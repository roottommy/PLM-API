using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.ERP
{
    public class TableMeta
    {
        [Column("COMPANY")]
        /// <remarks>nchar(20) 公司別</remarks>       
        public string COMPANY { get; set; }

        [Column("CREATOR")]
        /// <remarks>nchar(10) 建立者</remarks>
        public string CREATOR { get; set; }

        [Column("USR_GROUP")]
        /// <remarks>nchar(10) 使用者群組</remarks>
        public string USR_GROUP { get; set; }

        [Column("CREATE_DATE")]
        /// <remarks>nchar(8) 建立日期</remarks>
        public string CREATE_DATE { get; set; }

        [Column("MODIFIER")]
        /// <remarks>nchar(10) 修改者</remarks>
        public string? MODIFIER { get; set; }

        [Column("MODI_DATE")]
        /// <remarks>nchar(8) 修改日期</remarks>
        public string? MODI_DATE { get; set; }

        [Column("FLAG")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal FLAG { get; set; }
    }
}
