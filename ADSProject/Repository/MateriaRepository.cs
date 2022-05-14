using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class MateriaRepository : IMateriaRespository
    {
        //private readonly List<MateriaViewModel> lstMaterias;
        private readonly ApplicationDbContext applicationDbContext;
        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            /*lstMaterias = new List<MateriaViewModel>
            {
                new MateriaViewModel{ idMateria = 1, nombreMateria = "Analisis de sistemas"}
            };*/
            this.applicationDbContext = applicationDbContext;
        }

        public int agregarMateria(MateriaViewModel materiaViewModel)
        {
            try
            {
                /*if (lstMaterias.Count > 0)
                {
                    materiaViewModel.idMateria = lstMaterias.Last().idMateria + 1;
                }
                else
                {
                    materiaViewModel.idMateria = 1;
                }
                lstMaterias.Add(materiaViewModel);*/
                applicationDbContext.Materias.Add(materiaViewModel);
                applicationDbContext.SaveChanges();
                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel)
        {
            try
            {
                //lstMaterias[lstMaterias.FindIndex(x => x.idMateria == idMateria)] = materiaViewModel;
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materiaViewModel);

                applicationDbContext.SaveChanges();
                return materiaViewModel.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool eliminarMateria(int idMateria)
        {
            try
            {
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);
                item.estado = false;

                applicationDbContext.Attach(item);

                applicationDbContext.Entry(item).Property(x => x.estado).IsModified = true;

                applicationDbContext.SaveChanges();
                //lstMaterias.RemoveAt(lstMaterias.FindIndex(x => x.idMateria == idMateria));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MateriaViewModel obtenerMateriaPorID(int idMateria)
        {
            try
            {
                //var item = lstMaterias.Find(x => x.idMateria == idMateria);
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<MateriaViewModel> obtenerMateria()
        {
            try
            {
                return applicationDbContext.Materias.Where(x => x.estado == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
