using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.ERP
{
    public class INVMA
    {
        [Column("MA001")]
        /// <remarks>nchar(1) 分類方式</remarks>
        public string MA001 { get; set; }

        [Column("MA002")]
        /// <remarks>nchar(6) 品號類別代號</remarks>
        public string MA002 { get; set; }

        [Column("MA003")]
        /// <remarks>nvarchar(40) 品號類別名稱</remarks>
        public string? MA003 { get; set; }

        [Column("MA004")]
        /// <remarks>nvarchar(20) 存貨會計科目</remarks>
        public string? MA004 { get; set; }

        [Column("MA005")]
        /// <remarks>nvarchar(20) 銷貨收入科目</remarks>
        public string? MA005 { get; set; }

        [Column("MA006")]
        /// <remarks>nvarchar(20) 銷貨退回科目</remarks>
        public string? MA006 { get; set; }

        [Column("MA007")]
        /// <remarks>nvarchar(20) 預算會計科目</remarks>
        public string? MA007 { get; set; }

        [Column("MA008")]
        /// <remarks>numeric(21,6) 預留欄位</remarks>
        public decimal? MA008 { get; set; }

        [Column("MA009")]
        /// <remarks>numeric(15,6) 直接銷售費用率</remarks>
        public decimal? MA009 { get; set; }

        [Column("MA010")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MA010 { get; set; }

        [Column("MA011")]
        /// <remarks>nvarchar(30) 預留欄位</remarks>
        public string? MA011 { get; set; }

        [Column("MA012")]
        /// <remarks>nvarchar(60) 預留欄位</remarks>
        public string? MA012 { get; set; }

        [Column("MA013")]
        /// <remarks>numeric(8,5) 保固佔售價比率</remarks>
        public decimal? MA013 { get; set; }

        [Column("MA014")]
        /// <remarks>numeric(3,0) 保固期數(月數)</remarks>
        public decimal? MA014 { get; set; }

        [Column("MA015")]
        /// <remarks>nvarchar(20) 遞延收入會計科目</remarks>
        public string? MA015 { get; set; }

        [Column("UDF01")]
        /// <remarks>nvarchar(255)</remarks>
        public string? UDF01 { get; set; }

        [Column("UDF02")]
        /// <remarks>nvarchar(255)</remarks>
        public string? UDF02 { get; set; }

        [Column("UDF03")]
        /// <remarks>nvarchar(255)</remarks>
        public string? UDF03 { get; set; }

        [Column("UDF04")]
        /// <remarks>nvarchar(255)</remarks>
        public string? UDF04 { get; set; }

        [Column("UDF05")]
        /// <remarks>nvarchar(255)</remarks>
        public string? UDF05 { get; set; }

        [Column("UDF06")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? UDF06 { get; set; }

        [Column("UDF07")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? UDF07 { get; set; }

        [Column("UDF08")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? UDF08 { get; set; }

        [Column("UDF09")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? UDF09 { get; set; }

        [Column("UDF10")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? UDF10 { get; set; }
    }
}
