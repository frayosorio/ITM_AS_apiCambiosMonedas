using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiCambiosMoneda.Dominio.Entidades
{
    [Table("Moneda")]
    public class Moneda
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Moneda"), StringLength(100)]
        public String Nombre { get; set; }

        [Column("Sigla"), StringLength(5)]
        public String Sigla { get; set; }

        [Column("Emisor"), StringLength(100)]
        public String? Emisor { get; set; }

        [Column("Simbolo"), StringLength(5)]
        public String? Simbolo { get; set; }


    }
}
