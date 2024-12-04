using System.ComponentModel.DataAnnotations;

namespace HDI.Models
{
    public class OrdenesDetalle
    {
        public int orddet_id { get; set; }
        public int ord_id { get; set; }
        public int pro_id { get; set; }
        public short orddet_cantidad { get; set; }
        public byte orddet_estatus { get; set; }
    }
}
