using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCambiosMoneda.Dominio.Entidades
{
    [Table("Pais")]
    public class Pais
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Pais"), StringLength(50)]
        public string Nombre { get; set; }
        [Column("CodigoAlfa2"), StringLength(5)]
        public string CodigoAlfa2 { get; set; }
        [Column("CodigoAlfa3"), StringLength(5)]
        public string CodigoAlfa3 { get; set; }
        [Column("IdMoneda")]
        public int IdMoneda { get; set; }
        public Moneda? Moneda { get; set; }
    }
}
