using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class BankLimitProjectionSettlementDetailEtlDto
    {
        public double Month { get; set; }

        public double Year { get; set; }

        public Guid FinancingBankBranchId { get; set; }

        public decimal InvoiceAmount { get; set; }

        public long InvoiceCount { get; set; }

        public BankLimitProjectionType BankLimitProjectionType { get; set; }

        public string Lable { get; set; }

        public string FormattedInvoiceAmount { get; set; }

        //Just for quering
        public DateTime? TradeFinanceResponseBatchDate { get; set; }
    }
}
