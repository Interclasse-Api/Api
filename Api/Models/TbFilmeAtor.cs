using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("tb_filme_ator")]
    public partial class TbFilmeAtor
    {
        [Key]
        [Column("id_filme_ator")]
        public int IdFilmeAtor { get; set; }
        [Required]
        [Column("nm_personagem", TypeName = "varchar(100)")]
        public string NmPersonagem { get; set; }
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("id_ator")]
        public int IdAtor { get; set; }

        [ForeignKey(nameof(IdAtor))]
        [InverseProperty(nameof(TbAtor.TbFilmeAtor))]
        public virtual TbAtor IdAtorNavigation { get; set; }
        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbFilmeAtor))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
