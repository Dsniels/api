using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace apisiase.Controllers
{

    public class ProfesorController : BaseController
    {
        private readonly IGenericRepository<Profesor> _repository;
        public ProfesorController( IGenericRepository<Profesor> repository) {
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> create(Profesor profesor)
        {

            var result = await _repository.add(profesor);

            if (result == 0)
            {
                throw new Exception("Error al insertar");
            }
            return Ok(profesor);

        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> update(int id, Profesor profesor)
        {
            profesor.Id = id;

            var result = await _repository.update(profesor);
            if(result == 0)
            {
                throw new Exception("Error al actualizar");
            }

            return Ok(profesor);
        }



        [HttpGet("GetNew")]
        public ActionResult getNew()
        {
            var ds = new Profesor();

            return Ok(ds);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> getAll()
        {
            var result = await _repository.getAllAsync();

            return Ok(result);
        }

        [HttpDelete("DeleteByID/{id}")]
        public async Task<ActionResult> deleteByID(int id)
        {
            var record = await _repository.getByID(id);
            if (record == null)
            {
                return NotFound();
            }

            var result = await _repository.DeleteEntity(record);

            return Ok(result);
        }



    }
}
