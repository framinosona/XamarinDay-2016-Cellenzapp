using System;
using Cellenzapp.Core.Model;
namespace Cellenzapp.Core
{
	public class ObservableExpert
	{

		public string Id { get; set; }

		public string Picture { get; set; }

		public string Company { get; set; }

		public string Name { get; set; }

		public string Job { get; set; }

		public string Twitter { get; set; }

		public string Email { get; set; }

		public string Tel { get; set; }

		public string About { get; set; }

		public string CompanyAdress { get; set; } = "156 Boulevard Haussmann, 75008 Paris";


		public ObservableExpert(CellExpert expert)
		{
			this.Id = expert.Id.Value;
			this.Picture = expert.Picture?.Large;
			this.Company = "Cellenza";
			this.Name = expert.Name.Full;
			this.Job = expert.Job.Full;
			this.Twitter = expert.TwitterHandle;
			this.Email = expert.Email;
			this.Tel = expert.Cell;
			this.About = expert.AboutMe;
		}

		public ObservableExpert(Expert expert)
		{
			this.Id = expert.Id;
			this.Picture = expert.Picture;
			this.Company = expert.Company;
			this.Name = expert.Name;
			this.Job = expert.Job;
			this.Twitter = expert.Twitter;
			this.Email = expert.Email;
			this.Tel = expert.Tel;
			this.About = expert.About;
		}
	}
}

