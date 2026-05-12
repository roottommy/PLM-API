using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.SPCAn
{
    [Table("cs1data_picture")]
    public class Cs1dataPicture
    {
        [Key]
        [Column("pdid")]
        public string Pdid { get; set; } = string.Empty;

        [Column("sn")]
        public string Sn { get; set; } = string.Empty;

        [Column("path")]
        public string Path { get; set; } = string.Empty;

        [Column("path2")]
        public string Path2 { get; set; } = string.Empty;

        [Column("path3")]
        public string Path3 { get; set; } = string.Empty;


    }
}
