using apisiase.Dto;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisiase.Controllers
{

    public class MateriaController : BaseController
    {
        private readonly IGenericRepository<Profesor> _profesorRepostory;
        private readonly IGenericRepository<Carrera> _carreraRepostory;
        private readonly IGenericRepository<Materia> _repository;
        private readonly IMateriasRepository _materiasRepository;

        public MateriaController(IGenericRepository<Profesor> profesorRepository, IGenericRepository<Carrera> carreraRepostory, IGenericRepository<Materia> repository, IMateriasRepository materiasRepository)
        {
            _profesorRepostory = profesorRepository;
            _carreraRepostory = carreraRepostory;
            _repository = repository;
            _materiasRepository = materiasRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {

            var records = await _materiasRepository.getMateriasAsync();


            return Ok(records);

        }

        [HttpGet("GetByProfesor/{id}")]
        public async Task<ActionResult> GetByProfesor(int id)
        {

            var records = await _materiasRepository.getMateriasWhereProfesor(id);
            if (records == null)
            {
                return NotFound();
            }

            var results = records.Select(m => new MateriaProfesorDto
            {
                Nombre = m.Nombre,
                CarreraID = m.Carrera.Id,
                Carrera = m.Carrera.Nombre,
                Id = m.Id
            }).ToList();

            return Ok(results);


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


        [HttpGet("GetByCarrera/{id}")]
        public async Task<ActionResult> GetByCarrera(int id)
        {

            var records = await _materiasRepository.getMateriasWhereCarrera(id);
            if (records == null)
            {
                return NotFound();
            }

            var results = records.Select(m => new MateriaCarreraDto
            {
                Nombre = m.Nombre,
                ProfesorId = m.Profesor.Id,
                Profesor = m.Profesor.Nombre,
                Id = m.Id
            }).ToList();

            return Ok(results);

        }
        [HttpGet("GetByProfesorAndCarrera")]
        public async Task<ActionResult> GetByProfesorAndCarrera([FromQuery] int profesorId, [FromQuery] int carreraId)
        {
            if (profesorId <= 0 || carreraId <= 0)
                return BadRequest("");

            var materias = await _materiasRepository.getMateriasWhereProfesorAndCarrera(profesorId, carreraId);

            if (!materias.Any())
                return NotFound("No se encontraron materias con los criterios especificados");

            return Ok(materias);
        }
        [HttpGet("GetByID/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {

            var materia = await _materiasRepository.getMateriaByIdAsnc(id);

            if (materia == null)
            {
                return NotFound();
            }


            return Ok(materia);

        }

        [HttpPost("Add")]
        public async Task<ActionResult> Create(MateriaDto materia)
        {


            var profesor = await _profesorRepostory.getByID(materia.ProfesorId);
            var carrera = await _carreraRepostory.getByID(materia.CarreraId);
            if (profesor == null || carrera == null)
                return BadRequest("Profesor o Carrera no encontrados");
            var newMateria = new Materia
            {
                Nombre = materia.Nombre,
                Profesor = profesor,
                Carrera = carrera
            };
            var result = await _repository.add(newMateria);
            if (result == 0)
            {
                throw new Exception("error al insertar");
            }

            return Ok(result);
        }


    }
}
