using CustomerSatisfaction.Core;
using Microsoft.ML.Data;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Services
{
    public class ModelEvaluationService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;

        public ModelEvaluationService(MLContext mlContext, ITransformer model)
        {
            _mlContext = mlContext;
            _model = model;
        }

        public RegressionMetrics EvaluateModel(string testDataPath)
        {
            var testData = _mlContext.Data.LoadFromTextFile<CustomerReview>(testDataPath, hasHeader: true, separatorChar: ',');
            var predictions = _model.Transform(testData);
            var metrics = _mlContext.Regression.Evaluate(predictions);
            return metrics;
        }
    }

}
