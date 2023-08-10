using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class usuarios
    {
        [Key]
        public string nombre { get; set; }      
        public string apellidos { get; set; }
        public int empresa_id { get; set; }
        public string email { get; set; }
        public string? usuario { get; set; }
        public string password { get; set; }
        public string? idioma { get; set; }  
        public int rol_id { get; set; }
        public int usuario_id { get; set; }
        public int estado_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_registro { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_desactivacion { get; set; }
        public string? icono { get; set; }
    }
}
