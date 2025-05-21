namespace ExamenLenguajes.Model
{
    public class Alquiler
    {
        public int ApartamentoId { get; set; }
        public string Identificacion { get; set; } = null!;
        public string NombreInquilino { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public int CantidadMeses { get; set; }
    }
}
