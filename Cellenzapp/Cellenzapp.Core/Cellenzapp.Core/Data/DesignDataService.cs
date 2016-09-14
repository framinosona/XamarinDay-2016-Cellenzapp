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
		public IEnumerable<ObservableExpert> CellExperts { get; set; }
        HttpClient httpClient = new HttpClient();

        public async Task<IEnumerable<ObservableExpert>> TryLoadCellExpertsAsync()
        {
            try {
                var count = 20;
                var rawJson = await httpClient.GetStringAsync($"https://randomuser.me/api/?results={count}&noinfo");
                var output = JsonConvert.DeserializeObject<RandomUserResults>(rawJson);
                Debug.WriteLine($"DL : {output.CellExpert.Count} employees");
                CellExperts = output.CellExpert.Select((expert) => new ObservableExpert(expert));
                return CellExperts;
            } catch(Exception) {
                return null;
            }
        }
    }
}
