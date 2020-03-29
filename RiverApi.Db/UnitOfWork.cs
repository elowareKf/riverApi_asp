using Database.Interfaces;
using Models;

namespace Database {
    public class UnitOfWork : IUnitOfWork{
        private readonly string _connectionString;
        public readonly RiverApiContext Context;

        public UnitOfWork(string connectionString) {
            _connectionString = connectionString;
            Context = new RiverApiContext(_connectionString);
            
            // TODO: Initialize Repositories:
            Users = new UserRepository(Context.User, Context);

        }
        
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public UserRepository Users { get; set; }
    }
}