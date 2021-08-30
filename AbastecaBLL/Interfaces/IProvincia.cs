using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface IProvincia
    {
        Response Insert(ProvinciaDTO dto);
        Response List(int page, int take, string filtro = null);
        Response GetByID(int id);
        Response Update(ProvinciaDTO dto);
        Response Delete(int id);
    }
}
