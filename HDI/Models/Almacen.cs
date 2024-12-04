using System.ComponentModel.DataAnnotations;

namespace HDI.Models
{
    public class Almacen
    {
        public int alm_id { get; set; }
        public int alm_cantidad { get; set; }
        public DateTime alm_fecha_actualizacion { get; set; }
        public byte alm_estatus { get; set; }
    }
}
