using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Newtonsoft.Json;
using WSBF.Web.Data.Entities;

namespace WSBF.Web.Data.Services
{
	public class MusicService
	{
		private readonly HttpClient _httpClient;

		public MusicService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://db0960d5-3b60-4448-95cb-6624bbbd6e1f.mock.pstmn.io");
		}

		public async Task<T> GetAsync<T>(string endpoint)
		{
			HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

			if (response.IsSuccessStatusCode)
			{
				string json = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(json);
			}
			else
			{
				throw new HttpRequestException("API request failed");
			}
		}

		public async Task< IEnumerable<RotationAlbum> > getAllAlbums()
		{
			var responseData = await this.GetAsync< IEnumerable<RotationAlbum> >("/Albums");
			return responseData;
		}

		public async Task<IEnumerable<Song>> getAllSongs()
		{
			var responseData = await this.GetAsync<IEnumerable<Song>>("/songs");
			return responseData;
		}

		public async Task<Song> getSongByID(int ID)
		{
			var responseData = (from so in await this.getAllSongs()
								where so.ID == ID
								select so).FirstOrDefault();
			return responseData;
		}

		public async Task<IEnumerable<Song>> getTop(int numChart)
		{
			var chart = await this.getAllSongs();
			chart = chart.OrderByDescending(obj => obj.Plays).ToList();

			var TopSongs = new List<Song>(); var x = 0;
			foreach (var so in chart)
			{
				if (x >= numChart) { break; };
				TopSongs.Add(so); x++;
			}

			return TopSongs;
		}

		public async Task<IEnumerable<Playlist>> getAllPlaylists()
		{
			var playlistComp = await this.GetAsync<IEnumerable<Playlist>>("/playlists");
			var responseData = playlistComp.OrderByDescending(obj => obj.id).ToList();
			return responseData;
		}

		public async Task<Playlist> getPlaylistByName(string name)
		{
			var responseData = (from p in await this.getAllPlaylists()
								where p.name == name
								select p).FirstOrDefault();
			return responseData;
		}
	}
}
