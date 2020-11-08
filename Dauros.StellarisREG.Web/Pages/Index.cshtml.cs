using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Dauros.StellarisREG.DAL;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dauros.StellarisREG.Web.Pages
{
    [IgnoreAntiforgeryToken()]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public MultiSelectList DLC { get; set; }
        public List<SelectListItem> SelectedDLC { get; set; } = new List<SelectListItem>();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var dlcStrings = new String[] { EPN.D_AncientRelics, EPN.D_Apocalypse, EPN.D_Federations, EPN.D_Lithoids, EPN.D_Megacorp, EPN.D_Necroids, EPN.D_SyntheticDawn, EPN.D_Utopia };
            if (DLC == null)
            {
                var items = new HashSet<SelectListItem>();
                foreach (var dlc in dlcStrings)
                {
                    var item = new SelectListItem
                    {
                        Value = dlc,
                        Text = dlc,
                        Selected = true
                    };
                    items.Add(item);
                }
                DLC = new MultiSelectList(items.OrderBy(i => i.Text), "Value", "Text");
            }
        }

        public async Task<IActionResult> OnPostPreSelectAsync(HashSet<String> selectedDLC, HashSet<String> selectedEthics,
            String selectedAuthority, String selectedOrigin, HashSet<String> selectedCivics, String prohibitedPick)
        {
            var i = prohibitedPick;
            return ViewComponent("PreSelect", new
            {
                selectedDLC = selectedDLC,
                selectedOrigin = selectedOrigin,
                selectedEthics = selectedEthics,
                selectedAuthority = selectedAuthority,
                selectedCivics = selectedCivics,
                pick = prohibitedPick ?? String.Empty
            });
        }
    }

    public class EmpirePropertyModel
    {
        public Boolean IsSelected { get; set; }
        public String Name { get; set; }
        public Boolean IsProhibited { get; set; }
    }

    public class DLCModel
    {
        public Boolean IsSelected { get; set; }
        public String Name { get; set; }
    }
}
