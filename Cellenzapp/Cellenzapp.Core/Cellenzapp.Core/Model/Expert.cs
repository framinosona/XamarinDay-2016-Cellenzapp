using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Cellenzapp.Core
{
	[DataContract]
	public class Expert
	{

		[DataMember(Name = "_id")]
		public string Id { get; set; }

		[DataMember(Name = "picture")]
		public string Picture { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "company")]
		public string Company { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "tel")]
		public string Tel { get; set; }

		[DataMember(Name = "about")]
		public string About { get; set; }

		[DataMember(Name = "job")]
		public string Job { get; set; }

		[DataMember(Name = "twitter")]
		public string Twitter { get; set; }
	}
}

