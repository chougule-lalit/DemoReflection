using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class CashOutFlowWidgetOutputDto
    {
        public decimal FinancedInvoiceAmount { get; set; }

        public string FormatedFinancedInvoiceAmount { get; set; }

        public long FinancedInvoiceCount { get; set; }

        public decimal RejectedInvoiceAmount { get; set; }

        public decimal InvalidInvoiceAmount { get; set; }

        public string FormatedRejectedInvoiceAmount { get; set; }

        public string FormatedInvalidInvoiceAmount { get; set; }

        public long RejectedInvoiceCount { get; set; }

        public long InvalidInvoiceCount { get; set; }

        public string Lable { get; set; }

        public string Month { get; set; }

        public string Year { get; set; }

        public List<Guid> InvoiceIds { get; set; }
    }

    public class CashOutFlowWidgetDto
    {
        public List<CashOutFlowWidgetOutputDto> CashOutFlowDetails { get; set; }

        public long FinancedCount { get; set; }

        public long RejectedCount { get; set; }

        public long InvalidCount { get; set; }
    }
}
