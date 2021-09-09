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
    public class ProvinciaBLL:IProvincia
    {
        private AbastecaContext context;
        private readonly ILogger<ProvinciaBLL> logger;

        private Provincia provincia;

        public ProvinciaBLL(AbastecaContext _context, ILogger<ProvinciaBLL> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public Response Insert(ProvinciaCreatDTO dto)
        {
            var res = new Response();
            provincia = new Provincia();

            try
            {
                provincia.Nome = dto.Nome;

                context.Provincias.Add(provincia);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS01);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME01);
                return res.Bad(Recursos.MessagemErro.ME01);
            }
        }

        public Response List()
        {
            var resposta = new Response();

            try
            {
                var lista = context.Provincias.Include(x=>x.Municipios).AsNoTracking().AsQueryable();

                var provincias = lista.Select(x => new ProvinciaDTO
                {
                    ProvinciaID = x.ProvinciaID,
                    Nome = x.Nome,
                }).OrderBy(x => x.Nome);

                return resposta.Good(provincias);
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
                var provincia = context.Provincias.First(x => x.ProvinciaID == id);

                if (provincia != null)
                {
                    return res.Good(provincia);
                }

                return res.Bad(Recursos.MessagemErro.ME05);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME05);
                return res.Bad(Recursos.MessagemErro.ME05);
            }
        }

        public Response Update(ProvinciaUpdateDTO dto)
        {
            var res = new Response();

            try
            {
                var provincia = context.Provincias.FirstOrDefault(x => x.ProvinciaID == dto.ProvinciaID);

                if (provincia == null)
                {
                    return res.Bad("");
                }

                provincia.Nome = dto.Nome;
                
                context.Update(provincia);
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
                var usuario = context.Provincias.First(x => x.ProvinciaID == id);

                if (usuario != null)
                {
                    context.Entry(usuario).State = EntityState.Deleted;

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
