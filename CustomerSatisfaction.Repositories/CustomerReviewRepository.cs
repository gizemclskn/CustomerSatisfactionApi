using CustomerSatisfaction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Repositories
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly List<CustomerReview> _reviews = new List<CustomerReview>();

        public Task AddReviewAsync(CustomerReview review)
        {
            _reviews.Add(review);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<CustomerReview>> GetReviewsAsync()
        {
            return Task.FromResult((IEnumerable<CustomerReview>)_reviews);
        }

        public Task<CustomerReview> GetReviewByIdAsync(int id)
        {
            var review = _reviews.Find(r => r.GetHashCode() == id);  //  ID'yi hash kodu olarak kullanıyoruz
            return Task.FromResult(review);
        }
    }
}
