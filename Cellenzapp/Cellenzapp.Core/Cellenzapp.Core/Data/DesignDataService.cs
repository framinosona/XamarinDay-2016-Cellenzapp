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
    public class DesignDataService : IDataService
    {
        public IEnumerable<CellExpert> CellExperts { get; set; }
        HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<CellExpert>> TryLoadCellExpertsAsync()
        {
            try {
                var count = 20;
                var rawJson = await httpClient.GetStringAsync($"https://randomuser.me/api/?results={count}&noinfo");
                var output = JsonConvert.DeserializeObject<RandomUserResults>(rawJson);
                Debug.WriteLine($"DL : {output.CellExpert.Count} employees");
                CellExperts = output.CellExpert;
                return output.CellExpert;
            } catch(Exception) {
                return null;
            }
        }
    }
}
