using Xunit;
using PersonalPage.Models;

namespace PersonalPage.Tests
{
    /// <summary>
    /// Unit tests for the Owner model.
    /// TH: เทสต์หน่วยสำหรับโมเดล Owner
    /// </summary>
    public class OwnerTests
    {
        /// <summary>
        /// Test that Owner with valid name and email is valid.
        /// TH: ทดสอบว่า Owner ที่มีชื่อและอีเมลที่ถูกต้องเป็นค่าที่ถูกต้อง
        /// </summary>
        [Fact]
        public void IsValid_WithValidNameAndEmail_ReturnsTrue()
        {
            // Arrange
            var owner = new Owner { Name = "Test User", Email = "test@example.com" };

            // Act
            var result = owner.IsValid();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Test that Owner with empty name is invalid.
        /// TH: ทดสอบว่า Owner ที่มีชื่อว่างเป็นค่าที่ไม่ถูกต้อง
        /// </summary>
        [Fact]
        public void IsValid_WithEmptyName_ReturnsFalse()
        {
            // Arrange
            var owner = new Owner { Name = "", Email = "test@example.com" };

            // Act
            var result = owner.IsValid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Test that Owner with null name is invalid.
        /// TH: ทดสอบว่า Owner ที่มีชื่อ null เป็นค่าที่ไม่ถูกต้อง
        /// </summary>
        [Fact]
        public void IsValid_WithNullName_ReturnsFalse()
        {
            // Arrange
            var owner = new Owner { Name = null!, Email = "test@example.com" };

            // Act
            var result = owner.IsValid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Test that Owner with empty email is invalid.
        /// TH: ทดสอบว่า Owner ที่มีอีเมลว่างเป็นค่าที่ไม่ถูกต้อง
        /// </summary>
        [Fact]
        public void IsValid_WithEmptyEmail_ReturnsFalse()
        {
            // Arrange
            var owner = new Owner { Name = "Test User", Email = "" };

            // Act
            var result = owner.IsValid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Test that Owner with null email is invalid.
        /// TH: ทดสอบว่า Owner ที่มีอีเมล null เป็นค่าที่ไม่ถูกต้อง
        /// </summary>
        [Fact]
        public void IsValid_WithNullEmail_ReturnsFalse()
        {
            // Arrange
            var owner = new Owner { Name = "Test User", Email = null! };

            // Act
            var result = owner.IsValid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Test that Owner with whitespace name is invalid.
        /// TH: ทดสอบว่า Owner ที่มีชื่อเว้นว่างเป็นค่าที่ไม่ถูกต้อง
        /// </summary>
        [Fact]
        public void IsValid_WithWhitespaceName_ReturnsFalse()
        {
            // Arrange
            var owner = new Owner { Name = "   ", Email = "test@example.com" };

            // Act
            var result = owner.IsValid();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Test that Owner validates email format through data annotations.
        /// TH: ทดสอบว่า Owner ตรวจสอบรูปแบบอีเมล
        /// </summary>
        [Theory]
        [InlineData("valid@example.com", true)]
        [InlineData("user.name@example.co.uk", true)]
        [InlineData("notanemail", false)]
        [InlineData("@example.com", false)]
        [InlineData("user@", false)]
        public void EmailValidation_WithVaryingFormats(string email, bool shouldBeValid)
        {
            // Arrange
            var owner = new Owner { Name = "Test User", Email = email };
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(owner);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            // Act
            var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(owner, context, results, true);

            // Assert
            // If shouldBeValid is true, there should be no validation errors for email
            // If shouldBeValid is false, there should be validation errors
            var hasEmailError = results.Any(r => r.MemberNames.Contains("Email"));
            Assert.Equal(!shouldBeValid, hasEmailError);
        }
    }
}
