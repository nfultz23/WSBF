/*This file acts as the controller of a group of subpages that will be
 * referred to as the 'Event' family of pages. It handles routes to any
 * subpages from the "wsbf.net/Event" root URL. This family includes
 * the following pages
 * 
 *   Booking....Information about performing in a WSBF show, and about
 *               booking WSBF for an event
 *   Calendar...A calendar displaying the days of live music shows,
 *               tabling events, important station landmarks, and
 *               eventually the debut date of WSBF Live Sessions
 *   Shows......A list of previous and future live shows, including
 *               the date, location, artists, and price
 *               
 *If you are working on the site and decide to add, remove, or modify
 * the use of any entry in the 'Event' family, please update the list
 * in this header so that this can be a quick-reference point for all
 * items handled by this controller. Happy developing!
 */

using Microsoft.AspNetCore.Mvc;
//using WSBF.Web.Data;
using WSBF.Web.Data.Entities;
using WSBF.Web.Data.Services;
//using WSBF.Web.Models

namespace WSBF.Web.Controllers
{
	public class EventController : Controller
	{
		//Stores info about the environment that the site lives in
		private readonly IWebHostEnvironment hostEnvironment;
		private readonly ScheduleService _scheduleAPI;

		/*Parameterized constructor for the controller of the 'Event'
		 * family of pages. Initializes the private field holding info
		 * about the hosting environment. This contstructor is never
		 * explicitly called.
		 * 
		 *@param web...Is the information about the hosting environment
		 */
		public EventController(IWebHostEnvironment web) {
			hostEnvironment = web;
			_scheduleAPI = new ScheduleService();
		}

		/*Provides the site code for the "Calendar" page. This is
		 * the default page when the "EVENTS" button is clicked by
		 * the user. Otherwise accessible through navigation buttons
		 * within pages in the 'Event' family and the 'CALENDAR'
		 * button in the default subheader pages.
		 * 
		 *@return...The Calendar.cshtml view site code
		 */
		[Route("/Events")]
		[Route("/Events/Calendar")]
		public async Task<IActionResult> Calendar() {
			var eventList = await _scheduleAPI.getAllEvents();
			return View(eventList);
		}

		/*Provides the site code for the "Shows" page. This is
		 * accessible through navigation buttons within pages in
		 * the 'Events' family.
		 * 
		 *@return...The Shows.cshtml view site code
		 */
		[Route("/Events/Shows")]
		public async Task<IActionResult> Shows() {
			var showList = await _scheduleAPI.getLiveShows();
			return View(showList);
		}

		/*Provides the site code for the "Booking" page. This is
		 * accessible through navigation buttons within pages in
		 * the 'Events' family.
		 * 
		 *@return...The Booking.cshtml view site code
		 */
		[Route("/Events/Booking")]
		public IActionResult Booking() { return View(); }
	}
}
