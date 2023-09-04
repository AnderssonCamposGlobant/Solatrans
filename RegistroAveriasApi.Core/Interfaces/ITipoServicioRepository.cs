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
        Task<IReadOnlyList<tipo_servicios>> GetAllAsync();
        Task<tipo_servicios> GetTipoServicioByIdAsync(int codigo);
        void addTipoServicio(CreateTipoServicioDtos tipoServicioDtos);
        //void updateTipoServicio(int codigo, EstadoAveriaUpdateDto estadoAveria);
        Task<int> deleteTipoServicio(int codigo);
    }
}
