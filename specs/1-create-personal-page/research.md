# การวิจัยทางเทคนิคสำหรับหน้าเว็บส่วนตัว
# Technical Research for Personal Page

## การตัดสินใจหลัก
## Key Decisions

### 1. การเลือกเทคโนโลยีหลัก | Primary Technology Selection
**การตัดสินใจ | Decision**: ใช้ ASP.NET Core MVC (.NET 8) เป็นเทคโนโลยีหลักสำหรับโปรเจคนี้ โดยยังคงใช้ HTML/CSS/JS (BEM) สำหรับส่วนหน้า

**เหตุผล | Rationale**: 
- TH: ความต้องการพัฒนาที่ซับซ้อนขึ้น (การตรวจสอบฝั่งเซิร์ฟเวอร์, ฟอร์ม, ความสามารถในการขยายในอนาคต) ต้องการโค้ดฝั่งเซิร์ฟเวอร์ที่จัดการได้ง่ายและปลอดภัย; ASP.NET Core ให้กรอบงานที่มั่นคงสำหรับงานนี้
- EN: Increased server-side requirements (server validation, form handling, future extensibility) require maintainable server code; ASP.NET Core provides a robust framework for this use case

**ทางเลือกที่พิจารณา | Alternatives Considered**:
- ASP.NET Core MVC:
  - TH: เหมาะสมสำหรับการเรนเดอร์ฝั่งเซิร์ฟเวอร์และการปรับใช้บน Azure
  - EN: Well-suited for server-rendering and Azure deployment
- Static-first (HTML/CSS/JS):
  - TH: ยังคงเป็นทางเลือกที่เบา แต่ไม่ตรงกับความต้องการฝั่งเซิร์ฟเวอร์ที่เพิ่มขึ้น
  - EN: Still lightweight but doesn't meet increasing server-side needs

### 2. วิธีการจัดการสไตล์ | Styling Approach
**การตัดสินใจ | Decision**: ใช้ CSS ด้วยวิธี BEM | CSS with BEM methodology  

**เหตุผล | Rationale**: 
- TH: BEM ให้โครงสร้างที่ชัดเจนและดูแลรักษาง่ายโดยไม่ต้องพึ่งพาเฟรมเวิร์ก รองรับการออกแบบที่ตอบสนองได้โดยธรรมชาติ
- EN: BEM provides clear structure and maintainability without framework dependencies. Supports responsive design natively.

**ทางเลือกที่พิจารณา | Alternatives Considered**:
- Tailwind CSS:
  - TH: ต้องการระบบ build pipeline สำหรับประโยชน์ที่น้อย
  - EN: Would require build pipeline for minimal benefit
- CSS-in-JS:
  - TH: ความซับซ้อนที่ไม่จำเป็นสำหรับเนื้อหาแบบคงที่
  - EN: Unnecessary complexity for static content
- CSS Frameworks (Bootstrap):
  - TH: หนักเกินไปสำหรับความต้องการสไตล์ขั้นต่ำ
  - EN: Too heavy for minimal styling needs

#### BEM คืออะไร / What is BEM?
TH: BEM ย่อมาจาก Block — Element — Modifier เป็นแนวทางการตั้งชื่อตัวคลาส CSS ที่ช่วยทำให้โครงสร้างโค้ดชัดเจนและสามารถนำกลับมาใช้ซ้ำได้ง่าย โดยแบ่งส่วนประกอบเป็น:
- Block: ส่วนประกอบหลัก (เช่น `card`)
- Element: ส่วนย่อยของบล็อก (เช่น `card__title`)
- Modifier: สถานะหรือรูปแบบที่แตกต่างของบล็อก/องค์ประกอบ (เช่น `card--large` หรือ `card__title--highlight`)

EN: BEM stands for Block — Element — Modifier, a CSS naming methodology that makes class structure explicit and reusable. It separates UI into:
- Block: the standalone component (e.g. `card`)
- Element: a child part of the block (e.g. `card__title`)
- Modifier: a flag on a block or element to change appearance/behavior (e.g. `card--large`, `card__title--highlight`)

