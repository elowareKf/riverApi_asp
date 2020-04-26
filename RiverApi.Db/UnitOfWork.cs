using Microsoft.EntityFrameworkCore;
using Models;
using RiverApi.Db.Interfaces;

namespace RiverApi.Db {
    public class UnitOfWork : IUnitOfWork {
        private readonly string _connectionString;
        public readonly RiverApiContext Context;

        public UserRepository Users { get; set; }
        public IRepository<River> Rivers { get; set; }
        public IRepository<LevelSpot> LevelSpots { get; set; }
        public IRepository<Measurement> Measurements { get; set; }
        public IRepository<Section> Sections { get; set; }

        public UnitOfWork(string connectionString) {
            _connectionString = connectionString;
            Context = new RiverApiContext(_connectionString);

            Users = new UserRepository(Context.User, Context);
            Rivers = new Repository<River>(Context.Rivers, Context);
            LevelSpots = new Repository<LevelSpot>(Context.LevelSpots, Context);
            Measurements = new Repository<Measurement>(Context.Measurements, Context);
            Sections = new Repository<Section>(Context.Sections, Context);
        }

        public IRepository<HotSpot> HotSpots { get; set; }

        public void SaveChanges() {
            Context.SaveChanges();
        }
    }
}