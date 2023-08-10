using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class UsuariosDto
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public int empresa_id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string? usuario { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string? idioma { get; set; }
        [Required]
        public int rol_id { get; set; }
        [Required]
        public int usuario_id { get; set; }
        [Required]
        public int estado_id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_registro { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_desactivacion { get; set; }
        [Required]
        public string icono { get; set; }
    }
}
