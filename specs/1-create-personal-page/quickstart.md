# คู่มือเริ่มต้นอย่างรวดเร็ว | Quick Start Guide

## การตั้งค่าการพัฒนา | Development Setup

### สิ่งที่ต้องมี | Prerequisites
TH:
- Git
- เว็บเบราว์เซอร์พร้อมเครื่องมือนักพัฒนา
- โปรแกรมแก้ไขข้อความ (แนะนำ VS Code)
- ตัวเลือก: Node.js (สำหรับรันเซิร์ฟเวอร์ในเครื่อง)

EN:
- Git
- Web browser with dev tools
- Text editor (VS Code recommended)
- Optional: Node.js (for running local server)

### การเริ่มต้น | Getting Started

1. โคลนที่เก็บ | Clone the repository:
   ```bash
   git clone [repository-url]
   cd PersonalPage
   ```

2. การพัฒนา | Development:
   TH:
   - แก้ไขไฟล์ HTML/CSS/JS โดยตรง
   - ใช้ VS Code Live Server หรือเซิร์ฟเวอร์ไฟล์คงที่อื่น ๆ
   - สำหรับตัวเลือก ASP.NET Core MVC ดูที่ "ตัวเลือก: การตั้งค่า ASP.NET Core" ด้านล่าง

   EN:
   - Edit HTML/CSS/JS files directly
   - Use VS Code Live Server or any static file server
   - For ASP.NET Core MVC option, see "Optional: ASP.NET Core Setup" below

3. การทดสอบ | Testing:
   TH:
   - เปิดในเบราว์เซอร์/อุปกรณ์ต่าง ๆ
   - รันการตรวจสอบการเข้าถึง (เช่น WAVE, aXe)
   - ตรวจสอบ HTML (W3C Validator)
   - ทดสอบกับโปรแกรมอ่านหน้าจอ

   EN:
   - Open in different browsers/devices
   - Run accessibility checks (e.g., WAVE, aXe)
   - Validate HTML (W3C Validator)
   - Test with screen readers

### การเผยแพร่ | Deployment

1. GitHub Pages:
   TH:
   - Push การเปลี่ยนแปลงไปยังสาขา `main`
   - เปิดใช้งาน GitHub Pages ในการตั้งค่าที่เก็บ
   - เว็บไซต์จะใช้งานได้ที่ `username.github.io/PersonalPage`

   EN:
   - Push changes to `main` branch
   - Enable GitHub Pages in repository settings
   - Site will be live at `username.github.io/PersonalPage`

2. การทดสอบในเครื่อง | Local Testing:
   ```bash
   # TH: ใช้ Python (ต้องมี Python 3.x)
   # EN: Using Python (Python 3.x required)
   python -m http.server 8000

   # TH: หรือใช้ Node.js (ต้องมี Node.js)
   # EN: OR using Node.js (Node.js required)
   npx serve
   ```

### การตรวจสอบคุณภาพ | Quality Checks

รันสิ่งเหล่านี้ก่อนคอมมิต | Run these before committing:
TH:
1. การตรวจสอบ HTML
2. การตรวจสอบ CSS
3. การตรวจสอบการเข้าถึง
4. การตรวจสอบประสิทธิภาพ
5. ทดสอบการตอบสนองบนมือถือ

EN:
1. HTML validation
2. CSS validation
3. Accessibility check
4. Performance audit
5. Mobile responsiveness test

### ตัวเลือก: การตั้งค่า ASP.NET Core | Optional: ASP.NET Core Setup

TH: หากใช้ ASP.NET Core MVC:
EN: If using ASP.NET Core MVC:

1. สิ่งที่ต้องมี | Prerequisites:
   TH:
   - .NET SDK 8.0 หรือใหม่กว่า
   - Visual Studio 2022 หรือ VS Code พร้อมส่วนขยาย C#

   EN:
   - .NET SDK 8.0 or later
   - Visual Studio 2022 or VS Code with C# extension

2. การพัฒนา | Development:
   ```bash
   dotnet restore
   dotnet run
   ```

3. การสร้างสำหรับใช้งานจริง | Production Build:
   ```bash
   dotnet publish -c Release
   ```

4. การสร้าง Docker | Docker Build:
   TH: (หากใช้คอนเทนเนอร์)
   EN: (if using containers)
   ```bash
   docker build -t personal-page .
   docker run -p 80:80 personal-page
   ```

## การแก้ไขปัญหา | Troubleshooting

ปัญหาทั่วไปและวิธีแก้ | Common issues and solutions:

1. ฟอนต์ภาษาไทยไม่แสดง | Thai font not displaying:
   TH:
   - ตรวจสอบฟอนต์ระบบ
   - ตรวจสอบการเชื่อมต่อ Google Fonts
   - ตรวจสอบฟอนต์สำรอง

   EN:
   - Check system fonts
   - Verify Google Fonts connection
   - Check font-family fallbacks

2. ลิงก์อีเมลไม่ทำงาน | Email link not working:
   TH:
   - ตรวจสอบไวยากรณ์ mailto:
   - ตรวจสอบรูปแบบที่อยู่อีเมล
   - ทดสอบในเบราว์เซอร์ต่าง ๆ

   EN:
   - Verify mailto: syntax
   - Check email address format
   - Test in different browsers

3. ปัญหาการแสดงผลบนมือถือ | Mobile display issues:
   TH:
   - ตรวจสอบแท็ก viewport meta
   - ตรวจสอบ media queries
   - ทดสอบบนอุปกรณ์จริง

   EN:
   - Check viewport meta tag
   - Verify media queries
   - Test on real devices