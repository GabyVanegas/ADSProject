using ADSProject.Models;
using ADSProject.Repository;
using ADSProject.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IGrupoRepository grupoRepository;
        private readonly ICarreraRespositoy carreraRepository;
        private readonly IMateriaRespository materiaRepository;
        private readonly IProfesorRepository profesorRepository;
        private readonly ILogger<GrupoController> logger;
        public GrupoController(IGrupoRepository grupoRepository, ICarreraRespositoy carreraRespositoy, IMateriaRespository materiaRespository,
            IProfesorRepository profesorRepository, ILogger<GrupoController> logger)
        {
            this.grupoRepository = grupoRepository;
            this.carreraRepository = carreraRespositoy;
            this.materiaRepository = materiaRespository;
            this.profesorRepository = profesorRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                //var item = grupoRepository.obtenerGrupo();
                var item = grupoRepository.obtenerGrupos(new string[] { "Carreras", "Materias", "Profesores" });
                return View(item);
            }
            catch (Exception ex)
            {
                logger.LogError("Error en metodo index de controlador grupo", ex.Message);
                throw;
            }

        }

        [HttpGet]
        public IActionResult Form(int? idGrupo, Operaciones operaciones)
        {
            try
            {
                var grupos = new GrupoViewModel();

                if (idGrupo.HasValue)
                {
                    grupos = grupoRepository.obtenerGrupoPorID(idGrupo.Value);
                }
                // Indica el tipo de operacion que es esta realizando
                ViewData["Operaciones"] = operaciones;
                //Obtener todas las carreras disponibles
                ViewBag.Carreras = carreraRepository.obtenerCarrera();

                //Obtener todas las materias disponibles
                ViewBag.Materias = materiaRepository.obtenerMateria();

                //Obtener todas los profesores disponibles
                ViewBag.Profesores = profesorRepository.obtenerProfesor();
                return View(grupos);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Form(GrupoViewModel grupoViewModel)
        {
            try
            {
                if (grupoViewModel.idGrupo == 0) // En caso de insertar
                {
                    grupoRepository.agregarGrupo(grupoViewModel);
                }
                else // En caso de actualizar
                {
                    grupoRepository.actualizarGrupo
                        (grupoViewModel.idGrupo, grupoViewModel);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(int idGrupo)
        {
            try
            {
                grupoRepository.eliminarGrupo(idGrupo);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult cargarMaterias(int? idCarrera)
        {
            var listadoCarreras = idCarrera == null ? new List<MateriaViewModel>() :

            materiaRepository.obtenerMateria().Where(x => x.idCarrera == idCarrera);

            return StatusCode(StatusCodes.Status200OK, listadoCarreras);
        }
    }
}
