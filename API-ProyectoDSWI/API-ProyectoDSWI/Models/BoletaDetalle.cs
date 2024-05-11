namespace API_ProyectoDSWI.Models
{
    public class BoletaDetalle
    {
        public int? codigo { get; set; }
        public string? usuario { get; set; }
        public string? cliente { get; set; }
        public DateTime? fechaEmision { get; set; }
        public string? producto { get; set; }
        public double? totalPagar { get; set; }
    }
}
