using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class RolesDtoResponse
    {
        [Required]
        public int rol_id { get; set; }
        [Required]
        public string nombre_rol { get; set; }
        [Required]
        public string usuario_creador { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_creacion { get; set; }

        public List<string> permisos { get; set; }
    }
}
