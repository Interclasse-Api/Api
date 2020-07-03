using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("tb_filme")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbDiretor = new HashSet<TbDiretor>();
            TbFilmeAtor = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Required]
        [Column("nm_filme", TypeName = "varchar(100)")]
        public string NmFilme { get; set; }
        [Required]
        [Column("ds_genero", TypeName = "varchar(100)")]
        public string DsGenero { get; set; }
        [Column("nr_duracao")]
        public int? NrDuracao { get; set; }
        [Column("vl_avaliacao", TypeName = "decimal(15,2)")]
        public decimal? VlAvaliacao { get; set; }
        [Column("bt_disponivel")]
        public bool BtDisponivel { get; set; }
        [Column("dt_lancamento", TypeName = "datetime")]
        public DateTime DtLancamento { get; set; }

        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbDiretor> TbDiretor { get; set; }
        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtor { get; set; }
    }
}
