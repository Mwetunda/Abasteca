using AbastecaDTO;
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
        Response Insert(MunicipioDTOcriar dto);
        Response List(int provinciaId);
        Response GetByID(int id);
        Response Update(MunicipioUpdateDTOcriar dto);
        Response Delete(int id);
    }
}
