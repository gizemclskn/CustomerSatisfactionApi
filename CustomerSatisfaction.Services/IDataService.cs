using CustomerSatisfaction.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Services
{
    public interface IDataService
    {
        Task<CustomerReview[]> LoadCustomerReviewsAsync();
    }
}
