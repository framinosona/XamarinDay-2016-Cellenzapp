using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cellenzapp.Core.Model;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Cellenzapp.Core.Data
{
	public class DataService : IDataService
	{

		private const string SUBSCRIPTION_KEY = "7967e8f89c93428686a7489886bb0b5c";

		public IEnumerable<ObservableExpert> CellExperts { get; set; }
		HttpClient httpClient = new HttpClient();

		public DataService()
		{
			httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Trace", "true");
			httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "7967e8f89c93428686a7489886bb0b5c");
		}

		public async Task<IEnumerable<ObservableExpert>> TryLoadCellExpertsAsync()
		{
			var rawJson = await httpClient.GetStringAsync("https://cellenzamanagementrandomapi.azure-api.net/cellenzapi/api/Experts?");
			var unescapedRawJson = Regex.Unescape(rawJson).TrimEnd('"').TrimStart('"');
			var output = JsonConvert.DeserializeObject<List<Expert>>(rawJson);
			Debug.WriteLine($"DL : {output.Count} employees");
			CellExperts = output.Select((expert) => new ObservableExpert(expert));
			return CellExperts;
		}
	}
}
