using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using PersonalPage;
using System.Net;

namespace PersonalPage.Tests
{
    /// <summary>
    /// Integration tests for the home page using TestServer.
    /// TH: เทสต์การรวมสำหรับหน้าแรกโดยใช้ TestServer
    /// </summary>
    public class HomeIntegrationTests : IAsyncLifetime
    {
        private WebApplicationFactory<Program>? _factory;
        private HttpClient? _client;

        /// <summary>
        /// Initialize the test factory and client.
        /// TH: เริ่มต้นโรงงานการทดสอบและไคลเอนต์
        /// </summary>
        public async Task InitializeAsync()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Clean up resources.
        /// TH: ทำความสะอาดทรัพยากร
        /// </summary>
        public async Task DisposeAsync()
        {
            _client?.Dispose();
            _factory?.Dispose();
            await Task.CompletedTask;
        }

        /// <summary>
        /// Test that the home page returns HTTP 200.
        /// TH: ทดสอบว่าหน้าแรกส่งกลับ HTTP 200
        /// </summary>
        [Fact]
        public async Task Get_HomePage_ReturnsOkStatus()
        {
            // Act
            var response = await _client!.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        /// <summary>
        /// Test that the home page returns HTML content type.
        /// TH: ทดสอบว่าหน้าแรกส่งกลับประเภทเนื้อหา HTML
        /// </summary>
        [Fact]
        public async Task Get_HomePage_ReturnsHtmlContentType()
        {
            // Act
            var response = await _client!.GetAsync("/");

            // Assert
            Assert.NotNull(response.Content.Headers.ContentType);
            Assert.Contains("text/html", response.Content.Headers.ContentType?.ToString() ?? "");
        }

        /// <summary>
        /// Test that the home page contains the owner name.
        /// TH: ทดสอบว่าหน้าแรกมีชื่อเจ้าของ
        /// </summary>
        [Fact]
        public async Task Get_HomePage_ContainsOwnerName()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("Your Name", content);
        }

        /// <summary>
        /// Test that the home page contains the owner email.
        /// TH: ทดสอบว่าหน้าแรกมีอีเมลเจ้าของ
        /// </summary>
        [Fact]
        public async Task Get_HomePage_ContainsOwnerEmail()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("your.email@example.com", content);
        }

        /// <summary>
        /// Test that the home page contains the mailto: link for email.
        /// TH: ทดสอบว่าหน้าแรกมีลิงก์ mailto: สำหรับอีเมล
        /// </summary>
        [Fact]
        public async Task Get_HomePage_ContainsMailtoLink()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("mailto:", content);
        }

        /// <summary>
        /// Test that the home page contains the copy button.
        /// TH: ทดสอบว่าหน้าแรกมีปุ่มคัดลอก
        /// </summary>
        [Fact]
        public async Task Get_HomePage_ContainsCopyButton()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("copyEmail", content);
        }

        /// <summary>
        /// Test that the home page includes CSS stylesheet.
        /// TH: ทดสอบว่าหน้าแรกรวมสไตล์ชีต CSS
        /// </summary>
        [Fact]
        public async Task Get_HomePage_IncludesStylesheet()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("css/style.css", content);
        }

        /// <summary>
        /// Test that the home page includes JavaScript file.
        /// TH: ทดสอบว่าหน้าแรกรวมไฟล์ JavaScript
        /// </summary>
        [Fact]
        public async Task Get_HomePage_IncludesJavaScript()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("js/main.js", content);
        }

        /// <summary>
        /// Test that the home page has proper viewport meta tag for mobile responsiveness.
        /// TH: ทดสอบว่าหน้าแรกมี viewport meta tag สำหรับการตอบสนองบนมือถือ
        /// </summary>
        [Fact]
        public async Task Get_HomePage_HasViewportMetaTag()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("viewport", content);
            Assert.Contains("width=device-width", content);
        }

        /// <summary>
        /// Test that the home page is served with proper character encoding.
        /// TH: ทดสอบว่าหน้าแรกมีการเข้ารหัสอักขระที่เหมาะสม
        /// </summary>
        [Fact]
        public async Task Get_HomePage_HasCharsetMeta()
        {
            // Act
            var response = await _client!.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("charset", content.ToLower());
        }
    }
}
