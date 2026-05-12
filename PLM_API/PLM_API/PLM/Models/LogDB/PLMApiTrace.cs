using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLM_API.PLM.Models.LogDB
{
    [Table("PLMApiTrace")]
    public class PLMApiTrace
    {
        [Key]
        [Column("LogID")]
        public long? LogID { get; set; } = null;

        [Column("TraceID")]
        public string TraceID { get; set; } = string.Empty;

        [Column("MethodName")]
        public string MethodName { get; set; } = string.Empty;

        [Column("StepName")]
        public string StepName { get; set; } = string.Empty;

        [Column("Status")]
        public string Status { get; set; } = string.Empty;

        [Column("InputData")]
        public string InputData { get; set; } = string.Empty;

        [Column("OutputData")]
        public string OutputData { get; set; } = string.Empty;

        [Column("Message")]
        public string Message { get; set; } = string.Empty;

        [Column("ExecutionMs")]
        public int? ExecutionMs { get; set; } = null;

        [Column("CreatedAt")]
        public DateTime? CreatedAt { get; set; } = null;
    }
}
