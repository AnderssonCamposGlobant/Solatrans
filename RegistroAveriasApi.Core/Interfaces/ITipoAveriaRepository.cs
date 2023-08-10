﻿using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Interfaces
{
    public interface ITipoAveriaRepository
    {
        Task<IReadOnlyList<tipo_averia>> GetAllAsync();
        Task<tipo_averia> GetTipoAveriaByIdAsync(int codigo);
        void addTipoAveria(CreateTipoAveriaDtos averiaRegistro);
        //void updateTipoAveria(int codigo, EstadoAveriaUpdateDto estadoAveria);
        Task<int> deleteTipoAveria(int codigo);
    }
}
