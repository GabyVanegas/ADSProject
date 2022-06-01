﻿using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class MateriaController : Controller 
    {
        private readonly IMateriaRespository materiaRepository;
        private readonly ICarreraRespositoy carreraRepository;
        private readonly ILogger<MateriaController> logger;
        public MateriaController(IMateriaRespository materiaRespository, ICarreraRespositoy carreraRespositoy,
            ILogger<MateriaController> logger)
        {
            this.materiaRepository = materiaRespository;
            this.carreraRepository = carreraRespositoy;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                //var item = materiaRepository.obtenerMateria();
                var item = materiaRepository.obtenerMateria(new string[] { "Carreras" });

                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en metodo index de controlador materia", ex.Message);
                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idmateria, Operaciones operaciones)
        {
            try
            {
                var materia = new MateriaViewModel();

                if (idmateria.HasValue)
                {
                    materia = materiaRepository.obtenerMateriaPorID(idmateria.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;
                ViewBag.Carreras = carreraRepository.obtenerCarrera();
                return View(materia);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(MateriaViewModel materiaViewModel)
        {
            try
            {
                if (materiaViewModel.idMateria == 0) // En caso de insertar
                {
                    materiaRepository.agregarMateria(materiaViewModel);
                }
                else // En caso de actualizar
                {
                    materiaRepository.actualizarMateria
                        (materiaViewModel.idMateria, materiaViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int idmateria)
        {
            try
            {
                materiaRepository.eliminarMateria(idmateria);
            }
            catch (Exception)
            {

                throw;
            }
            
            return RedirectToAction("Index");
        }
    }
}
