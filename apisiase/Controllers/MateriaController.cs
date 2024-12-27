using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisiase.Controllers
{

    public class MateriaController : BaseController
    {
        private readonly IGenericRepository<Materia> _repository;

        public MateriaController(IGenericRepository<Materia> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() { 
            
            var records = await _repository.getAllAsync();

            return Ok(records); 
            
        }


        //[HttpGet("{id}")]
       // public Task<IActionResult> GetByID(int id) { }

        [HttpPost]
       public async Task<ActionResult> Create(Materia materia) {
        
           var result = await _repository.add(materia);
            if(result == 0)
            {
                throw new Exception("error al insertar");
            }


            return Ok(materia);
        }


    }
}
