using System.Reflection;
using Database.Interfaces;
using Models;

namespace Database {
    public interface IUnitOfWork {
        void SaveChanges();

        UserRepository Users { get; set; }
        // TODO: declare Repositories
    }
}