using AbastecaBLL.Interfaces;
using AbastecaDTO;
using AbastecaDTO.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Negocio
{
    public class GerenteBLL:IGerente
    {
        public Response Insert(GerenteDTO dto, int userId)
        {
            throw new NotImplementedException();
        }
        public Response GetByID(int id)
        {
            throw new NotImplementedException();
        }
        public Response List(int page, int take, string filtro = null)
        {
            throw new NotImplementedException();
        }

        public Response Update(GerenteDTO dto)
        {
            throw new NotImplementedException();
        }
        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
