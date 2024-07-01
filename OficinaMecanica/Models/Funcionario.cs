using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OficinaMecanica.Models
{
    [Table("FUNCIONARIO")]
    public class Funcionario
    {

        [Key]
        [Column("ID_FUNCIONARIO")]
        public int IdFuncionario { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NOME_FUNCIONARIO")]
        public string? NomeFuncionario { get; set; }

        [Required]
        [StringLength(100)]
        [Column("CPF")]
        public string? CPF { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [StringLength(100)]
        [Column("EMAIL")]
        public string? Email { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        [Column("ID_OFICINA")]
        public int IdOficina { get; set; }

        public Oficina? Oficina { get; set; }
    }
}
