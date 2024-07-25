using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Core
{
    public interface ICustomerReviewRepository
    {
        Task AddReviewAsync(CustomerReview review);
        Task<IEnumerable<CustomerReview>> GetReviewsAsync();
        Task<CustomerReview> GetReviewByIdAsync(int id);
    }
}
