using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellenzapp_Core.Core.BusinessObjects;

namespace Cellenzapp_Core.Core.Data
{
    public interface IDataService
    {
        IEnumerable<CellExpert> CellExperts { get; set; }

        Task<bool> TryLoadCellExpertsAsync();
    }
}
