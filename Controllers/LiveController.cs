/*This file acts as the controller of a gorup of subpages that will be
 * referred to as the 'Live' family of pages. It handles routes to any
 * subpages from the "wsbf.net/Live" root URL. This family includes the
 * following pages:
 * 
 *   Live...Provides the user with a live video feed of the broadcast
 *           studio, the current and recently played songs, the current
 *           show being broadcast, and a chat box to talk to the DJ and
 *           other listeners.
 *           
 *If you are working on the site and decide to add, remove, or modify
 * the use of any entry in the 'Live' family, please update the list
 * in this header so that this can be a quick-reference point for all
 * items handled by this controller. Happy developing!
 */

using Microsoft.AspNetCore.Mvc;
//using WSBF.Web.Data;
//using WSBF.Web.Entities;
//using WSBF.Web.Models

namespace WSBF.Web.Controllers
{
	public class LiveController : Controller
	{
		//Stores info about the nevironment that the site lives in
		private readonly IWebHostEnvironment hostEnvironment;

		/*Parameterized constructor for the controller of the 'Live'
		 * family of pages. Initializes the private field holding info
		 * about the hosting environment. This constructor is never
		 * explicitly called.
		 * 
		 *@param web...Is the information about the hosting environment.
		 */
		public LiveController(IWebHostEnvironment web) { hostEnvironment = web; }

		/*Provides the site code for the "Live" page. This is
		 * the default page when the "LIVE!" button is clicked by
		 * the user. Otherwise accessible through navigation buttons
		 * within any page with the default subheader.
		 * 
		 *@return...The Live.cshtml view site code
		 */
		[Route("/Live")]
		public IActionResult LiveIndex() { return View(); }
	}
}
