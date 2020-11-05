using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Dauros.StellarisREG.DAL;
using System.Security.Policy;

namespace Dauros.StellarisREG.Web.Pages
{
    [IgnoreAntiforgeryToken()]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public List<EmpirePropertyModel> Ethics { get; set; } = new List<EmpirePropertyModel>();
        [BindProperty]
        public List<EmpirePropertyModel> Origins { get; set; } = new List<EmpirePropertyModel>();
        [BindProperty]
        public List<EmpirePropertyModel> Civics { get; set; } = new List<EmpirePropertyModel>();
        [BindProperty]
        public List<EmpirePropertyModel> Authorities { get; set; } = new List<EmpirePropertyModel>();


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            if (!Ethics.Any())
            {
                var allEthics = Ethic.Collection;
                Ethics = allEthics.Select(e => new EmpirePropertyModel() { Name = e.Key }).ToList();
            }

            if (!Origins.Any())
            {
                var allOrigin = Origin.Collection;
                Origins = allOrigin.Select(e => new EmpirePropertyModel() { Name = e.Key }).ToList();
            }


            var state = new SelectState();
            state.SelectedDLC.UnionWith(new String[] { EPN.D_Utopia, EPN.D_AncientRelics, EPN.D_Apocalypse,EPN.D_Federations,EPN.D_Megacorp,EPN.D_SyntheticDawn });
            //state.CivicNames.Add(EPN.C_ImperialCult);
            //state.CivicNames.Add(EPN.C_AgrarianIdyll);
            state.CivicNames.Add(EPN.C_FanaticPurifiers);


            var test = state.GetProhibited();

        }

        public async Task<JsonResult> OnGetPreSelectAsync()
        {
            return new JsonResult(null);
        }

        private void RenderPage(SelectState state)
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var state = new SelectState();
            state.EthicNames = Ethics.Where(e=>e.IsSelected).Select(e => e.Name).ToHashSet();
            state.CivicNames = Civics.Where(e => e.IsSelected).Select(e => e.Name).ToHashSet();
            state.OriginName = Origins.First(o => o.IsSelected).Name;
            state.AuthorityName = Authorities.First(o => o.IsSelected).Name;

            

            //Prohibit


            return Page();
        }
    }

    public class EmpirePropertyModel
    {
        public Boolean IsSelected { get; set; }
        public String Name { get; set; }
        public Boolean IsProhibited { get; set; }
    }
}
