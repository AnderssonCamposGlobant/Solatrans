using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Dtos
{
    public class CreateAveriasDto
    {
        [Required]
        public int id_averia { get; set; }
        [Required]
        public int id_operador { get; set; }
        [Required]
        public int id_linea { get; set; }
        [Required]
        public int id_sublinea { get; set; }
        [Required]
        public int cod_tipo_averia { get; set; }
        public string? descripcion { get; set; }
        [Required]
        public int cod_tipo_servicio { get; set; }
        /*[Required]
        public int id_vehiculo { get; set; }*/
        [Required]
        public string? placa { get; set; }
        [Required]
        public int id_conductor { get; set; }
        [Required]
        public int id_parada { get; set; }

        [Required]
        public int id_ficha_autobus { get; set; }
        public int id_estado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_creacion { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fecha_modificacion { get; set; }
        public int id_usuario { get; set; }
        //public string? modificado_por { get; set; }
    }
}
