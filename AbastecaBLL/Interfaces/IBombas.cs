using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Interfaces
{
    public interface IBombas
    {
        Response Insert(BombascriarDTO dto);
        Response List(int page, int take, string filtro = null);
        Response GetByID(Guid id);
        Response Update(BombasUpdateDTO dto);
        Response Delete(Guid id);
    }
}
