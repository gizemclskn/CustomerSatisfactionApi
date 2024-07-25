using CustomerSatisfaction.Core;
using CustomerSatisfaction.MLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Services
{
    public class CustomerReviewService : IDataService
    {
        
            private readonly CustomerSatisfactionModel _model;
            private readonly string _dataPath = "C:\\Users\\gizem\\source\\repos\\CustomerSatisfactionApi\\CustomerSatisfaction.Core\\bin\\Debug\\net6.0\\Reviews.csv";

            // Constructor ile ML modelini yükle
            public CustomerReviewService(CustomerSatisfactionModel model)
            {
                _model = model;
            }

            public async Task<CustomerReview[]> LoadCustomerReviewsAsync()
            {
                // Veri kaynağından müşteri yorumlarını yükleyin
                var reviews = File.ReadAllLines(_dataPath)
                    .Skip(1) // Başlık satırını atla
                    .Select(line => line.Split(','))
                    .Select(parts => new CustomerReview
                    {
                        Label = float.Parse(parts[0]), // Hedef değişken
                        ReviewText = parts[1] // Yorum metni
                    })
                    .ToArray();

                return await Task.FromResult(reviews);
            }

            public float PredictSatisfaction(string reviewText)
            {
                // Tahmini hesapla ve döndür
                return _model.Predict(reviewText);
            }
        }
    }


