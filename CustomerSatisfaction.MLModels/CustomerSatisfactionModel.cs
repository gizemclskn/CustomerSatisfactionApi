using CustomerSatisfaction.Core;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.LightGbm;


namespace CustomerSatisfaction.MLModels
{
    public class CustomerSatisfactionModel
    {

        private readonly MLContext _mlContext;
        private readonly ITransformer _model;
        private readonly string _modelPath = Path.Combine("MLModels", "CustomerSatisfactionModel.zip");
        private readonly string _dataPath = @"C:\Users\gizem\source\repos\CustomerSatisfactionApi\CustomerSatisfaction.Core\bin\Debug\net6.0\Reviews.csv";

        public CustomerSatisfactionModel()
            {
            _mlContext = new MLContext();

            // Dizin kontrolü ve oluşturma
            var modelDirectory = Path.GetDirectoryName(_modelPath);
            if (!Directory.Exists(modelDirectory))
            {
                Directory.CreateDirectory(modelDirectory);
            }

            if (File.Exists(_modelPath))
            {
                _model = _mlContext.Model.Load(_modelPath, out _);
            }
            else
            {
                _model = Train();
                _mlContext.Model.Save(_model, null, _modelPath);
            }
        }

            public ITransformer Train()
            {
                if (!File.Exists(_dataPath))
                {
                    throw new FileNotFoundException($"Data file not found: {_dataPath}");
                }

                var data = _mlContext.Data.LoadFromTextFile<CustomerReview>(_dataPath, hasHeader: true, separatorChar: ',');

                var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(CustomerReview.ReviewText))
                    .Append(_mlContext.Regression.Trainers.LightGbm(new LightGbmRegressionTrainer.Options
                    {
                        NumberOfLeaves = 50,
                        MinimumExampleCountPerLeaf = 20,
                        LearningRate = 0.01,
                        NumberOfIterations = 100
                    }));

                var model = pipeline.Fit(data);
                return model;
            }

            public float Predict(string reviewText)
            {
                var predictionEngine = _mlContext.Model.CreatePredictionEngine<CustomerReview, CustomerSatisfactionPrediction>(_model);
                var prediction = predictionEngine.Predict(new CustomerReview { ReviewText = reviewText });
                return prediction.Score;
            }
    }
  }
