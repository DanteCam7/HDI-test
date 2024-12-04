using System.ComponentModel.DataAnnotations;

namespace HDI.Models
{
    public class Mesas
    {
        public int mes_id { get; set; }

        public int mes_lugares { get; set; }

        public int mes_disponible { get; set; }

        public int mes_estatus { get; set; }
    }
}
