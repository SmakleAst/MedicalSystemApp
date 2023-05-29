using Microsoft.ML.Data;

namespace WebApiServer.InputModels
{
    internal class HepatitisModelInput
    {
        [ColumnName(@"column1")]
        public float Column1 { get; set; }

        [ColumnName(@"Category")]
        public string Category { get; set; }

        [ColumnName(@"Age")]
        public float Age { get; set; }

        [ColumnName(@"Sex")]
        public string Sex { get; set; }

        [ColumnName(@"ALB")]
        public float ALB { get; set; }

        [ColumnName(@"ALP")]
        public float ALP { get; set; }

        [ColumnName(@"ALT")]
        public float ALT { get; set; }

        [ColumnName(@"AST")]
        public float AST { get; set; }

        [ColumnName(@"BIL")]
        public float BIL { get; set; }

        [ColumnName(@"CHE")]
        public float CHE { get; set; }

        [ColumnName(@"CHOL")]
        public float CHOL { get; set; }

        [ColumnName(@"CREA")]
        public float CREA { get; set; }

        [ColumnName(@"GGT")]
        public float GGT { get; set; }

        [ColumnName(@"PROT")]
        public float PROT { get; set; }
    }
}
