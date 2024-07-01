using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaMecanica.Models
{
    [Table("OFICINA")]
    public class Oficina
    {
        [Key]
        [Column("ID_OFICINA")]
        public int IdOficina { get; set; }

        [Required]
        [StringLength(200)]
        [Column("NOME_OFICINA")]
        public string? NomeOficina { get; set; }

        [Required]
        [StringLength(20)]
        [Column("CNPJ")]
        public string Cnpj { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [Column("DATA_ENTRADA")]
        public DateTime DataEntrada { get; set; }

        public ICollection<Funcionario>? Funcionarios { get; set; }
    }
}
