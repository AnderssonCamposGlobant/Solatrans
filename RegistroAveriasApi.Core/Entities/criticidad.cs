using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Entities
{
    public class criticidad
    {
        [Key]
        public int id_criticidad { get; set; }
        public string? descripcion { get; set; }
        public string? color { get; set; }
    }
}
