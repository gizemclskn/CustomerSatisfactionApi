using CustomerSatisfaction.Core;
using CustomerSatisfaction.MLModels;
using CustomerSatisfaction.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace CustomerSatisfactionApi.Controllers
{
    [ApiController]
    [Route("Metrics")]
    public class MetricsController : ControllerBase
    {
        private readonly MLContext _mlContext;
        private readonly CustomerSatisfactionModel _model;
        private readonly string _dataPath = @"C:\Users\gizem\source\repos\CustomerSatisfactionApi\CustomerSatisfaction.Core\bin\Debug\net6.0\Reviews.csv";

        public MetricsController(MLContext mlContext, CustomerSatisfactionModel model)
        {
            _mlContext = mlContext;
            _model = model;
        }

        [HttpGet("evaluate")]
        public IActionResult Evaluate()
        {
            if (!System.IO.File.Exists(_dataPath))
            {
                return NotFound("Data file not found.");
            }

            var data = _mlContext.Data.LoadFromTextFile<CustomerReview>(_dataPath, hasHeader: true, separatorChar: ',');

            var predictions = _model.Train().Transform(data);

            var metrics = _mlContext.Regression.Evaluate(predictions);

            var result = new
            {
                MeanAbsoluteError = metrics.MeanAbsoluteError,
                MeanSquaredError = metrics.MeanSquaredError,
                RootMeanSquaredError = metrics.RootMeanSquaredError,
                LossFunction = metrics.LossFunction,
                RSquared = metrics.RSquared
            };

            return Ok(result);
        }
    }
}
