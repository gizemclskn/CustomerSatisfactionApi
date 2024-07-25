using CustomerSatisfaction.MLModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Services
{
    public class CustomerSatisfactionService
    {
        private readonly CustomerSatisfactionModel _model;

        public CustomerSatisfactionService()
        {
            _model = new CustomerSatisfactionModel();
        }

        public float PredictCustomerSatisfaction(string reviewText)
        {
            if (string.IsNullOrEmpty(reviewText))
            {
                throw new ArgumentException("Review text cannot be null or empty", nameof(reviewText));
            }

            return _model.Predict(reviewText);
        }
    }
}