TH: ตัวอย่าง HTML/CSS แบบง่าย:

```html
<div class="card card--large">
  <h2 class="card__title card__title--highlight">ชื่อ</h2>
  <p class="card__body">คำอธิบายสั้น ๆ</p>
</div>
```

```css
.card { /* block styles */ }
.card__title { /* element styles */ }
.card--large { /* modifier styles for the block */ }
.card__title--highlight { /* modifier styles for the element */ }
```

EN: Benefits of BEM:
- TH: ช่วยให้ชื่อคลาสมีความสอดคล้อง, ลดการชนกันของสไตล์, และง่ายต่อการอ่าน/ดูแล
- EN: Promotes consistent class names, reduces style collisions, and improves readability/maintainability

### 3. กลยุทธ์การจัดการฟอนต์ | Font Strategy
**การตัดสินใจ | Decision**: 
- TH: ใช้ฟอนต์ระบบที่รองรับภาษาไทย + Google Fonts (Noto Sans Thai) เป็นตัวสำรอง
- EN: System font stack with Thai language support + Google Fonts (Noto Sans Thai) as fallback

**เหตุผล | Rationale**: 
- TH: ฟอนต์ระบบโหลดทันทีและมีการรองรับภาษาไทยที่ดีในระบบสมัยใหม่ Google Fonts ให้การสำรองที่เชื่อถือได้
- EN: System fonts load instantly and have good Thai support on modern systems. Google Fonts provides reliable fallback.

**ทางเลือกที่พิจารณา | Alternatives Considered**:
- Local font files:
  - TH: น้ำหนักไม่จำเป็น
  - EN: Unnecessary weight
- Web font service:
  - TH: การพึ่งพาภายนอกเพิ่มเติม
  - EN: Additional external dependency

### 4. กลยุทธ์การเผยแพร่ | Deployment Strategy
**การตัดสินใจ | Decision**: 
- TH: ปรับเป็นการปรับใช้บน Azure App Service (หรือ App Service for Containers) เป็นหลัก เพื่อรองรับแอป ASP.NET Core และ pipeline CI/CD
- EN: Target Azure App Service (or App Service for Containers) as the primary deployment target to host the ASP.NET Core app and enable CI/CD pipelines

**เหตุผล | Rationale**: 
- TH: Azure ผสานกับ ASP.NET Core ได้ดี มีบริการเช่น App Service, Managed Identity, และการเชื่อมต่อ CI/CD (GitHub Actions / Azure DevOps) ที่รองรับการปรับใช้แบบอัตโนมัติ
- EN: Azure integrates well with ASP.NET Core and provides App Service, managed identities, and CI/CD capabilities (GitHub Actions / Azure DevOps) for automated deployments

**ทางเลือกที่พิจารณา | Alternatives Considered**:
- Netlify/Vercel:
  - TH: เหมาะสำหรับ static hosting แต่ไม่เหมาะสำหรับแอป ASP.NET Core ที่ต้องการ runtime ฝั่งเซิร์ฟเวอร์
  - EN: Suitable for static hosts but not for runtime-hosted ASP.NET Core apps
- GitHub Pages:
  - TH: ไม่เหมาะสำหรับโฮสต์แอป ASP.NET Core
  - EN: Not suitable for hosting ASP.NET Core apps

### 5. การวิเคราะห์และความเป็นส่วนตัว | Analytics & Privacy
**การตัดสินใจ | Decision**: 
- TH: ไม่มีการวิเคราะห์โดยค่าเริ่มต้น
- EN: No analytics by default

**เหตุผล | Rationale**: 
- TH: สอดคล้องกับแนวทางความเป็นส่วนตัวมาก่อนตามรัฐธรรมนูญ, ลดขนาดหน้าเว็บ
- EN: Aligns with constitution's privacy-first approach, reduces page weight

**ทางเลือกที่พิจารณา | Alternatives Considered**:
- Simple Analytics:
  - TH: สามารถเพิ่มแบบเลือกได้แต่ไม่จำเป็นสำหรับ MVP
  - EN: Could be added as opt-in but not needed for MVP
