using Spectrum.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Shared.Services.States
{
    public class PortalState
    {
        public ApplicationUser ApplicationUser { get; set; } = new();
        public List<SpectrumPortal> SearchPortalData { get; set; } = new();
        public string SearchString { get; set; } = string.Empty;
        public SpectrumPortal? SelectedPortal { get; set; }

        public bool SetSelectedPortal(SpectrumPortal portal)
        {
            SelectedPortal = ApplicationUser.SpectrumPortal.Where(x => x.Id == portal.Id).FirstOrDefault();
            return SelectedPortal != null;
        }


        public void ClearSelectedPortal()
        {
            SelectedPortal = null;
        }

        public void AddPortal(bool done)
        {
            if (done)
            {
                var portal = ApplicationUser.SpectrumPortal.FirstOrDefault(SelectedPortal);
                if (portal != null) return;
                ApplicationUser.SpectrumPortal.Add(SelectedPortal!);
                SearchPortalData.Add(SelectedPortal!);
            }
        }

        public void RemovePortal(string id, bool done)
        {
            if(done)
            {
                SelectedPortal = null;
                var toRemove = ApplicationUser.SpectrumPortal.Where(x => x.Id == id).FirstOrDefault();
                if(toRemove == null) { return; }
                ApplicationUser.SpectrumPortal.Remove(toRemove);
                SearchPortalData.Remove(toRemove);
            }
        }


        public void LoadUser(ApplicationUser user)
        {
            ApplicationUser = user;
            SearchPortalData = user.SpectrumPortal.ToList();
        }

        public void ResetSearch()
        {
            SearchString = string.Empty;
            SearchPortalData = ApplicationUser.SpectrumPortal.ToList();
        }

        public void FilterPortal()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                SearchPortalData = ApplicationUser.SpectrumPortal
                    .Where(x => x.Name!.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1)
                    .ToList();
            }
            else
            {
                SearchPortalData = ApplicationUser.SpectrumPortal.ToList();
            }
        }

    }
}
