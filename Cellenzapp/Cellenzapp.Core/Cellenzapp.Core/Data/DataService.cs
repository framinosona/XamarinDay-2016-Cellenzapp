using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cellenzapp.Core.Model;
using Newtonsoft.Json;

namespace Cellenzapp.Core.Data
{
    public class DataService : IDataService
    {

        public IEnumerable<CellExpert> CellExperts { get; set; }
        HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<CellExpert>> TryLoadCellExpertsAsync()
        {
            try {
                Cellenzapi test = new Cellenzapi();
                var experts = await test.GetExperts();
                return CellExperts;
            } catch(Exception) {
                return null;
            }
        }
    }
}
