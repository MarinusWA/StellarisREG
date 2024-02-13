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

        public List<String> DLC { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGetAsync()
        {
#if !DEBUG
            if (Request.Host.Host == "stellaris.timango.com")
            {
                // Perform a 301 redirect
                return RedirectPermanent("https://stellarisreg.azurewebsites.net");
            }
#endif
            DLC = SelectState.AllDLC.Order().ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostPreSelectAsync(HashSet<String> selectedDLC, HashSet<String> selectedEthics,
            String selectedAuthority, String? selectedArchetype, String selectedOrigin, HashSet<String> selectedCivics, String prohibitedPick)
        {
            return ViewComponent("PreSelect", new
            {
                selectedDLC = selectedDLC,
                selectedOrigin = selectedOrigin,
                selectedEthics = selectedEthics,
                selectedAuthority = selectedAuthority,
                selectedArchetype = selectedArchetype,
                selectedCivics = selectedCivics,
                pick = prohibitedPick ?? String.Empty
            });
        }

        public async Task<IActionResult> OnPostEmpireListAsync(HashSet<String> selectedDLC, HashSet<String> selectedEthics,
            String selectedAuthority, String? selectedArchetype, String selectedOrigin, HashSet<String> selectedCivics)
        {
            return ViewComponent("EmpireList", new
            {
                selectedDLC = selectedDLC,
                selectedOrigin = selectedOrigin,
                selectedEthics = selectedEthics,
                selectedAuthority = selectedAuthority,
                selectedArchetype = selectedArchetype,
                selectedCivics = selectedCivics
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
