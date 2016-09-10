using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cellenzapp.Core.BusinessObjects;

namespace Cellenzapp.Core.Data
{
    public interface IDataService
    {
        IEnumerable<CellExpert> CellExperts { get; set; }

        Task<bool> TryLoadCellExpertsAsync();
    }
}
