namespace WSBF.Web.Data.Entities
{
	public class RotationAlbum
	{
		public string Code { get; set; }
		public string Artist { get; set; }
		public string Album { get; set; }
		public string Label { get; set; }
		public string Gen_Genre { get; set; }
		public string[] Genre { get; set; }
		public string Reviewer { get; set; }
		public string Review { get; set; }
		public int[] Songs { get; set; }
		public string[] Rel_Artists { get; set; }
	}
}
