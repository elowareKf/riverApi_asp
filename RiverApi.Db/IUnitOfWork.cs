using System.IO;
using Models;
using RiverApi.Db.Interfaces;

namespace RiverApi.Db {
    public interface IUnitOfWork {
        UserRepository Users { get; set; }
        IRepository<River> Rivers { get; set; }
        IRepository<LevelSpot> LevelSpots { get; set; }
        IRepository<Measurement> Measurements { get; set; }
        IRepository<Section> Sections { get; set; }
        IRepository<HotSpot> HotSpots { get; set; }
        void SaveChanges();
    }
}