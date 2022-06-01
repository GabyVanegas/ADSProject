using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface IAsignacionGrupoRepository
    {
        public int agregarAsignacionGrupo(GrupoViewModel grupoViewModel);

        public void agregarAsignacionGrupo(ICollection<AsignacionGrupoViewModel> asignacionGrupoViewModel);

        public int actualizarAsignacionGrupo(int idGrupo, AsignacionGrupoViewModel asignacionGrupoViewModel);

        public bool deleteAsignacionGrupo(int idGrupo);

        public List<AsignacionGrupoViewModel> obtenerAsignacionesGrupo();

        public AsignacionGrupoViewModel obtenerAsignacionPorID(int idGrupo);
    }
}
