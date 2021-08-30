﻿using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface IMunicipio
    {
        Response Insert(MunicipioDTO dto);
        Response List(int page, int take, string filtro = null);
        Response GetByID(int id);
        Response Update(MunicipioDTO dto);
        Response Delete(int id);
    }
}
