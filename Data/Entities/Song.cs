using Newtonsoft.Json;

namespace WSBF.Web.Data.Entities
{
	public class Song
	{
		public int ID { get; set; }
		public int Disk { get; set; }
		public int Track { get; set; }
		public string Name { get; set; }
		public string Artist { get; set; }
		public string Air { get; set; }
		public int Plays { get; set; }
		public string Rot { get; set; }
	}
}
