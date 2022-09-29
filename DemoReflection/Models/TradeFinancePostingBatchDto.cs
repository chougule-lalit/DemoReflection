using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class TradeFinancePostingBatchDto
    {
        public Guid SupplierId { get; set; }

        public Guid BusinessEntityId { get; set; }

        public Guid FinancingBankBranchId { get; set; }

        public int CurrencyId { get; set; }

        public string SellerOrgId { get; set; }

        public string BuyerOrgId { get; set; }

        public string ProgramId { get; set; }

        public DateTime OriginalDueDate { get; set; }

        public DateTime MaturityDate { get; set; }

        public DateTime DiscountDate { get; set; }

        public int InvoiceCount { get; set; }

        public int CreditNoteCount { get; set; }

        public decimal TotalInvoiceAmount { get; set; }

        public decimal TotalCreditNoteAmount { get; set; }

        public decimal TotalBatchAmount { get; set; }

        public decimal TotalFinanceAmount { get; set; }

        public int Tenor { get; set; }

        public int CountryId { get; set; }

        public string BenchMark { get; set; }

        public decimal MarginRate { get; set; }

        public decimal InterestRate { get; set; }

        public decimal TotalInterestAmount { get; set; }

        public decimal NetFinanceAmount { get; set; }

        public decimal ServiceChargeRate { get; set; }

        public decimal TotalServiceChargeAmount { get; set; }

        public int SupplierCollectionBankId { get; set; }

        public string TransactionReference { get; set; }

        public DateTime PostingDate { get; set; }

        public int StatusId { get; set; }

        public string FinanceRequestNumber { get; set; }

        public DateTime MessageCreationDate { get; set; }

        public string ChannelId { get; set; }

        public string TransactionType { get; set; }

        public string ReferenceField1 { get; set; }

        public string ReferenceField2 { get; set; }

        public string ReferenceField3 { get; set; }

        public string ReferenceField4 { get; set; }

        public string ReferenceField5 { get; set; }

        public string ReferenceField6 { get; set; }

        public string Description { get; set; }

        public List<TradeFinanceInvoiceDetailCreateDto> TradeFinanceInvoiceDetails { get; set; }

        public List<TradeFinanceCreditNoteDetailCreateDto> TradeFinanceCreditNoteDetails { get; set; }
    }
}
