using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class CashOutflowBankDropdownOutputDto
    {
        public ParameterObjectMetaData[] ParameterObjectMetaDataArray { get; set; }

        public int? IntNullableId { get; set; }

        public int IntId { get; set; }

        public Guid FinancingBankBranchId { get; set; }

        public string FinancingBankBranchName { get; set; }

        public Guid SupplierId { get; set; }

        public List<SupplierLinkedFinancingBankBranch> SupplierLinkedFinancingBankBranches { get; set; } //= new List<SupplierLinkedFinancingBankBranch>() { new SupplierLinkedFinancingBankBranch() };

        public SupplierLinkedFinancingBankBranch SupplierLinkedFinancingBankBranch { get; set; } //= new SupplierLinkedFinancingBankBranch();

        public List<int> IntList { get; set; }

        public TradeFinancePostingBatchDto TradeFinancePostingBatchDto { get; set; }

        public SomeThing SomeThing { get; set; }

        public string[] Names { get; set; }
    }
}
