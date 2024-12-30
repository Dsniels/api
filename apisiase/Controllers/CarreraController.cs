using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace apisiase.Controllers
{

    public class CarreraController : BaseController
    {

        private readonly IGenericRepository<Carrera> _repository;   

        public CarreraController(IGenericRepository<Carrera> repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> create(Carrera carrera)
        {

            var result = await  _repository.add(carrera);

            if(result == 0)
            {
                throw new Exception("Error al insertar");
            }
            return Ok(carrera);  

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
            if(record == null)
            {
                return NotFound();
            }

             var result = await _repository.DeleteEntity(record);

            return Ok(result);
        }
    }
}
