using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Core
{
    public class CustomerReview
    {
        public float Label { get; set; }  // Müşteri memnuniyeti puanı (etiket)
        public string ReviewText { get; set; }  // Müşteri inceleme metni
    }
}
