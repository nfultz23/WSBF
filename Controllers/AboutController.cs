/*This file acts as the controller of a group of subpages that will be
 * referred to as the 'About' family of pages. It handles routes to any
 * subpages from the "wsbf.net/About" root URL. This family includes
 * the following pages:
 * 
 *   About Us....Information about the radio station
 *   Contact.....Contact information for the staff
 *   Join........Resources for how to join the radio station
 *   Promotion...Information about airing promotions during a show
 *   Staff.......Info about our staff
 *
 *If you are working on the site and decide to add, remove, or modify
 * the use of any entry in the 'About' family, please update the list
 * in this header so that this can be a quick-reference point for all
 * items handled by this controller. Happy developing!
 */

using Microsoft.AspNetCore.Mvc;
using WSBF.Web.Data.Services;
using WSBF.Web.Models;

namespace WSBF.Web.Controllers
{
	public class AboutController : Controller
	{
		//Stores info about the environment that the site lives in
		private readonly IWebHostEnvironment hostEnvironment;

		private readonly StaffService _staffAPI;

		/*Parameterized constructor for the controller of the 'About'
		 * family of pages. Initializes the private field holding info
		 * about the hosting environment. This constructor is never
		 * explicitly called.
		 * 
		 *@param web...Is the information about the hosting environment.
		 */
		public AboutController(IWebHostEnvironment web) {
			hostEnvironment = web;
			_staffAPI = new StaffService();
		}

		/*Provides the site code for the "About Us" page. This is
		 * the default page when the "ABOUT" button is clicked by
		 * the user. Otherwise accessible through navigation buttons
		 * within pages in the 'About' family.
		 * 
		 *@return...The AboutUs.cshtml view site code.
		 */
		[Route("/About")]
		[Route("/About/AboutUs")]
		public IActionResult AboutUs() { return View(); }

		/*Provides the site code for the "Contact Us" page. This is
		 * accessible through navigation buttons within pages in
		 * the 'About' family.
		 * 
		 *@return...The Contact.cshtml view site code.
		 */
		[Route("/About/Contact")]
		public IActionResult Contact() { return View(); }

		/*Provides the site code for the "Staff" page. This is
		 * accessible through navigation buttons within pages in
		 * the 'About' family.
		 * 
		 *@return...The Staff.cshtml view site code.
		 */
		[Route("/About/Staff")]
		public async Task<IActionResult> Staff() {
			var SeniorStaff = await _staffAPI.getAllStaff();
			return View(SeniorStaff);
		}

		/*Provides the site code for the "Join Us" page. This is
		 * accessible through navigation buttons within pages in
		 * the 'About' family and in the default subheader pages.
		 * 
		 *@return...The Join.cshtml view site code.
		 */
		[Route("/About/Join")]
		public IActionResult Join() { return View(); }

		/*Provides the site code for the "Promotion" page. This is
		 * accessible through navigation buttons within pages in the
		 * 'About' family.
		 * 
		 *@return...The Promotion.cshtml view site code.
		 */
		[Route("/About/Promotion")]
		public IActionResult Promotion() { return View(); }
	}
}
