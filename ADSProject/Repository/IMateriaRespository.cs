using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Repository
{
    public interface IMateriaRespository
    {
        List<MateriaViewModel> obtenerMateria();
        List<MateriaViewModel> obtenerMateria(string[] includes);
        int agregarMateria(MateriaViewModel materiaViewModel);

        int actualizarMateria(int idMateria, MateriaViewModel materiaViewModel);

        bool eliminarMateria(int idMateria);

        MateriaViewModel obtenerMateriaPorID(int idMateria);
    }
}
