using ADSProject.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADSProject.Models
{
    [Table("AsignacionGrupos")]
    public class AsignacionGrupoViewModel
    {

            [Key]
            public int id { get; set; }
            [Display(Name = "idGrupo")]
            [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
            public int idGrupo { get; set; }
            [Display(Name = "Estudiantes")]
            [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
            public int idEstudiante { get; set; }
            [ForeignKey("idGrupo")]
            public GrupoViewModel Grupos { get; set; }
            [ForeignKey("idEstudiante")]
            public EstudianteViewModel Estudiantes { get; set; }
        
    }
}
