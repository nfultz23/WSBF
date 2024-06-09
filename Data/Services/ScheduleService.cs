using Newtonsoft.Json;
using WSBF.Web.Data.Entities;

namespace WSBF.Web.Data.Services
{
	public class ScheduleService
	{
		private readonly HttpClient _httpClient;

		public ScheduleService()
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

		public async Task< IEnumerable<Show> > getAllShows()
		{
			var responseData = await this.GetAsync<IEnumerable<Show>>("/shows");
			return responseData;
		}

		public async Task< IEnumerable<Show> > getShowsByDay(string day)
		{
			var responseData = await this.GetAsync<IEnumerable<Show>>("/shows?day=" + day);
			return responseData;
		}

		public async Task< IEnumerable<Event> > getAllEvents()
		{
			var eventslist = await this.GetAsync<IEnumerable<Event>>("/events");
			var responseData = eventslist.OrderBy(obj => obj.date[2]).ThenBy(obj => obj.date[0]).ThenBy(obj => obj.date[1]).ToList();
			return responseData;
		}

		public async Task< IEnumerable<Event> > getLiveShows()
		{
			var responseData = (from e in await this.getAllEvents()
								where e.type == "show"
								select e).ToList();
			return responseData;
		}
	}
}
