﻿using Microsoft.AspNetCore.Mvc;
using System;
using ADSProject.Models;
using ADSProject.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSProject.Utils;
using Microsoft.Extensions.Logging;

namespace ADSProject.Controllers
{
    public class CarreraController : Controller
    {
        private readonly ICarreraRespositoy carreraRespositoy;
        private readonly ILogger<CarreraController> logger;
        public CarreraController(ICarreraRespositoy carreraRespositoy, ILogger<CarreraController> logger)
        {
            this.carreraRespositoy = carreraRespositoy;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var item = carreraRespositoy.obtenerCarrera();

                return View(item);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idCarrera, Operaciones operaciones)
        {
            try
            {
                var carrera = new CarreraViewModel();

                if (idCarrera.HasValue)
                {
                    carrera = carreraRespositoy.obtenerCarreraPorID(idCarrera.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;

                return View(carrera);

            }
            catch (Exception ex)
            {
                logger.LogError("Error en metodo index de controlador carrera", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(CarreraViewModel carreraViewModel)
        {
            try
            {
                if (carreraViewModel.idCarrera == 0) // En caso de insertar
                {
                    carreraRespositoy.agregarCarrera(carreraViewModel);
                }
                else // En caso de actualizar
                {
                    carreraRespositoy.actualizarCarrera
                        (carreraViewModel.idCarrera, carreraViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Delete(int idCarrera)
        {
            try
            {
                carreraRespositoy.eliminarCarrera(idCarrera);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
