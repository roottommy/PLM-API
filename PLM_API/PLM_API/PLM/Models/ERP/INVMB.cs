using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.ERP
{
    [Table("INVMB")]
    /// <summary>
    /// 品號基本資料
    /// </summary>
    public class INVMB : TableMeta
    {
        [Column("MB001")]
        /// <remarks>nchar(40)</remarks>
        public string? MB001 { get; set; }

        [Column("MB002")]
        /// <remarks>nvarchar(120)</remarks>
        public string? MB002 { get; set; }

        [Column("MB003")]
        /// <remarks>nvarchar(120)</remarks>
        public string? MB003 { get; set; }

        [Column("MB004")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB004 { get; set; }

        [Column("MB005")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB005 { get; set; }

        [Column("MB006")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB006 { get; set; }

        [Column("MB007")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB007 { get; set; }

        [Column("MB008")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB008 { get; set; }

        [Column("MB009")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB009 { get; set; }

        [Column("MB010")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB010 { get; set; }

        [Column("MB011")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB011 { get; set; }

        [Column("MB012")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB012 { get; set; }

        [Column("MB013")]
        /// <remarks>nvarchar(20)</remarks>
        public string? MB013 { get; set; }

        [Column("MB014")]
        /// <remarks>numeric(16,6)</remarks>
        public decimal? MB014 { get; set; }

        [Column("MB015")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB015 { get; set; }

        [Column("MB016")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB016 { get; set; }

        [Column("MB017")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB017 { get; set; }

        [Column("MB018")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB018 { get; set; }

        [Column("MB019")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB019 { get; set; }

        [Column("MB020")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB020 { get; set; }

        [Column("MB021")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB021 { get; set; }

        [Column("MB022")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB022 { get; set; }

        [Column("MB023")]
        /// <remarks>numeric(4,0)</remarks>
        public decimal? MB023 { get; set; }

        [Column("MB024")]
        /// <remarks>numeric(4,0)</remarks>
        public decimal? MB024 { get; set; }

        [Column("MB025")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB025 { get; set; }

        [Column("MB026")]
        /// <remarks>nvarchar(2)</remarks>
        public string? MB026 { get; set; }

        [Column("MB027")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB027 { get; set; }

        [Column("MB028")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB028 { get; set; }

        [Column("MB029")]
        /// <remarks>nvarchar(20)</remarks>
        public string? MB029 { get; set; }

        [Column("MB030")]
        /// <remarks>nvarchar(8)</remarks>
        public string? MB030 { get; set; }

        [Column("MB031")]
        /// <remarks>nvarchar(8)</remarks>
        public string? MB031 { get; set; }

        [Column("MB032")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB032 { get; set; }

        [Column("MB033")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB033 { get; set; }

        [Column("MB034")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB034 { get; set; }

        [Column("MB035")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB035 { get; set; }

        [Column("MB036")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB036 { get; set; }

        [Column("MB037")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB037 { get; set; }

        [Column("MB038")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB038 { get; set; }

        [Column("MB039")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB039 { get; set; }

        [Column("MB040")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB040 { get; set; }

        [Column("MB041")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB041 { get; set; }

        [Column("MB042")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB042 { get; set; }

        [Column("MB043")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB043 { get; set; }

        [Column("MB044")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB044 { get; set; }

        [Column("MB045")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB045 { get; set; }

        [Column("MB046")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB046 { get; set; }

        [Column("MB047")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB047 { get; set; }

        [Column("MB048")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB048 { get; set; }

        [Column("MB049")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB049 { get; set; }

        [Column("MB050")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB050 { get; set; }

        [Column("MB051")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB051 { get; set; }

        [Column("MB052")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB052 { get; set; }

        [Column("MB053")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB053 { get; set; }

        [Column("MB054")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB054 { get; set; }

        [Column("MB055")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB055 { get; set; }

        [Column("MB056")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB056 { get; set; }

        [Column("MB057")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB057 { get; set; }

        [Column("MB058")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB058 { get; set; }

        [Column("MB059")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB059 { get; set; }

        [Column("MB060")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB060 { get; set; }

        [Column("MB061")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB061 { get; set; }

        [Column("MB062")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB062 { get; set; }

        [Column("MB063")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB063 { get; set; }

        [Column("MB064")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB064 { get; set; }

        [Column("MB065")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB065 { get; set; }

        [Column("MB066")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB066 { get; set; }

        [Column("MB067")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB067 { get; set; }

        [Column("MB068")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB068 { get; set; }

        [Column("MB069")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB069 { get; set; }

        [Column("MB070")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB070 { get; set; }

        [Column("MB071")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB071 { get; set; }

        [Column("MB072")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB072 { get; set; }

        [Column("MB073")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB073 { get; set; }

        [Column("MB074")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB074 { get; set; }

        [Column("MB075")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB075 { get; set; }

        [Column("MB076")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB076 { get; set; }

        [Column("MB077")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB077 { get; set; }

        [Column("MB078")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB078 { get; set; }

        [Column("MB079")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB079 { get; set; }

        [Column("MB080")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB080 { get; set; }

        [Column("MB081")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB081 { get; set; }

        [Column("MB082")]
        /// <remarks>numeric(9,6)</remarks>
        public decimal? MB082 { get; set; }

        [Column("MB083")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB083 { get; set; }

        [Column("MB084")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB084 { get; set; }

        [Column("MB085")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB085 { get; set; }

        [Column("MB086")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB086 { get; set; }

        [Column("MB087")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB087 { get; set; }

        [Column("MB088")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB088 { get; set; }

        [Column("MB089")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB089 { get; set; }

        [Column("MB090")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB090 { get; set; }

        [Column("MB091")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB091 { get; set; }

        [Column("MB092")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB092 { get; set; }

        [Column("MB093")]
        /// <remarks>numeric(6,1)</remarks>
        public decimal? MB093 { get; set; }

        [Column("MB094")]
        /// <remarks>numeric(6,1)</remarks>
        public decimal? MB094 { get; set; }

        [Column("MB095")]
        /// <remarks>numeric(6,1)</remarks>
        public decimal? MB095 { get; set; }

        [Column("MB096")]
        /// <remarks>numeric(7,4)</remarks>
        public decimal? MB096 { get; set; }

        [Column("MB097")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB097 { get; set; }

        [Column("MB098")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB098 { get; set; }

        [Column("MB099")]
        /// <remarks>numeric(7,6)</remarks>
        public decimal? MB099 { get; set; }

        [Column("MB100")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB100 { get; set; }

        [Column("MB101")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB101 { get; set; }

        [Column("MB102")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB102 { get; set; }

        [Column("MB103")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB103 { get; set; }

        [Column("MB104")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB104 { get; set; }

        [Column("MB105")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB105 { get; set; }

        [Column("MB106")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB106 { get; set; }

        [Column("MB107")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB107 { get; set; }

        [Column("MB108")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB108 { get; set; }

        [Column("MB109")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB109 { get; set; }

        [Column("MB110")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB110 { get; set; }

        [Column("MB111")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB111 { get; set; }

        [Column("MB112")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB112 { get; set; }

        [Column("MB113")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB113 { get; set; }

        [Column("MB114")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB114 { get; set; }

        [Column("MB115")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB115 { get; set; }

        [Column("MB116")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB116 { get; set; }

        [Column("MB117")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB117 { get; set; }

        [Column("MB118")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB118 { get; set; }

        [Column("MB119")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB119 { get; set; }

        [Column("MB120")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB120 { get; set; }

        [Column("MB121")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB121 { get; set; }

        [Column("MB122")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB122 { get; set; }

        [Column("MB123")]
        /// <remarks>nvarchar(2)</remarks>
        public string? MB123 { get; set; }

        [Column("MB124")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB124 { get; set; }

        [Column("MB125")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB125 { get; set; }

        [Column("MB126")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB126 { get; set; }

        [Column("MB127")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB127 { get; set; }

        [Column("MB128")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB128 { get; set; }

        [Column("MB129")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB129 { get; set; }

        [Column("MB130")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB130 { get; set; }

        [Column("MB131")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB131 { get; set; }

        [Column("MB132")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB132 { get; set; }

        [Column("MB133")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB133 { get; set; }

        [Column("MB134")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB134 { get; set; }

        [Column("MB135")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB135 { get; set; }

        [Column("MB136")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB136 { get; set; }

        [Column("MB137")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB137 { get; set; }

        [Column("MB138")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB138 { get; set; }

        [Column("MB139")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB139 { get; set; }

        [Column("MB140")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB140 { get; set; }

        [Column("MB141")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB141 { get; set; }

        [Column("MB142")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB142 { get; set; }

        [Column("MB143")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB143 { get; set; }

        [Column("MB144")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB144 { get; set; }

        [Column("MB145")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB145 { get; set; }

        [Column("MB146")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB146 { get; set; }

        [Column("MB147")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB147 { get; set; }

        [Column("MB148")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB148 { get; set; }

        [Column("MB149")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB149 { get; set; }

        [Column("MB150")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB150 { get; set; }

        [Column("MB151")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB151 { get; set; }

        [Column("MB152")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB152 { get; set; }

        [Column("MB153")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB153 { get; set; }

        [Column("MB154")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB154 { get; set; }

        [Column("MB155")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB155 { get; set; }

        [Column("MB156")]
        /// <remarks>nvarchar(6)</remarks>
        public string? MB156 { get; set; }

        [Column("MB157")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB157 { get; set; }

        [Column("MB158")]
        /// <remarks>nvarchar(8)</remarks>
        public string? MB158 { get; set; }

        [Column("MB159")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB159 { get; set; }

        [Column("MB160")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB160 { get; set; }

        [Column("MB161")]
        /// <remarks>numeric(15,6)</remarks>
        public decimal? MB161 { get; set; }

        [Column("MB162")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB162 { get; set; }

        [Column("MB163")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB163 { get; set; }

        [Column("MB164")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB164 { get; set; }

        [Column("MB165")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB165 { get; set; }
        
        [Column("MB166")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB166 { get; set; }

        [Column("MB167")]
        /// <remarks>numeric(21,6)</remarks>
        public decimal? MB167 { get; set; }

        [Column("MB168")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB168 { get; set; }

        
        [Column("MB169")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB169 { get; set; }

        [Column("MB170")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB170 { get; set; }

        [Column("MB171")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB171 { get; set; }

        [Column("MB172")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB172 { get; set; }

        [Column("MB173")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB173 { get; set; }

        [Column("MB174")]
        /// <remarks>nvarchar(32)</remarks>
        public string? MB174 { get; set; }

        [Column("MB175")]
        /// <remarks>nvarchar(32)</remarks>
        public string? MB175 { get; set; }

        [Column("MB176")]
        /// <remarks>nvarchar(32)</remarks>
        public string? MB176 { get; set; }

        [Column("MB177")]
        /// <remarks>nvarchar(32)</remarks>
        public string? MB177 { get; set; }

        [Column("MB178")]
        /// <remarks>nvarchar(32)</remarks>
        public string? MB178 { get; set; }

        [Column("MB179")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB179 { get; set; }

        [Column("MB180")]
        /// <remarks>numeric(8,0)</remarks>
        public decimal? MB180 { get; set; }

        [Column("MB181")]
        /// <remarks>numeric(8,0)</remarks>
        public decimal? MB181 { get; set; }

        [Column("MB182")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB182 { get; set; }
        
        [Column("MB183")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB183 { get; set; }
        
        [Column("MB184")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB184 { get; set; }

        [Column("MB185")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB185 { get; set; }

        [Column("MB186")]
        /// <remarks>nvarchar(20)</remarks>
        public string? MB186 { get; set; }

        [Column("MB187")]
        /// <remarks>nvarchar(15)</remarks>
        public string? MB187 { get; set; }

        
        [Column("MB188")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB188 { get; set; }

        [Column("MB189")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB189 { get; set; }

        [Column("MB190")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB190 { get; set; }

        [Column("MB191")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB191 { get; set; }

        [Column("MB192")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB192 { get; set; }

        [Column("MB193")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB193 { get; set; }

        [Column("MB195")]
        /// <remarks>nvarchar(8)</remarks>
        public string? MB195 { get; set; }
        
        [Column("MB196")]
        /// <remarks>nvarchar(10)</remarks>
        public string? MB196 { get; set; }

        [Column("MB198")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB198 { get; set; }

        [Column("MB199")]
        /// <remarks>nvarchar(20)</remarks>
        public string? MB199 { get; set; }

        [Column("MB200")]
        /// <remarks>numeric(9,3)</remarks>
        public decimal? MB200 { get; set; }

        [Column("MB201")]
        /// <remarks>numeric(2,0)</remarks>
        public decimal? MB201 { get; set; }

        [Column("MB202")]
        /// <remarks>numeric(6,3)</remarks>
        public decimal? MB202 { get; set; }

        [Column("MB203")]
        /// <remarks>numeric(15,3)</remarks>
        public decimal? MB203 { get; set; }

        [Column("MB204")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB204 { get; set; }

        [Column("MB205")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB205 { get; set; }
        
        [Column("MB206")]
        /// <remarks>nvarchar(2)</remarks>
        public string? MB206 { get; set; }

        [Column("MB207")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB207 { get; set; }

        [Column("MB208")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB208 { get; set; }

        [Column("MB209")]
        /// <remarks>numeric(3,0)</remarks>
        public decimal? MB209 { get; set; }

        [Column("MB210")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB210 { get; set; }

        [Column("MB211")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB211 { get; set; }

        [Column("MB212")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB212 { get; set; }

        [Column("MB509")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB509 { get; set; }

        [Column("MB510")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB510 { get; set; }

        [Column("MB511")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB511 { get; set; }

        [Column("MB512")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB512 { get; set; }

        [Column("MB513")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB513 { get; set; }

        [Column("MB514")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB514 { get; set; }

        [Column("MB515")]
        /// <remarks>nvarchar(20)</remarks>
        public string? MB515 { get; set; }

        [Column("MB516")]
        /// <remarks>nvarchar(8)</remarks>
        public string? MB516 { get; set; }

        [Column("MB517")]
        /// <remarks>nvarchar(15)</remarks>
        public string? MB517 { get; set; }

        [Column("MB518")]
        /// <remarks>nvarchar(15)</remarks>
        public string? MB518 { get; set; }

        [Column("MB519")]
        /// <remarks>nvarchar(15)</remarks>
        public string? MB519 { get; set; }

        [Column("MB520")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB520 { get; set; }

        [Column("MB521")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB521 { get; set; }

        [Column("MB522")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB522 { get; set; }

        [Column("MB500")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB500 { get; set; }

        [Column("MB501")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB501 { get; set; }

        [Column("MB502")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB502 { get; set; }

        [Column("MB503")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB503 { get; set; }

        [Column("MB504")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB504 { get; set; }

        [Column("MB545")]
        /// <remarks>numeric(8,5)</remarks>
        public decimal? MB545 { get; set; }

        [Column("MB546")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB546 { get; set; }

        [Column("MB547")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB547 { get; set; }

        [Column("MB548")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB548 { get; set; }

        [Column("MB549")]
        /// <remarks>nvarchar(30)</remarks>
        public string? MB549 { get; set; }

        [Column("MB550")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB550 { get; set; }

        [Column("MB551")]
        /// <remarks>nvarchar(20)</remarks>
        public string? MB551 { get; set; }

        [Column("MB552")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB552 { get; set; }

        [Column("MB553")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB553 { get; set; }

        [Column("MB554")]
        /// <remarks>nvarchar(4)</remarks>
        public string? MB554 { get; set; }

        [Column("MB555")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB555 { get; set; }

        [Column("MB556")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB556 { get; set; }

        [Column("MB557")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB557 { get; set; }

        [Column("MB558")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB558 { get; set; }

        [Column("MB559")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB559 { get; set; }

        [Column("MB560")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB560 { get; set; }

        [Column("MB561")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB561 { get; set; }

        [Column("MB562")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB562 { get; set; }

        [Column("MB563")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB563 { get; set; }

        [Column("MB564")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB564 { get; set; }

        [Column("MB565")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB565 { get; set; }

        [Column("MB566")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB566 { get; set; }

        [Column("MB567")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB567 { get; set; }

        [Column("MB568")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB568 { get; set; }

        [Column("MB569")]
        /// <remarks>nvarchar(255)</remarks>
        public string? MB569 { get; set; }

        [Column("MB570")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB570 { get; set; }

        [Column("MB571")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB571 { get; set; }

        [Column("MB572")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB572 { get; set; }

        [Column("MB573")]
        /// <remarks>nvarchar(40)</remarks>
        public string? MB573 { get; set; }

        [Column("MB574")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB574 { get; set; }

        [Column("MB575")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB575 { get; set; }

        [Column("MB576")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB576 { get; set; }

        [Column("MB577")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB577 { get; set; }

        [Column("MB578")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB578 { get; set; }

        [Column("MB579")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB579 { get; set; }

        [Column("MB580")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB580 { get; set; }

        [Column("MB581")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB581 { get; set; }

        [Column("MB582")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB582 { get; set; }

        [Column("MB583")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB583 { get; set; }

        [Column("MB584")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB584 { get; set; }

        [Column("MB585")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB585 { get; set; }

        [Column("MB586")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB586 { get; set; }

        [Column("MB587")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB587 { get; set; }

        [Column("MB588")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB588 { get; set; }

        [Column("MB589")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB589 { get; set; }

        [Column("MB590")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB590 { get; set; }

        [Column("MB591")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB591 { get; set; }

        [Column("MB592")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB592 { get; set; }

        [Column("MB593")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB593 { get; set; }

        [Column("MB594")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB594 { get; set; }

        [Column("MB595")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB595 { get; set; }

        [Column("MB596")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB596 { get; set; }

        [Column("MB597")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB597 { get; set; }

        [Column("MB598")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB598 { get; set; }
        
        [Column("MB599")]
        /// <remarks>nvarchar(60)</remarks>
        public string? MB599 { get; set; }
        
        [Column("MB900")]
        /// <remarks>nvarchar(50)</remarks>
        public string? MB900 { get; set; }
        
        [Column("MB901")]
        /// <remarks>nvarchar(50)</remarks>
        public string? MB901 { get; set; }

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

        [Column("OldAccount")]
        /// <remarks>nvarchar(6)</remarks>
        public string? OldAccount { get; set; }

        [Column("OldProduct")]
        /// <remarks>nvarchar(6)</remarks>
        public string? OldProduct { get; set; }

        [Column("MB4A0")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB4A0 { get; set; }

        [Column("MB4A1")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB4A1 { get; set; }

        [Column("MB4A2")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB4A2 { get; set; }

        [Column("MB4A3")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB4A3 { get; set; }

        [Column("MB4A4")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB4A4 { get; set; }

        [Column("MB4A5")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB4A5 { get; set; }

        [Column("MB4A6")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB4A6 { get; set; }

        [Column("MB4A7")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB4A7 { get; set; }

        [Column("MB4A8")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB4A8 { get; set; }

        [Column("MB4A9")]
        /// <remarks>numeric(16,3)</remarks>
        public decimal? MB4A9 { get; set; }

        [Column("MB4B0")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB4B0 { get; set; }

        [Column("MB4B1")]
        /// <remarks>nvarchar(1)</remarks>
        public string? MB4B1 { get; set; }
    }
}
