using Microsoft.ML.Data;

namespace CustomerSatisfaction.Core
{
    public class CustomerSatisfactionPrediction
    {
        [ColumnName("Score")]
        public float Score { get; set; }
    }
}
