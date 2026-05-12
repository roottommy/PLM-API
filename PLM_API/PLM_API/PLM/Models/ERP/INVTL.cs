using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.ERP
{
    /// <summary>
    /// 品號變更單單頭
    /// </summary>
    public class INVTL : TableMeta
    {
        [Column("TL001")]
        /// <remarks>nchar(40) 品號</remarks>
        public string? TL001 { get; set; }

        [Column("TL002")]
        /// <remarks>nvarchar(120) 原品名</remarks>
        public string? TL002 { get; set; }

        [Column("TL003")]
        /// <remarks>nvarchar(120) 原規格</remarks>
        public string? TL003 { get; set; }

        [Column("TL004")]
        /// <remarks>nchar(4) 變更版次</remarks>
        public string? TL004 { get; set; }

        [Column("TL005")]
        /// <remarks>nvarchar(8) 變更日期</remarks>
        public string? TL005 { get; set; }

        [Column("TL006")]
        /// <remarks>nvarchar(1) 刪除品號</remarks>
        public string? TL006 { get; set; }

        [Column("TL007")]
        /// <remarks>nvarchar(120) 新品名</remarks>
        public string? TL007 { get; set; }

        [Column("TL008")]
        /// <remarks>nvarchar(120) 新規格</remarks>
        public string? TL008 { get; set; }

        [Column("TL009")]
        /// <remarks>nvarchar(10) 修改者</remarks>
        public string? TL009 { get; set; }

        [Column("TL010")]
        /// <remarks>nvarchar(255) 備註</remarks>
        public string? TL010 { get; set; }

        [Column("TL011")]
        /// <remarks>nvarchar(1) 修改欄位類別</remarks>
        public string? TL011 { get; set; }

        [Column("TL012")]
        /// <remarks>nvarchar(10) 確認者</remarks>
        public string? TL012 { get; set; }

        [Column("TL013")]
        /// <remarks>nvarchar(8) 確認日期</remarks>
        public string? TL013 { get; set; }

        [Column("TL014")]
        /// <remarks>nvarchar(1) 確認碼</remarks>
        public string? TL014 { get; set; }

        [Column("TL015")]
        /// <remarks>nvarchar(1) 簽核狀態</remarks>
        public string? TL015 { get; set; }

        [Column("TL016")]
        /// <remarks>numeric(1, 0) 列印次數</remarks>
        public decimal? TL016 { get; set; }

        [Column("TL017")]
        /// <remarks>numeric(1, 0) 傳送次數</remarks>
        public decimal? TL017 { get; set; }

        [Column("TL018")]
        /// <remarks>numeric(21, 6) 預留欄位</remarks>
        public decimal? TL018 { get; set; }

        [Column("TL019")]
        /// <remarks>numeric(15, 6) 預留欄位</remarks>
        public decimal? TL019 { get; set; }

        [Column("TL020")]
        /// <remarks>nvarchar(1) 預留欄位</remarks>
        public string? TL020 { get; set; }

        [Column("TL021")]
        /// <remarks>nvarchar(30) 預留欄位</remarks>
        public string? TL021 { get; set; }

        [Column("TL022")]
        /// <remarks>nvarchar(60) 預留欄位</remarks>
        public string? TL022 { get; set; }

        [Column("TL023")]
        /// <remarks>nvarchar(4) 原版次</remarks>
        public string? TL023 { get; set; }

        [Column("UDF01")]
        /// <remarks>nvarchar(255) </remarks>
        public string? UDF01 { get; set; }

        [Column("UDF02")]
        /// <remarks>nvarchar(255) </remarks>
        public string? UDF02 { get; set; }
        
        [Column("UDF03")]
        /// <remarks>nvarchar(255) </remarks>
        public string? UDF03 { get; set; }

        [Column("UDF04")]
        /// <remarks>nvarchar(255) </remarks>
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
