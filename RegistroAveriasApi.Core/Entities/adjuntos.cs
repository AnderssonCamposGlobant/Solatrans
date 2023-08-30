using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class adjuntos
    {
        [Key]
        public int id_adjunto { get; set; }
        public int id_averia { get; set; }
        public string nombre { get; set; }
        public string archivo { get; set; }
        public bool activo { get; set; }        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_desactivacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_creacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_ultima_modificacion { get; set; }
        public string? creado_por { get; set; }
        [Required]
        public string? modificado_por { get; set; }
    }
}
