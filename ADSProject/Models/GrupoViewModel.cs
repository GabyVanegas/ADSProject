﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSProject.Models
{
    public class GrupoViewModel
    {
        [Display(Name = "ID")]
        [Key]
        public int idGrupo { get; set; }

        [Display(Name = "ID Carrera")]
        public int idCarrera { get; set; }
        [Display(Name = "ID Materia")]
        public int idMateria { get; set; }
        [Display(Name = "ID Profesor")]
        public int idProfesor { get; set; }
        [Display(Name = "Ciclo")]
        public string ciclo { get; set; }
        [Display(Name = "Año")]
        public int anio { get; set; }
        public bool estado { get; set; }
    }
}
