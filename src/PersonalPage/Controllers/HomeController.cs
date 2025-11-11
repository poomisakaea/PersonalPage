using Microsoft.AspNetCore.Mvc;
using PersonalPage.Models;
using PersonalPage.Services;

namespace PersonalPage.Controllers
{
    /// <summary>
    /// Home controller for displaying the personal page.
    /// TH: ตัวควบคุมหน้าแรกสำหรับแสดงหน้าส่วนตัว
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IOwnerProvider _ownerProvider;

        /// <summary>
        /// Initialize HomeController with dependency injection.
        /// TH: เริ่มต้น HomeController ด้วย dependency injection
        /// </summary>
        public HomeController(IOwnerProvider ownerProvider)
        {
            _ownerProvider = ownerProvider;
        }

        /// <summary>
        /// Displays the home page with owner information.
        /// TH: แสดงหน้าแรกพร้อมข้อมูลเจ้าของ
        /// </summary>
        public IActionResult Index()
        {
            var owner = _ownerProvider.GetOwner();
            
            if (owner == null || !owner.IsValid())
            {
                // Handle case where owner data is not properly configured
                owner = new Owner
                {
                    Name = "Your Name",
                    Email = "your.email@example.com"
                };
            }

            return View(owner);
        }
    }
}
