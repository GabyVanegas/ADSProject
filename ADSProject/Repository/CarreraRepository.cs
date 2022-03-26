using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class CarreraRepository : ICarreraRespositoy
    {
        private readonly List<CarreraViewModel> lstCarrera;

        public CarreraRepository()
        {
            lstCarrera = new List<CarreraViewModel>
            {
                new CarreraViewModel{ idCarrera = 1, codigoCarrera = "I04", nombreCarrera = "Ingenieria en Sistemas"}
            };
        }
        public int agregarCarrera(CarreraViewModel carreraViewModel)
        {
            try
            {
                if (lstCarrera.Count > 0)
                {
                    carreraViewModel.idCarrera = lstCarrera.Last().idCarrera + 1;
                }
                else
                {
                    carreraViewModel.idCarrera = 1;
                }
                lstCarrera.Add(carreraViewModel);
                return carreraViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int actualizarCarrera(int idCarrera, CarreraViewModel carreraViewModel)
        {
            try
            {
                lstCarrera[lstCarrera.FindIndex(x => x.idCarrera == idCarrera)] = carreraViewModel;
                return carreraViewModel.idCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool eliminarCarrera(int idCarrera)
        {
            try
            {
                lstCarrera.RemoveAt(lstCarrera.FindIndex(x => x.idCarrera == idCarrera));
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CarreraViewModel obtenerCarreraPorID(int idCarrera)
        {
            try
            {
                var item = lstCarrera.Find(x => x.idCarrera == idCarrera);
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<CarreraViewModel> obtenerCarrera()
        {
            try
            {
                return lstCarrera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
