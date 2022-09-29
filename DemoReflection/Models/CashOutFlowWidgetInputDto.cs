using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection.Models
{
    public class CashOutFlowWidgetInputDto
    {
        public WidgetTenure WidgetTenure { get; set; }

        public List<Guid> SupplierIds { get; set; } = new List<Guid>();

        public List<Guid> BankIds { get; set; } = new List<Guid>();

        public List<Guid> BusinessEntityIds { get; set; } = new List<Guid>();
    }

    public enum WidgetTenure
    {
        Monthly = 1,
        Yearly = 2
    }
}
