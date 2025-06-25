namespace Final.Entidades
{
    public class EntTrabajador
    {
        public int? Id_trabajador { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public int? Edad { get; set; }
        public string? Sexo { get; set; }
        public string? Estado_Civil { get; set; }
        public string? Escolaridad { get; set; }
        public int? Id_empresa { get; set; }
        public decimal? PorcentajeValoracion { get; set; }
        public string? ResultadoValoracion { get; set; }

    }
}
