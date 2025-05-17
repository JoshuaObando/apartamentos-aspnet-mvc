namespace ExamenLenguajes.BL
{
    public class GestionAlquileres
    {
        public static double CalcularMontoDeposito(double precioPorMes, int cantidadMeses)
        {
            if (cantidadMeses < 12)
                return precioPorMes;
            else if (cantidadMeses < 24)
                return precioPorMes * 0.75;
            else
                return precioPorMes * 0.5;
        }

        public static DateTime CalcularFechaFinal(DateTime inicio, int meses)
        {
            return inicio.AddMonths(meses);
        }
     }
}

