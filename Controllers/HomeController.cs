/*This file acts as the controller of a group of subpages that will be
 * referred to as the 'Home' family of pages. It handles routes to any
 * subpages from the 'wsbf.net/home' root URL or directly from the
 * 'wsbf.net' URL. This family includes the following pages
 * 
 *   Index...The default splash page that welcomes a user when they
 *           enter the site. Displays what's currently playing and
 *           the shows of the day.
 *           
 *If you are working on the site and decide to add, remove, or modify
 * the use of any entry in the 'Home' family, please update the list
 * in this header so that this can be a quick-reference point for all
 * items handled by this controller. Happy developing!
 */

using Microsoft.AspNetCore.Mvc;
//using WSBF.Web.Data;
//using WSBF.Web.Entities;
//using WSBF.Web.Models;

namespace WSBF.Web.Controllers {

    public class HomeController : Controller {

        private readonly IWebHostEnvironment hostingEnvironment;

		/*Parameterized constructor for the controller of the 'Home'
		 * family of pages. Initializes the private field holding info
		 * about the hosting environment. This contstructor is never
		 * explicitly called.
		 * 
		 *@param web...Is the information about the hosting environment
		 */
		public HomeController(IWebHostEnvironment web) {
            hostingEnvironment = web;
        }

        /*Provides the site code for the default view of the site, when
         * there is no information provided, or when the homepage is
         * requested. This can be accessed from the root URL, or by
         * clicking the Lady on the header of any page.
         * 
         * @return...The Index view
         */
        [Route("")]
        [Route("/Home")]
        public IActionResult Index() { return View(); }

    }

}
