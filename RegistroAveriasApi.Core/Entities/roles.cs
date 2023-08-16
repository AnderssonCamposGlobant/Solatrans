using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class roles
    {
        [Key]
        public int rol_id { get; set; }      
        public string nombre_rol { get; set; }
        public string usuario_creador { get; set; }
        public int permiso_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_creacion { get; set; }
    }
}
