using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDApp.Models
{
    public class Candidato
    {
        public Candidato()
        { }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Party { get; set; }

        public string District { get; set; }

        public string Platform { get; set; }

        public int? UsuarioModificacion { get; set; }
        public virtual Usuarios? UsuariosModificacion { get; set; }
        public int? UsuarioCreador { get; set; }
        public virtual Usuarios? UsuariosCreador { get; set; }
    }
}
