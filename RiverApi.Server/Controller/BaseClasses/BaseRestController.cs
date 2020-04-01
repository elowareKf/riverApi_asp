using Microsoft.AspNetCore.Mvc;
using Models;
using RiverApi.Db.Interfaces;

namespace RiverApi.Server.Controller.BaseClasses {
    public abstract class BaseRestController<TModel> : ControllerBase
        where TModel : ModelBase, new() {
        protected readonly IRepository<TModel> _repository;

        protected BaseRestController(IRepository<TModel> repository) {
            _repository = repository;
        }

        [HttpGet]
        public virtual IActionResult Get() {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id) {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        public virtual IActionResult Post(TModel message) {
            return Ok(_repository.Add(message));
        }

        [HttpPut]
        public virtual IActionResult Put(TModel entity) {
            return Ok(_repository.Update(entity));
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id) {
            var entity = _repository.Get(id);
            if (entity == null)
                return NotFound();

            _repository.Delete(entity);
            return Ok();
        }

        [HttpOptions]
        public virtual IActionResult GetPrototype() => Ok(new TModel());
    }
}