- Self-hosted analytics:
  - TH: ความซับซ้อนที่ไม่จำเป็น
  - EN: Unnecessary complexity

## การวิจัยแนวทางปฏิบัติที่ดีที่สุด | Best Practices Research

### การปรับประสิทธิภาพ | Performance Optimization
TH:
- ใช้รูปภาพแบบตอบสนอง (responsive) ด้วย srcset หากมีการเพิ่มรูปภายหลัง
- ฝัง CSS ที่สำคัญไว้ในหน้าเว็บ
- ชะลอการโหลดทรัพยากรที่ไม่สำคัญ
- ใช้ preconnect สำหรับ Google Fonts หากมีการใช้งาน

EN:
- Use responsive images with srcset if images added later
- Inline critical CSS
- Defer non-critical resources
- Implement preconnect for Google Fonts if used

### แนวทางการเข้าถึง | Accessibility Guidelines
TH:
- โครงสร้าง HTML เชิงความหมาย
- ใช้ ARIA labels ตามความจำเป็น
- รองรับการนำทางด้วยแป้นพิมพ์
- อัตราส่วนความคมชัดสูงสำหรับข้อความ
- ตัวบ่งชี้โฟกัสที่ชัดเจน

EN:
- Semantic HTML structure
- ARIA labels where needed
- Keyboard navigation support
- High contrast ratios for text
- Clear focus indicators

### การรองรับภาษาไทย | Thai Language Support
TH:
- ทดสอบชุดฟอนต์บนระบบปฏิบัติการและเบราว์เซอร์หลัก
- ปรับการแสดงผลข้อความให้เหมาะสม
- จัดการ RTL/LTR สำหรับเนื้อหาที่ผสมหลายภาษา

EN:
- Font stacks tested on major OS/browsers
- Text rendering optimization
- RTL/LTR handling for mixed language content

## ทบทวนเกณฑ์ทางเทคนิค | Technical Gates Review
1. มือถือมาก่อน | Mobile-first ✅
   - TH: การออกแบบที่ตอบสนอง, ไม่มีการพึ่งพาแบบเดสก์ท็อปก่อน
   - EN: Responsive design, no desktop-first dependencies
2. การเข้าถึง | Accessibility ✅
   - TH: HTML เชิงความหมาย, วางแผนรองรับ ARIA
   - EN: Semantic HTML, ARIA support planned
3. ประสิทธิภาพ | Performance ✅
   - TH: เป้าหมาย <500KB สามารถทำได้ด้วยไฟล์คงที่
   - EN: <500KB target achievable with static assets
4. ความเป็นส่วนตัว | Privacy ✅
   - TH: ไม่มีการติดตามโดยค่าเริ่มต้น
   - EN: No tracking by default
5. ความเรียบง่าย | Simplicity ✅
   - TH: เทคโนโลยีน้อยที่สุด, วางแผนเอกสารที่ชัดเจน
   - EN: Minimal tech stack, clear documentation planned

## การพิจารณาด้านความปลอดภัย | Security Considerations
TH:
- ส่วนหัว CSP สำหรับ GitHub Pages
- นโยบาย no-referrer สำหรับลิงก์ภายนอก
- การป้องกัน XSS ผ่านส่วนหัว Content-Type
- การกำหนดค่านโยบาย CORS

EN:
- CSP headers for GitHub Pages
- No-referrer policy for external links
- XSS protection through Content-Type headers
- CORS policy configuration

## เครื่องมือการพัฒนา | Development Tooling
TH:
- การตั้งค่า VS Code สำหรับรองรับภาษาไทย
- การตั้งค่า linting สำหรับ HTML/CSS
- git hooks พื้นฐานสำหรับตรวจสอบคุณภาพ
- สคริปต์ build อย่างง่ายหากจำเป็น

EN:
- VS Code configuration for Thai language support
- HTML/CSS linting setup
- Basic git hooks for quality checks
- Simple build script if needed