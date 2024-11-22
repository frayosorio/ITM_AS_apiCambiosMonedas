using apiCambiosMoneda.Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;


namespace apiCambiosMoneda.Dominio.Entidades
{
    [Table("CambioMoneda")]
    public class CambioMoneda
    {
        [Column("IdMoneda")]
        public int IdMoneda { get; set; }
        public Moneda? Moneda { get; set; }
        [Column("Fecha")]
        public DateTime Fecha { get; set; }
        [Column("Cambio")]
        public double Cambio { get; set; }
    }
}
