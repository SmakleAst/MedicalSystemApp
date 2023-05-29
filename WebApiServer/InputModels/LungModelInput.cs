using Microsoft.ML.Data;

namespace WebApiServer.InputModels
{
    internal class LungModelInput
    {
        [ColumnName(@"Label")]
        public string Label { get; set; }

        [ColumnName(@"ImageSource")]
        public byte[] ImageSource { get; set; }
    }
}
