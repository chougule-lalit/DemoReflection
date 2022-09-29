using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class SupplierLinkedFinancingBankBranch
    {
        public int? Id { get; set; }

        public virtual Guid? TenantId { get; set; }

        public virtual Guid FinancingBankBranchId { get; set; }

        public virtual Guid SupplierId { get; set; }

        public virtual string Description { get; set; }

        public virtual double InvoiceCountSplit { get; set; }

        public virtual string PricingBenchmark { get; set; }

        public virtual float PricingMargin { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual DateTime IsActiveDate { get; set; }

        public virtual DateTime? IsActiveNullDate { get; set; }
    }
}
