using AbastecaBLL.Interfaces;
using AbastecaDAL.EFC;
using AbastecaDAL.Entidades;
using AbastecaDTO;
using AbastecaDTO.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastecaBLL.Negocio
{
    public class MunicipioBLL:IMunicipio
    {
        private AbastecaContext context;
        private readonly ILogger<MunicipioBLL> logger;

        private Municipio municipio;

        public MunicipioBLL(AbastecaContext _context, ILogger<MunicipioBLL> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public Response Insert(MunicipioDTOcriar dto)
        {
            var res = new Response();
            municipio = new Municipio();

            try
            {
                municipio.Nome = dto.Nome;
                municipio.ProvinciaID = dto.ProvinciaID;

                context.Municipios.Add(municipio);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS01);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME01);
                return res.Bad(Recursos.MessagemErro.ME01);
            }
        }

        public Response List(int provinciaId)
        {
            var resposta = new Response();

            try
            {
                var lista = context.Municipios.Where(x=>x.ProvinciaID == provinciaId).AsNoTracking().AsQueryable();

                var municipios = lista.Select(x => new MunicipioDTO
                {
                    MunicipioID = x.MunicipioID,
                    Nome = x.Nome,
                    Provincia = new ProvinciaDTO
                    {
                        ProvinciaID = x.Provincia.ProvinciaID,
                        Nome = x.Provincia.Nome
                    }

                }).OrderBy(x => x.Nome);

                return resposta.Good(municipios);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME04);
                return resposta.Bad(Recursos.MessagemErro.ME04);
            }
        }

        public Response GetByID(int id)
        {
            var res = new Response();

            try
            {
                var municipio = context.Municipios.First(x => x.MunicipioID == id);

                if (municipio != null)
                {
                    return res.Good(municipio);
                }

                return res.Bad(Recursos.MessagemErro.ME05);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME05);
                return res.Bad(Recursos.MessagemErro.ME05);
            }
        }

        public Response Update(MunicipioUpdateDTOcriar dto)
        {
            var res = new Response();

            try
            {
                var municipio = context.Municipios.FirstOrDefault(x => x.MunicipioID == dto.MunicipioID);

                if (municipio == null)
                {
                    return res.Bad("");
                }

                municipio.Nome = dto.Nome;
                municipio.ProvinciaID = dto.ProvinciaID;

                context.Update(municipio);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS02);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME02);
                return res.Bad(Recursos.MessagemErro.ME02);
            }
        }

        public Response Delete(int id)
        {
            var res = new Response();

            try
            {
                var municipio = context.Municipios.First(x => x.ProvinciaID == id);

                if (municipio != null)
                {
                    context.Entry(municipio).State = EntityState.Deleted;

                    context.SaveChanges();

                    return res.Good(Recursos.MessagemSucesso.MS03);
                }

                return res.Bad(Recursos.MessagemErro.ME03);

            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME03);
                return res.Bad(Recursos.MessagemErro.ME03);
            }
        }
    }
}
