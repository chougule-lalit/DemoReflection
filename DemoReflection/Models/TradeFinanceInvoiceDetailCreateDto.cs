using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class TradeFinanceInvoiceDetailCreateDto
    {
        public Guid TradeFinanceBatchId { get; set; }

        public Guid InvoiceId { get; set; }

        public DateTime MaturityDate { get; set; }

        public DateTime DiscountDate { get; set; }

        public decimal InterestRate { get; set; }

        public decimal TotalInterestAmount { get; set; }

        public string BenchMark { get; set; }

        public decimal MarginRate { get; set; }

        public int Tenor { get; set; }

        public string PaymentReference { get; set; }

        public string DiscountReference { get; set; }

        public string ReferenceField1 { get; set; }

        public string ReferenceField2 { get; set; }

        public string ReferenceField3 { get; set; }

        public string ReferenceField4 { get; set; }

        public string ReferenceField5 { get; set; }

        public string ReferenceField6 { get; set; }

        public int StatusId { get; set; }

    }
}
