# Feature: สร้างหน้าเว็บบุคคลหน้าเดียว (ชื่อ + อีเมล)  
# Feature: Single personal page (Name + Email)

**Feature Branch**: `1-create-personal-page`  
**Created**: 2025-11-10  
**Status**: Draft  
**Input**: 
TH: ผู้ใช้ต้องการหน้าเว็บส่วนตัวหน้าเดียวเพื่อแสดงเพียงชื่อและอีเมลติดต่อเท่านั้น ("สร้างหน้าเว็บบุคคล 1 หน้าเว็บ").

EN: The user wants a single personal page that displays only the name and contact email ("create 1 personal page").

## User Scenarios & Testing *(mandatory)* / กรณีผู้ใช้ & การทดสอบ *(ต้องมี)*

### User Story 1 - ผู้เข้าชมทั่วไป (Priority: P1)  
TH: ผู้เข้าชมต้องการเห็นชื่อและสามารถติดต่อผ่านอีเมลได้โดยง่าย

EN: Visitor wants to quickly see the name and be able to contact via email easily.

**Why this priority | เหตุผลที่ให้ความสำคัญ**: 
TH: หน้านี้ถูกออกแบบให้เรียบง่ายที่สุด เพื่อให้ข้อมูลติดต่อพื้นฐานชัดเจนและลดเวลาการโหลด

EN: The page is intentionally minimal to make contact info clear and minimize load time.

**Independent Test | การทดสอบแยก**: เปิดหน้าเว็บจากมือถือและเดสก์ท็อป ตรวจสอบว่า / Open the page on mobile and desktop and verify:
1. TH: ชื่อปรากฏชัดและอ่านง่าย  
	 EN: Name is clearly visible and readable
2. TH: มีลิงก์อีเมลหรือปุ่มที่เปิด client อีเมล (mailto:) หรือแสดงวิธีการคัดลอกอีเมลที่ชัดเจน  
	 EN: There is a mailto: link or a copy-email control that clearly communicates how to contact

**Acceptance Scenarios | เกณฑ์ยอมรับ**:
1. TH: Given: ผู้ใช้เปิดหน้าเว็บบนมือถือ, When: หน้าโหลดเสร็จ, Then: ผู้ใช้เห็นชื่อและช่องทางอีเมลภายใน 5–10 วินาที
	 EN: Given: user opens the page on mobile; When: page finishes loading; Then: user can identify the name and email contact within 5–10s
2. TH: Given: ผู้ใช้คลิกอีเมล, When: คลิก, Then: จะเปิด client อีเมลด้วยช่อง To ที่ตั้งค่าไว้ (หรือแสดงวิธีคัดลอกอีเมลถ้าไม่มี mailto)
	 EN: Given: user clicks the email; When: click; Then: the email client opens with To set (or a copy flow is shown if mailto is not possible)

---

### Edge Cases | กรณีพิเศษ
- TH: การเข้าถึงจากเครือข่ายช้าหรือบล็อกสคริปต์บุคคลที่สาม
- EN: Access from slow networks or environments that block third-party scripts
- TH: ฟอนต์ที่ไม่รองรับภาษาไทยต้องมี fallback
- EN: Fonts that do not support Thai must have a suitable fallback

## Requirements *(mandatory)* / ข้อกำหนด *(ต้องมี)*

### Functional Requirements / ข้อกำหนดเชิงฟังก์ชัน
- FR-001: TH: เว็บไซต์ MUST แสดงชื่อของเจ้าของหน้าอย่างชัดเจน  
	EN: The site MUST display the owner's name prominently
- FR-002: TH: เว็บไซต์ MUST แสดงอีเมลติดต่อที่ใช้งานได้ (mailto: หรือวิธีคัดลอกอีเมล)  
	EN: The site MUST present a working contact email (mailto: or copy flow)
- FR-003: TH: เว็บไซต์ MUST โหลดและใช้งานได้บนมือถือ (responsive)  
	EN: The site MUST load and function on mobile (responsive)
- FR-004: TH: เว็บไซต์ MUST ปฏิบัติตามข้อกำหนด accessibility พื้นฐาน (semantic HTML, สามารถนำทางด้วยคีย์บอร์ด)  
	EN: The site MUST meet basic accessibility standards (semantic HTML, keyboard navigable)
- FR-005: TH: เว็บไซต์ SHOULD จำกัดการโหลดสคริปต์บุคคลที่สาม และ analytics ต้องเป็น opt-in  
	EN: The site SHOULD minimize third-party scripts; analytics must be opt-in

### Key Entities / เอนทิตี้สำคัญ
- TH: Owner: ข้อมูลเจ้าของหน้า (name)  
	EN: Owner: page owner's data (name)
- TH: Contact: ช่องทางติดต่อหลัก (email)  
	EN: Contact: primary contact method (email)
- TH: Asset: รูปภาพ (ถ้าใช้) และไฟล์ที่ใช้บนหน้า (มี alt, ขนาดเหมาะสม)  
	EN: Asset: images (if used) and page files (with alt and appropriate sizing)

