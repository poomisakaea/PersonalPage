using PersonalPage.Models;
using Microsoft.Extensions.Configuration;

namespace PersonalPage.Services
{
    /// <summary>
    /// Interface for providing owner information.
    /// TH: ส่วนติดต่อสำหรับให้ข้อมูลเจ้าของ
    /// </summary>
    public interface IOwnerProvider
    {
        /// <summary>
        /// Get the owner's information.
        /// TH: ได้รับข้อมูลเจ้าของ
        /// </summary>
        Owner? GetOwner();
    }

    /// <summary>
    /// Implementation of IOwnerProvider that loads owner data from configuration.
    /// TH: การใช้งาน IOwnerProvider ที่โหลดข้อมูลเจ้าของจากการตั้งค่า
    /// </summary>
    public class OwnerProvider : IOwnerProvider
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initialize OwnerProvider with configuration.
        /// TH: เริ่มต้น OwnerProvider ด้วยการตั้งค่า
        /// </summary>
        public OwnerProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get owner information from appsettings.json or environment variables.
        /// 
        /// Configuration sources (in order of precedence):
        /// 1. Environment variables: Owner__Name, Owner__Email
        /// 2. appsettings.json: Owner.Name, Owner.Email
        /// 3. Hard-coded defaults
        /// 
        /// TH: ได้รับข้อมูลเจ้าของจากการตั้งค่าหรือตัวแปรสภาพแวดล้อม
        /// </summary>
        public Owner? GetOwner()
        {
            var name = _configuration["Owner:Name"] ?? "Default Owner";
            var email = _configuration["Owner:Email"] ?? "default@example.com";

            return new Owner
            {
                Name = name,
                Email = email
            };
        }
    }
}
