﻿using apisiase.Dto;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        public async Task<ActionResult> GetAll([FromQuery] MateriaSpecificationParams materiaParams)
        {
            var spec = new MateriaWithProfesorAndCarreraSpecification(materiaParams);

            var records = await _repository.getAllWithSpec(spec);


            return Ok(records);

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

        [HttpGet("GetNew")]
        public ActionResult getNew()
        {
            var ds = new MateriaDto();

            return Ok(ds);
        }


        [HttpPut("Update/{id}")]
        public async Task<ActionResult> update(int id, Materia materia)
        {
            materia.Id = id;
            var result = await _repository.update(materia);
            
            if(result == 0)
            {
                throw new Exception("Error al actualizar");
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
