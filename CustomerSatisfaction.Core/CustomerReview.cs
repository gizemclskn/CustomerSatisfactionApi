using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSatisfaction.Core
{
    public class CustomerReview
    {
        [LoadColumn(0)]
        public float Label { get; set; } // Hedef değişken (etiket)

        [LoadColumn(1)]
        public string ReviewText { get; set; } // Yorum metni
    }
}
