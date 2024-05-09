namespace API_ProyectoDSWI.Models
{
    public class Boleta
    {
        public int? codigo {  get; set; }
        public int? codigoUsuario { get; set; }
        public int? codigoCliente { get; set; }
        public DateTime? fechaEmision {  get; set; }
        public int? codigoProducto { get; set; }
        public double? totalPagar {  get; set; }
    }
}
