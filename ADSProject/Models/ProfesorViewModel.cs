using System;
using ADSProject.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class ProfesorViewModel
    {
        [Display(Name = "ID")]
        [Key]
        public int idProfesor { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La longitud del campo no debe ser mayor a 50 caracteres ni menor de 3 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombresProfesor { get; set; }

        [Display(Name = "Apellido")]
        public string apellidosProfesor { get; set; }
        
        [Display(Name = "Correo")]
        public string correoProfesor { get; set; }
        public bool estado { get; set; }
    }
}
