using System.ComponentModel.DataAnnotations;

namespace HDI.Models
{
    public class CatEstatusOrden
    {
        public int catord_id { get; set; }
        public string catord_nombre { get; set; }

        public int catord_estatus { get; set; }
    }
}
