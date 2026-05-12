using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.ERP
{
    /// <summary>
    /// 
    /// </summary>
    public class CMSMC : TableMeta
    {
        [Column("MC001")]
        /// <remarks>nchar(10) 庫別代號</remarks>
        public string MC001 { get; set; }

        [Column("MC002")]
        /// <remarks>nvarchar(40) 庫別名稱</remarks>
        public string? MC002 { get; set; }

        [Column("MC003")]
        /// <remarks>nvarchar(6) 廠別代號</remarks>
        public string? MC003 { get; set; }

        [Column("MC004")]
        /// <remarks>nvarchar(1) 庫別性質</remarks>
        public string? MC004 { get; set; }

        [Column("MC005")]
        /// <remarks>nvarchar(1) 納入MRP計算</remarks>
        public string? MC005 { get; set; }

        [Column("MC006")]
        /// <remarks>nvarchar(1) 確認時庫存量不足准許出庫</remarks>
        public string? MC006 { get; set; }

        [Column("MC007")]
        /// <remarks>nvarchar(255) 備註</remarks>
        public string? MC007 { get; set; }

        [Column("MC008")]
        /// <remarks>nvarchar(1) 存檔時庫存量不足准許出庫</remarks>
        public string? MC008 { get; set; }

        [Column("MC009")]
        /// <remarks>nvarchar(1) 儲位管理</remarks>
        public string? MC009 { get; set; }

        [Column("MC010")]
        /// <remarks>numeric(21,6) 預留欄位</remarks>
        public decimal? MC010 { get; set; }

        [Column("MC011")]
        /// <remarks>numeric(15,6) 預留欄位</remarks>
        public decimal? MC011 { get; set; }

        [Column("MC012")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MC012 { get; set; }

        [Column("MC013")]
        /// <remarks>nvarchar(30) 預留欄位</remarks>
        public string? MC013 { get; set; }

        [Column("MC014")]
        /// <remarks>nvarchar(60) 預留欄位</remarks>
        public string? MC014 { get; set; }

        [Column("UDF01")]
        /// <remarks>nvarchar(255) 託外轉撥倉</remarks>
        public string? UDF01 { get; set; }

        [Column("UDF02")]
        /// <remarks>nvarchar(255) 預設完檢站</remarks>
        public string? UDF02 { get; set; }

        [Column("UDF03")]
        /// <remarks>nvarchar(255) 現場餘料倉</remarks>
        public string? UDF03 { get; set; }

        [Column("UDF04")]
        /// <remarks>nvarchar(255) 託外餘料倉</remarks>
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

        [Column("MC200")]
        /// <remarks>numeric(3,0) 提前備料天數</remarks>
        public decimal? MC200 { get; set; }

        [Column("MC201")]
        /// <remarks>nvarchar(10) 預設領料庫別</remarks>
        public string? MC201 { get; set; }

        [Column("MC4A0")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MC4A0 { get; set; }

        [Column("MC015")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MC015 { get; set; }

        [Column("MC016")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MC016 { get; set; }

        [Column("MC017")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MC017 { get; set; }

        [Column("MC018")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MC018 { get; set; }

        [Column("MC019")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? MC019 { get; set; }
    }
}
