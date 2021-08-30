﻿using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface ISupervisor
    {
        Response Insert(SupervisorDTO dto, int userId, int bombasId);
        Response List(int page, int take, string filtro = null);
        Response GetByID(int id);
        Response Update(SupervisorDTO dto);
        Response Delete(int id);
    }
}
