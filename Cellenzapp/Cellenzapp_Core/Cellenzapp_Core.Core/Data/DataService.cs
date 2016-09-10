using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellenzapp_Core.Core.BusinessObjects;

namespace Cellenzapp_Core.Core.Data
{
    class DataService : IDataService
    {
        private bool IsCorrectlyLoaded = false;
        private Task<bool> LoadingCellExperts;
        public IEnumerable<CellExpert> CellExperts { get; set; }

        public async Task<bool> TryLoadCellExpertsAsync()
        {
            if (LoadingCellExperts != null)
            {
                await LoadingCellExperts;
                return IsCorrectlyLoaded;
            }
            else
            {
                LoadingCellExperts = new Task<bool>(() =>
                {
                    return true;
                });
            }
            return true;
        }
    }
}
