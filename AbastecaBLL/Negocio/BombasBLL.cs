using AbastecaBLL.Helpers;
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
    public class BombasBLL : IBombas
    {
        private AbastecaContext context;
        private readonly ILogger<BombasBLL> logger;

        private Bomba bombas;

        public BombasBLL(AbastecaContext _context, ILogger<BombasBLL> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public Response Insert(BombascriarDTO dto)
        {
            var res = new Response();
            bombas = new Bomba();

            try
            {
                bombas.BombaID = Guid.NewGuid();
                bombas.Localidade = dto.Localidade;
                bombas.MunicipioID = dto.MunicipioID;
                bombas.Latitude = dto.Latitude;
                bombas.Longitude = dto.Longitude;
                bombas.OperadoraID = dto.OperadoraID;
                bombas.Sinal = 1;
                bombas.DataCadastro = DateTime.Now;
                bombas.DataActualizacao = DateTime.Now;

                context.Bombas.Add(bombas);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS01);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME01);
                return res.Bad(Recursos.MessagemErro.ME01);
            }
        }

        public Response List(int page, int take, string filtro = null)
        {
            var resposta = new Response();

            try
            {
                var lista = context.Bombas.AsNoTracking().AsQueryable();

                var bombas = lista.Select(x => new  BombasDTO
                {
                    Sinal = x.Sinal,
                    BombaID = x.BombaID,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    Localidade = x.Localidade,
                    Municipio = new MunicipioDTO
                    {
                        MunicipioID = x.Municipio.MunicipioID,
                        Nome = x.Municipio.Nome,
                        
                    },
                    Operadora = new OperadoraDTO
                    {
                        OperadoraID = x.Operadora.OperadoraID,
                        Nome = x.Operadora.Nome
                    } 

                }).Paginar(page, take);

                return resposta.Good(bombas);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME04);
                return resposta.Bad(Recursos.MessagemErro.ME04);
            }
        }

        public Response GetByID(Guid id)
        {
            var res = new Response();

            try
            {
                var bombas = context.Bombas.First(x => x.BombaID == id);

                if (bombas != null)
                {
                    return res.Good(bombas);
                }

                return res.Bad(Recursos.MessagemErro.ME05);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME05);
                return res.Bad(Recursos.MessagemErro.ME05);
            }
        }

        public Response Update(BombasUpdateDTO dto)
        {
            var res = new Response();

            try
            {
                var bombas = context.Bombas.FirstOrDefault(x => x.BombaID == dto.BombaID);

                if (bombas == null)
                {
                    return res.Bad("");
                }

                bombas.Latitude = dto.Latitude;
                bombas.Longitude = dto.Longitude;
                bombas.MunicipioID = dto.MunicipioID;
                bombas.Localidade = dto.Localidade;
                bombas.OperadoraID = dto.OperadoraID;
                bombas.MunicipioID = dto.MunicipioID;
                bombas.DataActualizacao = DateTime.Now;

                context.Update(bombas);
                context.SaveChanges();

                return res.Good(Recursos.MessagemSucesso.MS02);
            }
            catch (Exception e)
            {
                logger.LogError(e, Recursos.MessagemErro.ME02);
                return res.Bad(Recursos.MessagemErro.ME02);
            }
        }

        public Response Delete(Guid id)
        {
            var res = new Response();

            try
            {
                var bombas = context.Bombas.First(x => x.BombaID == id);

                if (bombas != null)
                {
                    context.Entry(bombas).State = EntityState.Deleted;

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
