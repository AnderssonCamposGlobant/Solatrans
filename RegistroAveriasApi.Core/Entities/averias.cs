﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class averias
    {
        [Key]
        public int id_averia { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fecha_averia { get; set; }
        public int id_tipo_averia { get; set; }
        public int id_empresa { get; set; }      
        public int id_linea { get; set; }
        public int id_sub_linea { get; set; }
        public int id_tipo_servicio { get; set; }
        public string? placa_vehiculo { get; set; }
        public int id_vehiculo { get; set; }
        public int id_conductor { get; set; }
        public int id_parada { get; set; }
        public string? descripcion { get; set; }
        public int id_estado_averia { get; set; }
        public int id_criticidad { get; set; }   
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
