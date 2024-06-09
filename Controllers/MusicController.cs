/*This file acts as the controller of a group of subpages that will be
 * referred to as the 'Music' family of pages. It handles routes to any
 * subpages from the "wsbf.net/Music" root URL. This family includes the
 * following pages:
 * 
 *   Charting....A chart of the most popular songs and albums on the
 *                WSBF broadcast
 *   DJSignIn....A Sign-in point for DJs, once signed in will redirect
 *                to the 'Broadcast' family of pages
 *   Playlists...A set of previous show recordings and playlists put
 *                together by the WSBF staff (probably the music crew)
 *   Recording...Information about booking the WSBF station as a
 *                recording studio, or using WSBF recording equipment
 *   Schedule....The schedule of WSBF show titles and DJs throughout
 *                the week, and links to previous playlists and
 *                archived shows
 *                
 *If you are working on the site and decide to add, remove, or modify
 * the use of any entry in the 'Music' family, please update the list
 * in this header so that this can be a quick-reference point for all
 * items handled by this controller. Happy developing!
 */

using Microsoft.AspNetCore.Mvc;
using WSBF.Web.Data.Services;
using WSBF.Web.Models;

namespace WSBF.Web.Controllers
{
	public class MusicController : Controller
	{
		//Stores info about the environment that the site lives in
		private readonly IWebHostEnvironment hostEnvironment;

		private readonly ScheduleService _scheduleAPI;
		private readonly MusicService _musicAPI;

		/*Parameterized constructor for the controller of the 'Music'
		 * family of pages. Initializes the private field holding info
		 * about the hosting environment. This constructor is never
		 * explicitly called.
		 * 
		 *@param web...Is the information about the hosting environment.
		 */
		public MusicController(IWebHostEnvironment web) {
			hostEnvironment = web;
			_scheduleAPI = new ScheduleService();
			_musicAPI = new MusicService();
		}

		/*Provides the site code for the "Schedule" page. This is
		 * the default page when the "MUSIC" button is clicked by
		 * the user. Otherwise accessible through navigation buttons
		 * within the pages in the 'Music' family and in the default
		 * subheader pages.
		 * 
		 *@param day...Represents the first three letters (non-capitalized)
		 * of the day whose schedule is being viewed. Nullable, if no value
		 * passed then the value 'sun' is used by default
		 * 
		 *@return...the Schedule.cshtml view site code
		 */
		[Route("/Music")]
		[Route("/Music/Schedule")]
		public async Task<IActionResult> Schedule(string? day) {
			string currday;
			if (day == null) { currday = "sun"; }
			else { currday = day; }

			//Request a list of all shows from the Schedule API, then
			// initialize a ShowSchedule model with it
			var showList = await _scheduleAPI.getAllShows();
			var schedule = new ShowSchedule(showList, currday);

			//Pass the schedule model into the view to display the show
			return View(schedule);
		}

		/*Provides the site code for the "Charting" page. This is
		 * accessible through the navigation buttons within pages in
		 * the 'Music' family.
		 * 
		 *@return...The Charting.cshtml view site code.
		 */
		[Route("/Music/Charting")]
		public async Task<IActionResult> Charting() {

			var songRequest = await _musicAPI.getTop(20);
			
			return View(songRequest);
		}

		/*Provides the site code for the "Playlists" page. This is
		 * accessible through navigation buttons within pages in
		 * the 'Music' family.
		 * 
		 *@return...The Playlist.cshtml view site code
		 */
		[Route("/Music/Playlists")]
		public async Task<IActionResult> Playlists() {
			var playlistSet = await _musicAPI.getAllPlaylists();
			return View(playlistSet);
		}

		/*Provides the site code for the "Recording" page. This is
		 * accessible thorugh navigation buttons within pages in
		 * the 'Music' family.
		 * 
		 *@return...The Contact.cshtml view site code.
		 */
		[Route("/Music/Recording")]
		public IActionResult Recording() { return View(); }

		/*Provides the site code for the "DJs" sign-in page. This is
		 * accessible through navigation buttons within pages in
		 * the 'Music' family and in pages with the default subheader
		 * 
		 *@return...The DJSignIn.cshtml view site code
		 */
		[Route("/Music/DJs")]
		public IActionResult DJSignIn() { return View(); }


	}
}
