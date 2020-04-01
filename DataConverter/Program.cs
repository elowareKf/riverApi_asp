using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Models;
using MySql.Data.MySqlClient;
using RiverApi.Db;

namespace DataConverter {
    class Program {
        private static Dictionary<int, River> _rivers;
        private static Dictionary<int, Section> _sections;
        private static Dictionary<int, LevelSpot> _levelSpots;

        static void Main(string[] args) {
            _rivers = new Dictionary<int, River>();
            _sections = new Dictionary<int, Section>();
            _levelSpots = new Dictionary<int, LevelSpot>();

            Console.WriteLine("Converting MySQL into MSSQL...");
            var mysql =
                new MySqlConnection(
                    "server=localhost;Port=1435;uid=root;pwd=MySqlServer.1;Database=dbs91425");
            mysql.Open();
            GetRivers(mysql);
            GetLevelSpots(mysql);
            GetSections(mysql);
            GetMeasurements(mysql);
            mysql.Close();

            var unitOfWork = new UnitOfWork(null);
            _rivers.Select(r => unitOfWork.Rivers.Add(r.Value));
            unitOfWork.SaveChanges();
        }

        private static void GetMeasurements(MySqlConnection mysql) {
            var command = mysql.CreateCommand();
            command.CommandText = "select * from measurements";
            using var reader = command.ExecuteReader();
            while (reader.Read()) {
                var measurement = new Measurement {
                    TimeStamp = GetValue<DateTime>(reader, "TimeStamp"),
                    Level = (double?) GetValue<decimal?>(reader, "Level"),
                    Flow = (double?) GetValue<decimal?>(reader, "Flow"),
                    Temperature = (double?) GetValue<decimal?>(reader, "Temperature"),
                };

                var spotKey = (int) reader["levelSpot"];
                if (_levelSpots.ContainsKey(spotKey)) {
                    _levelSpots[spotKey].Measurements.Add(measurement);
                }
            }

            reader.Close();
        }

        private static void GetLevelSpots(MySqlConnection mysql) {
            var command = mysql.CreateCommand();
            command.CommandText = "select * from levelSpots";

            using var reader = command.ExecuteReader();
            while (reader.Read()) {
                var levelSpot = new LevelSpot {
                    ApiUrl = GetValue<string>(reader, "ApiUrl"),
                    Name = GetValue<string>(reader, "Name"),
//CreekKm = GetValue<string>(reader, "CreekKm"), 
                    Location = GetValue<string>(reader, "Location"),
                    LastMeasurement = GetValue<DateTime>(reader, "LastMeasurement"),
                    Flow = (double?) GetValue<decimal>(reader, "Flow"),
                    Level = (double?) GetValue<decimal>(reader, "Level"),
                    Temperature = (double?) GetValue<decimal>(reader, "Temperature"),
                    Measurements = new List<Measurement>(), 
//RiverId = GetValue<string>(reader, "RiverId"), 
//SectionId = GetValue<string>(reader, "SectionId"), 
                };

                var key = (int) reader["id"];
                var riverKey = (int) reader["river"];
                if (!_rivers.ContainsKey(riverKey)) {
                    Console.WriteLine($"River Key not found {riverKey} on LevelSpot {key}");
                }
                else
                    _rivers[riverKey].LevelSpots.Add(levelSpot);

                _levelSpots.Add(key, levelSpot);
            }

            reader.Close();
        }

        private static void GetRivers(MySqlConnection mysql) {
            var command = mysql.CreateCommand();
            command.CommandText = "select * from rivers";
            var reader = command.ExecuteReader();
            while (reader.Read()) {
                _rivers.Add((int) reader["id"], new River {
                    Name = (string) reader["name"],
                    Sections = new List<Section>(),
                    LevelSpots = new List<LevelSpot>()
                });
            }

            reader.Close();
        }

        private static TValue GetValue<TValue>(IDataRecord reader, string name) {
            try {
                return (TValue) (reader[name] == DBNull.Value ? default(TValue) : reader[name]);
            }
            catch (Exception exception) {
                Console.WriteLine($"Field {name} - " + exception.Message);
                throw;
            }
        }

        private static void GetSections(MySqlConnection mysql) {
            var command = mysql.CreateCommand();
            command.CommandText = "select * from sections";
            using var reader = command.ExecuteReader();
            while (reader.Read()) {
                var section = new Section {
                    Name = GetValue<string>(reader, "Name"),
                    Country = GetValue<string>(reader, "Country"),
                    Grade = GetValue<string>(reader, "General_Grade"),
                    SpotGrade = GetValue<string>(reader, "Spot_Grades"),
                    Type = GetValue<string>(reader, "Type"),
                    Origin = GetValue<string>(reader, "Origin"),
                    ExtLevelSpot = GetValue<string>(reader, "ExtLevelSpot"),
                    ExtLevelType = GetValue<string>(reader, "ExtLevelType"),

                    PutIn =
                        $"{GetValue<float?>(reader, "LatStart")};{GetValue<float?>(reader, "LngStart")}",
                    TakeOut =
                        $"{GetValue<float?>(reader, "LatEnd")};{GetValue<float?>(reader, "LngEnd")}",

                    MinFlow = GetValue<float?>(reader, "MinFlow"),
                    MidFlow = GetValue<float?>(reader, "MidFlow"),
                    MaxFlow = GetValue<float?>(reader, "MaxFlow"),
                    MinLevel = GetValue<float?>(reader, "MinLevel"),
                    MidLevel = GetValue<float?>(reader, "MidLevel"),
                    MaxLevel = GetValue<float?>(reader, "MaxLevel"),
                };

                var key = (int) reader["river"];
                _rivers[key].Sections.Add(section);

                var levelSpotKey = GetValue<int?>(reader, "levelSpot");
                if (levelSpotKey == null)
                    continue;

                if (!_levelSpots.ContainsKey(levelSpotKey.Value)) {
                    Console.WriteLine($"LevelSpot Key not found {levelSpotKey} on Section {key}");
                }
                else
                    section.LevelSpot = _levelSpots[levelSpotKey.Value];


                _sections.Add(
                    GetValue<int>(reader, "Id"),
                    section
                );
            }

            reader.Close();
        }
    }
}