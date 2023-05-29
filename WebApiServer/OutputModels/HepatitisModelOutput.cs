using Microsoft.ML.Data;

namespace WebApiServer.OutputModels
{
    internal class HepatitisModelOutput
    {
        [ColumnName(@"column1")]
        public float Column1 { get; set; }

        [ColumnName(@"Category")]
        public uint Category { get; set; }

        [ColumnName(@"Age")]
        public float Age { get; set; }

        [ColumnName(@"Sex")]
        public float[] Sex { get; set; }

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

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"PredictedLabel")]
        public string PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }
    }
}
