using Spectrum.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectrum.Shared.Services.States
{
    public interface IPortalState
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }

   

    public class PortalState : IPortalState
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
        public Mission? SelectedMission { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = new();
        public List<SpectrumPortal> SearchPortalData { get; set; } = new();
        public string SearchString { get; set; } = string.Empty;
        public SpectrumPortal? SelectedPortal { get; set; }

        public List<Mission> Missions = new List<Mission>();
        public int MissionCount { get; set; }
        public int MissionActiveCount { get; set; }

        public void UpdateMission()
        {
            MissionCount = Missions.Count;
            MissionActiveCount = Missions.Where(x => x.Status != Status.Done).Count();
        }

        public bool SetSelectedPortal(string portalAddr)
        {
            SelectedPortal = ApplicationUser.SpectrumPortal.Where(x => x.PortalAddress == portalAddr).FirstOrDefault();
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
