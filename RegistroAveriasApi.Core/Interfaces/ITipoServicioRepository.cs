using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Interfaces
{
    public interface ITipoServicioRepository
    {
        Task<IReadOnlyList<tipo_servicio>> GetAllAsync();
        Task<tipo_servicio> GetTipoServicioByIdAsync(int codigo);
        void addTipoServicio(CreateTipoServicioDtos tipoServicioDtos);
        //void updateTipoServicio(int codigo, EstadoAveriaUpdateDto estadoAveria);
        Task<int> deleteTipoServicio(int codigo);
    }
}
