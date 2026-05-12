using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.ERP
{
    /// <summary>
    /// 
    /// </summary>
    public class INVTM : TableMeta
    {
        [Column("TM001")]
        /// <remarks>nchar(40) 品號</remarks>
        public string? TM001 { get; set; }

        [Column("TM002")]
        /// <remarks>nchar(4) 變更版次</remarks>
        public string? TM002 { get; set; }

        [Column("TM003")]
        /// <remarks>nchar(4) 序號</remarks>
        public string? TM003 { get; set; }

        [Column("TM004")]
        /// <remarks>nvarchar(15) 欄位編號</remarks>
        public string? TM004 { get; set; }

        [Column("TM005")]
        /// <remarks>nvarchar(40) 欄位名稱</remarks>
        public string? TM005 { get; set; }

        [Column("TM006")]
        /// <remarks>nvarchar(255) 新文字型欄位值</remarks>
        public string? TM006 { get; set; }

        [Column("TM007")]
        /// <remarks>nvarchar(255) 原文字型欄位值</remarks>
        public string? TM007 { get; set; }

        [Column("TM008")]
        /// <remarks>numeric(21, 6) 新數值欄位值</remarks>
        public decimal? TM008 { get; set; }

        [Column("TM009")]
        /// <remarks>numeric(21, 6) 原數值欄位值</remarks>
        public decimal? TM009 { get; set; }

        [Column("TM010")]
        /// <remarks>nvarchar(1) 欄位型態</remarks>
        public string? TM010 { get; set; }

        [Column("TM011")]
        /// <remarks>nvarchar(20) 保留欄位</remarks>
        public string? TM011 { get; set; }
        
        [Column("TM012")]
        /// <remarks>nvarchar(255) 備註</remarks>
        public string? TM012 { get; set; }

        [Column("TM013")]
        /// <remarks>nvarchar(1) 確認碼</remarks>
        public string? TM013 { get; set; }

        [Column("TM014")]
        /// <remarks>nvarchar(255) 新值名稱</remarks>
        public string? TM014 { get; set; }

        [Column("TM015")]
        /// <remarks>nvarchar(255) 原值名稱</remarks>
        public string? TM015 { get; set; }

        [Column("TM016")]
        /// <remarks>numeric(21, 6) 預留欄位</remarks>
        public decimal? TM016 { get; set; }

        [Column("TM017")]
        /// <remarks>numeric(15, 6) 預留欄位</remarks>
        public decimal? TM017 { get; set; }

        [Column("TM018")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? TM018 { get; set; }

        [Column("TM019")]
        /// <remarks>nvarchar(30) 預留欄位</remarks>
        public string? TM019 { get; set; }

        [Column("TM020")]
        /// <remarks>nvarchar(60) 預留欄位</remarks>
        public string? TM020 { get; set; }

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
        /// <remarks>numeric(21, 6)</remarks>
        public decimal? UDF06 { get; set; }

        [Column("UDF07")]
        /// <remarks>numeric(21, 6)</remarks>
        public decimal? UDF07 { get; set; }

        [Column("UDF08")]
        /// <remarks>numeric(21, 6)</remarks>
        public decimal? UDF08 { get; set; }

        [Column("UDF09")]
        /// <remarks>numeric(21, 6)</remarks>
        public decimal? UDF09 { get; set; }

        [Column("UDF10")]
        /// <remarks>numeric(21, 6)</remarks>
        public decimal? UDF10 { get; set; }
    }
}