## Success Criteria *(mandatory)* / เกณฑ์ความสำเร็จ *(ต้องมี)*

### Measurable Outcomes / ผลลัพธ์ที่วัดได้
- SC-001: TH: ผู้ใช้ทั่วไปสามารถระบุชื่อได้ภายใน 5–10 วินาที (observational test)  
	EN: A typical visitor can identify the name within 5–10 seconds (observational)
- SC-002: TH: อีเมลติดต่อสามารถใช้งานได้เมื่อทดสอบ (mailto: เปิดหรือสามารถคัดลอกอีเมลได้)  
	EN: Contact email is functional during tests (mailto: opens or copy works)
- SC-003: TH: หน้าโหลดสำเร็จภายใน 3 วินาทีในเครือข่ายปกติ (measured via performance audit)  
	EN: Page loads within 3s on a typical network (performance audit)
- SC-004: TH: Accessibility checks ผ่านข้อกำหนดพื้นฐาน (เช่น ไม่มีภาพสำคัญที่ขาด alt, การนำทางด้วยคีย์บอร์ดทำงาน)  
	EN: Accessibility checks pass basic rules (no essential images missing alt, keyboard nav works)
- SC-005: TH: หน้าแรกมีขนาดรวม assets < 500KB เมื่อเป็นไปได้ (performance target)  
	EN: Initial page total assets < 500KB where feasible (performance target)

## Assumptions / สมมติฐาน
- TH: โครงการเป็นหน้าเดียว ไม่จำเป็นต้องมี backend ซับซ้อน (static-first)  
	EN: Project is single-page; no complex backend required (static-first)
- TH: อีเมลที่จะใช้เป็นช่องทางติดต่อเป็นอีเมลจริงที่เจ้าของหน้าเตรียมไว้  
	EN: The contact email provided is a real address prepared by the owner
- TH: ผู้ดูแลจะเป็นผู้อนุมัติ PR และตรวจสอบการทดสอบ accessibility  
	EN: Maintainer will approve PRs and check accessibility tests

- TH: หากต้องการใช้ ASP.NET Core MVC (.NET Core) ให้ถือเป็นตัวเลือกเสริม แต่ไม่จำเป็นสำหรับความต้องการขั้นต่ำนี้: หากใช้ต้องอธิบายการ build/publish ใน README และรักษาผลลัพธ์สุดท้ายให้ง่ายและเร็ว
	EN: ASP.NET Core MVC is optional; if used, document build/publish steps in README and keep final output simple and fast

## Constraints / ข้อจำกัด
- TH: หลีกเลี่ยงเฟรมเวิร์กขนาดใหญ่หากหน้าเดียวเพียงพอ  
	EN: Avoid large frameworks when a single page suffices
- TH: ต้องเลือกฟอนต์ที่รองรับภาษาไทยหรือมี fallback ที่เหมาะสม  
	EN: Choose fonts that support Thai or include suitable fallbacks

- TH: หากใช้ ASP.NET Core MVC ให้รักษาความเรียบง่าย: หลีกเลี่ยง middlewares และ dependencies ที่เพิ่ม overhead เกินจำเป็น และให้มีคำอธิบายการ build/publish ใน README
	EN: If using ASP.NET Core MVC, keep it minimal: avoid unnecessary middlewares/deps and provide build/publish docs in README

## Deliverables / สิ่งที่ต้องส่งมอบ
- TH: Static HTML/CSS/JS (หรือ SSG output) สำหรับหน้าเดียว แสดงเพียงชื่อและอีเมล  
	EN: Static HTML/CSS/JS (or SSG output) for a single page showing only name and email
- TH: README สั้นอธิบายการพัฒนาท้องถิ่น และวิธี deploy บน GitHub Pages/Netlify/Vercel หรือวิธีรันเซิร์ฟเวอร์ถ้าใช้ ASP.NET Core  
	EN: Short README describing local development and how to deploy to GitHub Pages/Netlify/Vercel or run a server if using ASP.NET Core
- TH: Test notes: accessibility checklist และ performance audit report  
	EN: Test notes: accessibility checklist and a performance audit report

- TH: ถ้ามีการใช้ ASP.NET Core MVC ให้แนบตัวอย่างคำสั่ง build & publish (`dotnet build`, `dotnet publish`) และตัวอย่าง `Dockerfile` ถ้าจำเป็น  
	EN: If using ASP.NET Core MVC, include sample build & publish commands (`dotnet build`, `dotnet publish`) and a sample `Dockerfile` if needed

## Notes / Clarifications made by author / หมายเหตุ
- TH: สเปคนี้ถูกย่อให้แสดงเพียงชื่อและอีเมลตามคำขอของผู้ใช้งาน
	EN: This spec is intentionally reduced to name + email per the user's request
- TH: ไม่มี [NEEDS CLARIFICATION] markers. ทำสมมติฐานข้างต้นเมื่อรายละเอียดไม่ระบุ
	EN: No [NEEDS CLARIFICATION] markers. Assumptions above apply where details are unspecified

