# Feature: สร้างหน้าเว็บบุคคลหน้าเดียว (ชื่อ + อีเมล)

**Feature Branch**: `1-create-personal-page`
**Created**: 2025-11-10
**Status**: Draft
**Input**: ผู้ใช้ต้องการหน้าเว็บส่วนตัวหน้าเดียวเพื่อแสดงเพียงชื่อและอีเมลติดต่อเท่านั้น ("สร้างหน้าเว็บบุคคล 1 หน้าเว็บ").

## User Scenarios & Testing *(mandatory)*

### User Story 1 - ผู้เข้าชมทั่วไป (Priority: P1)
ผู้เข้าชมต้องการเห็นชื่อและสามารถติดต่อผ่านอีเมลได้โดยง่าย

**Why this priority**: หน้านี้ถูกออกแบบให้เรียบง่ายที่สุด เพื่อให้ข้อมูลติดต่อพื้นฐานชัดเจนและลดเวลาการโหลด

**Independent Test**: เปิดหน้าเว็บจากมือถือและเดสก์ท็อป ตรวจสอบว่า:
1. ชื่อปรากฏชัดและอ่านง่าย
2. มีลิงก์อีเมลหรือปุ่มที่เปิด client อีเมล (mailto:) หรือแสดงวิธีการคัดลอกอีเมลที่ชัดเจน

**Acceptance Scenarios**:
1. Given: ผู้ใช้เปิดหน้าเว็บบนมือถือ, When: หน้าโหลดเสร็จ, Then: ผู้ใช้เห็นชื่อและช่องทางอีเมลภายใน 5–10 วินาที
2. Given: ผู้ใช้คลิกอีเมล, When: คลิก, Then: จะเปิด client อีเมลด้วยช่อง To ที่ตั้งค่าไว้ (หรือแสดงวิธีคัดลอกอีเมลถ้าไม่มี mailto)

---

### Edge Cases
- การเข้าถึงจากเครือข่ายช้าหรือบล็อกสคริปต์บุคคลที่สาม
- ฟอนต์ที่ไม่รองรับภาษาไทยต้องมี fallback

## Requirements *(mandatory)*

### Functional Requirements
- FR-001: เว็บไซต์ MUST แสดงชื่อของเจ้าของหน้าอย่างชัดเจน
- FR-002: เว็บไซต์ MUST แสดงอีเมลติดต่อที่ใช้งานได้ (mailto: หรือวิธีคัดลอกอีเมล)
- FR-003: เว็บไซต์ MUST โหลดและใช้งานได้บนมือถือ (responsive)
- FR-004: เว็บไซต์ MUST ปฏิบัติตามข้อกำหนด accessibility พื้นฐาน (semantic HTML, สามารถนำทางด้วยคีย์บอร์ด)
- FR-005: เว็บไซต์ SHOULD จำกัดการโหลดสคริปต์บุคคลที่สาม และ analytics ต้องเป็น opt-in

### Key Entities
- Owner: ข้อมูลเจ้าของหน้า (name)
- Contact: ช่องทางติดต่อหลัก (email)
- Asset: รูปภาพ (ถ้าใช้) และไฟล์ที่ใช้บนหน้า (มี alt, ขนาดเหมาะสม)

## Success Criteria *(mandatory)*

### Measurable Outcomes
- SC-001: ผู้ใช้ทั่วไปสามารถระบุชื่อได้ภายใน 5–10 วินาที (observational test)
- SC-002: อีเมลติดต่อสามารถใช้งานได้เมื่อทดสอบ (mailto: เปิดหรือสามารถคัดลอกอีเมลได้)
- SC-003: หน้าโหลดสำเร็จภายใน 3 วินาทีในเครือข่ายปกติ (measured via performance audit)
- SC-004: Accessibility checks ผ่านข้อกำหนดพื้นฐาน (เช่น ไม่มีภาพสำคัญที่ขาด alt, การนำทางด้วยคีย์บอร์ดทำงาน)
- SC-005: หน้าแรกมีขนาดรวม assets < 500KB เมื่อเป็นไปได้ (performance target)

## Assumptions
- โครงการเป็นหน้าเดียว ไม่จำเป็นต้องมี backend ซับซ้อน (static-first)
- อีเมลที่จะใช้เป็นช่องทางติดต่อเป็นอีเมลจริงที่เจ้าของหน้าเตรียมไว้
- ผู้ดูแลจะเป็นผู้อนุมัติ PR และตรวจสอบการทดสอบ accessibility

- หากต้องการใช้ ASP.NET Core MVC (.NET Core) ให้ถือเป็นตัวเลือกเสริม แต่ไม่จำเป็นสำหรับความต้องการขั้นต่ำนี้: หากใช้ต้องอธิบายการ build/publish ใน README และรักษาผลลัพธ์สุดท้ายให้ง่ายและเร็ว

## Constraints
- หลีกเลี่ยงเฟรมเวิร์กขนาดใหญ่หากหน้าเดียวเพียงพอ
- ต้องเลือกฟอนต์ที่รองรับภาษาไทยหรือมี fallback ที่เหมาะสม

- หากใช้ ASP.NET Core MVC ให้รักษาความเรียบง่าย: หลีกเลี่ยง middlewares และ dependencies ที่เพิ่ม overhead เกินจำเป็น และให้มีคำอธิบายการ build/publish ใน README

## Deliverables
- Static HTML/CSS/JS (หรือ SSG output) สำหรับหน้าเดียว แสดงเพียงชื่อและอีเมล
- README สั้นอธิบายการพัฒนาท้องถิ่น และวิธี deploy บน GitHub Pages/Netlify/Vercel หรือวิธีรันเซิร์ฟเวอร์ถ้าใช้ ASP.NET Core
- Test notes: accessibility checklist และ performance audit report

- ถ้ามีการใช้ ASP.NET Core MVC ให้แนบตัวอย่างคำสั่ง build & publish (`dotnet build`, `dotnet publish`) และตัวอย่าง `Dockerfile` ถ้าจำเป็น

## Notes / Clarifications made by author
- สเปคนี้ถูกย่อให้แสดงเพียงชื่อและอีเมลตามคำขอของผู้ใช้งาน
- ไม่มี [NEEDS CLARIFICATION] markers. ทำสมมติฐานข้างต้นเมื่อรายละเอียดไม่ระบุ
