using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WSBF.Web.Data.Entities;

namespace WSBF.Web.Data.Services
{
	public class StaffService
	{
		private readonly HttpClient _httpClient;

		public StaffService()
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

		public async Task<IEnumerable<StaffMember>> getAllStaff()
		{
			var responseData = await this.GetAsync<IEnumerable<StaffMember>>("/staff");
			return responseData;
		}

		public async Task<StaffMember> getStaffByTitle(string title)
		{
			var responseData = (from st in await this.getAllStaff()
								 where st.title == title
								 select st).FirstOrDefault();

			return responseData;
		}
	}
}
