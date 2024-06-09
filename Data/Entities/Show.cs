namespace WSBF.Web.Data.Entities
{
	public class Show
	{

		public int id { get; set; }
		public string day { get; set; }
		public string name { get; set; }
		public string[] host { get; set; }

		public string img { get; set; }
		public string desc { get; set; }

		public string str_start { get; set; }
		public string str_end { get; set; }
		public double raw_start { get; set; }
		public double raw_end { get; set; }

	}
}
