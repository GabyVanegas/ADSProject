using ADSProject.Data;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public class AsignacionGrupoRepository : IAsignacionGrupoRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AsignacionGrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int actualizarAsignacionGrupo(int idGrupo, AsignacionGrupoViewModel asignacionGrupoViewModel)
        {
            try
            {
                var item = applicationDbContext.AsignacionGrupos.SingleOrDefault(x => x.id == idGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(asignacionGrupoViewModel);
                applicationDbContext.SaveChanges();

                return asignacionGrupoViewModel.id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int agregarAsignacionGrupo(GrupoViewModel grupoViewModel)
        {
            try
            {
                ;

                if (grupoViewModel.AsignacionGrupos != null)
                {
                    agregarAsignacionGrupo(grupoViewModel.AsignacionGrupos);

                }

                return grupoViewModel.idGrupo;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel)
        {
            try
            {
                applicationDbContext.AsignacionGrupos.AddRange(asignacionGrupoViewModel);

                applicationDbContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool deleteAsignacionGrupo(int idGrupo)
        {
            try
            {
                var item = applicationDbContext.AsignacionGrupos.Where(x => x.id == idGrupo).ToList();

                applicationDbContext.AsignacionGrupos.RemoveRange(item);
                applicationDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AsignacionGrupoViewModel> obtenerAsignacionesGrupo()
        {
            try
            {
                return applicationDbContext.AsignacionGrupos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AsignacionGrupoViewModel obtenerAsignacionPorID(int idGrupo)
        {
            try
            {
                return applicationDbContext.AsignacionGrupos.SingleOrDefault(x => x.id == idGrupo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
