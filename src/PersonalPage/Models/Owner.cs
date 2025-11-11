using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Models
{
    /// <summary>
    /// Represents the owner of the personal page.
    /// Represents: ผู้เป็นเจ้าของของหน้าส่วนตัว
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// The owner's display name.
        /// ชื่อที่แสดงของเจ้าของ
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 200 characters")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The owner's contact email address.
        /// ที่อยู่อีเมลติดต่อของเจ้าของ
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email must be a valid email address")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Validates that the owner has both name and email.
        /// ตรวจสอบว่าเจ้าของมีทั้งชื่อและอีเมล
        /// </summary>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Email);
        }
    }
}
