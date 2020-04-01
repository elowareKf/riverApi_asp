using System.Linq;

namespace RiverApi.Db.Interfaces {
    public interface IRepository<TModel> {
        TModel Get(int id, bool noTracking = false);
        IQueryable<TModel> Get();
        TModel Update(TModel entity);
        TModel Add(TModel entity);
        void Delete(TModel entity);
        void Delete(int id);
    }
}