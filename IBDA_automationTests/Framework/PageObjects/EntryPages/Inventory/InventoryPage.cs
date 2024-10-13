using IBDA_automationTests.Framework.PageObjects.Shared.Components;
using IBDA_automationTests.Framework.PageObjects.Shared.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBDA_automationTests.Framework.PageObjects.EntryPages.Inventory
{
    public class InventoryPage : EntryPageBase
    {
        public List<ProductCard> ProductCards => SelectAll<ProductCard>(".inventory_item");
        public DropdownMenu SortDropdownMenu => Select<DropdownMenu>(".product_sort_container");
    }
}