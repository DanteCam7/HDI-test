using Azure;
using HDI.Data;
using HDI.Models;
using HDI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HDI.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class OrdenesController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public OrdenesController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        

        [HttpGet("GetTotalOrdenesPorMesa")]
        public ResponseDto GetTotalOrdenesPorMesa()
        {
            try
            {
                var ordenesPorMesa = _context.ordenes
                    .GroupBy(o => o.mes_id)
                    .Select(g => new
                    {
                        MesId = g.Key,
                        TotalOrdenes = g.Count()
                    })
                    .ToList();

                _response.Data = ordenesPorMesa;
                _response.estatus = 200;
                _response.Message = "Proceso realizado";
                _response.codigo = 1;
            }
            catch (Exception ex)
            {
                _response.estatus = 500;
                _response.Message = ex.Message;
                _response.codigo = -1;
            }

            return _response;
        }

        [HttpGet("GetMesasDisponibles")]
        public ResponseDto GetMesasDisponibles()
        {
            try
            {
                var mesasDisponibles = _context.Mesas
                    .Where(m => m.mes_disponible == 1)
                    .GroupBy(m => m.mes_lugares)
                    .Select(g => new
                    {
                        MesLugares = g.Key,
                        TotalMesasDisponibles = g.Count()
                    })
                    .ToList();

                _response.Data = mesasDisponibles;
                _response.estatus = 200;
                _response.Message = "Proceso realizado";
                _response.codigo = 1;
            }
            catch (Exception ex)
            {
                _response.estatus = 500;
                _response.Message = ex.Message;
                _response.codigo = -1;
            }

            return _response;
        }

        [HttpPost("InsertarNuevaOrden")]
        public ResponseDto InsertarNuevaOrden([FromBody] ordenes nuevaOrden)
        {
            try
            {
                _context.ordenes.Add(nuevaOrden);
                _context.SaveChanges();

                _response.Data = nuevaOrden;
                _response.estatus = 200;
                _response.Message = "Proceso realizado";
                _response.codigo = 1;
            }
            catch (Exception ex)
            {
                _response.estatus = 500;
                _response.Message = ex.Message;
                _response.codigo = -1;
            }

            return _response;
        }

        [HttpPut("AgregarProductoAOrden")]
        public ResponseDto AgregarProductoAOrden([FromBody] OrdenesDetalle nuevoDetalle)
        {
            try
            {
                _context.OrdenesDetalle.Add(nuevoDetalle);
                _context.SaveChanges();

                _response.Data = nuevoDetalle;
                _response.estatus = 200;
                _response.Message = "Proceso realizado";
                _response.codigo = 1;
            }
            catch (Exception ex)
            {
                _response.estatus = 500;
                _response.Message = ex.Message;
                _response.codigo = -1;
            }

            return _response;
        }

        [HttpPut("CambiarEstatusOrden/{ord_id}")]
        public ResponseDto CambiarEstatusOrden(int ord_id, byte nuevoEstatus)
        {
            try
            {
                var orden = _context.ordenes.FirstOrDefault(o => o.ord_id == ord_id);
                if (orden != null)
                {
                    orden.ord_estatus = nuevoEstatus;
                    _context.SaveChanges();

                    _response.Data = orden;
                    _response.estatus = 200;
                    _response.Message = "Proceso realizado";
                    _response.codigo = 1;
                }
                else
                {
                    _response.estatus = 404;
                    _response.Message = "Orden no encontrada";
                    _response.codigo = -1;
                }
            }
            catch (Exception ex)
            {
                _response.estatus = 500;
                _response.Message = ex.Message;
                _response.codigo = -1;
            }

            return _response;
        }

        [HttpDelete("EliminarOrden/{ord_id}")]
        public ResponseDto EliminarOrden(int ord_id)
        {
            try
            {
                var orden = _context.ordenes.FirstOrDefault(o => o.ord_id == ord_id);
                if (orden != null)
                {
                    orden.ord_estatus = 0; // Borrado lógico
                    _context.SaveChanges();

                    _response.Data = orden;
                    _response.estatus = 200;
                    _response.Message = "Proceso realizado";
                    _response.codigo = 1;
                }
                else
                {
                    _response.estatus = 404;
                    _response.Message = "Orden no encontrada";
                    _response.codigo = -1;
                }
            }
            catch (Exception ex)
            {
                _response.estatus = 500;
                _response.Message = ex.Message;
                _response.codigo = -1;
            }

            return _response;
        }

    }

}
