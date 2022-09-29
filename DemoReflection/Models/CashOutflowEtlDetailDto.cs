using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class CashOutflowEtlDetailDto
    {
        public double Month { get; set; }

        public double Year { get; set; }

        public Guid SupplierId { get; set; }

        public decimal InvoiceAmount { get; set; }

        public long InvoiceCount { get; set; }

        public CashOutflowDataType CashOutflowType { get; set; }

        public CashOutflowWidgetTenureType CashOutflowWidgetTenureType { get; set; }

        public string Lable { get; set; }

        public string FormattedInvoiceAmount { get; set; }

        //Just for Query --> Unmapped
        public DateTime? MaturityDate { get; set; }
    }
}
