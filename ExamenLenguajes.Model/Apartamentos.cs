using System.Data.SqlTypes;

namespace ExamenLenguajes.Model
{
    public class Apartamentos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumeroDePiso { get; set; }
        public string Descripcion { get; set; }
        public int PrecioPorMes { get; set; }
        public Estado Estado { get; set; }

        public string? IdentificacionInquilino { get; set; }
        public string? NombreInquilino { get; set; }
        public DateTime? FechaInicioAlquiler { get; set; }
        public int? CantidadDeMesesAlquiler { get; set; }
        public int? DepositoDeGarantia { get; set; }


    }
}
