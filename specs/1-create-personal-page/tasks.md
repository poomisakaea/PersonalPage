# Tasks for Feature: สร้างหน้าเว็บบุคคลหน้าเดียว (ชื่อ + อีเมล) / Single personal page (Name + Email)

**Feature**: Single personal page (Name + Email)
**Feature branch**: `1-create-personal-page`

**Description (EN)**: This tasks file is generated from the feature spec and implementation plan. Tasks are organized by phase and by user story (priority order). Each task is a single actionable item with an exact file path where the work should be done.

**คำอธิบาย (TH)**: ไฟล์งานนี้ถูกสร้างจากสเปคและแผนการใช้งาน แบ่งงานเป็นเฟสและตาม user story ตามลำดับความสำคัญ แต่ละงานเป็นขั้นตอนที่ชัดเจนพร้อมระบุเส้นทางไฟล์ที่จะต้องแก้ไข

---

## PHASE 1 — Setup (project initialization) | เฟส 1 — ติดตั้งเริ่มต้น (การเริ่มโปรเจค)

- [x] T001 **EN**: Create ASP.NET Core solution and web project at `src/PersonalPage/` | **TH**: สร้างโซลูชันและโปรเจค ASP.NET Core ที่ `src/PersonalPage/` — `src/PersonalPage/PersonalPage.csproj`
- [x] T002 [P] **EN**: Create repository README at `README.md` with build/run/publish summary and Azure hints | **TH**: สร้าง README ที่อธิบายการ build/run/publish และคำแนะนำการปรับใช้บน Azure — `README.md`
- [x] T003 [P] **EN**: Add `.gitignore` suitable for .NET projects | **TH**: เพิ่ม `.gitignore` ที่เหมาะสมกับโปรเจค .NET — `.gitignore`
- [x] T004 [P] **EN**: Add basic GitHub Actions CI workflow for .NET build at `.github/workflows/dotnet-ci.yml` (build + test) | **TH**: เพิ่ม workflow พื้นฐานของ GitHub Actions สำหรับการ build และทดสอบ .NET — `.github/workflows/dotnet-ci.yml`

## PHASE 2 — Foundational (blocking prerequisites for stories) | เฟส 2 — พื้นฐาน (งานที่ต้องทำก่อนเริ่ม story)

- [x] T005 [P] **EN**: Create project folder structure (Controllers, Models, Views, wwwroot/css, wwwroot/js, wwwroot/assets) | **TH**: สร้างโฟลเดอร์โครงสร้างโปรเจคตามที่ระบุ — `src/PersonalPage/`
- [x] T006 [P] **EN**: Implement Owner model (Name, Email properties with basic validation) | **TH**: สร้างโมเดล Owner พร้อมคุณสมบัติ Name, Email และการตรวจสอบพื้นฐาน — `src/PersonalPage/Models/Owner.cs`
- [x] T007 [P] **EN**: Add basic layout and home view stubs (_Layout.cshtml, Index.cshtml) | **TH**: เพิ่มโครงร่าง layout และ view หน้าแรกแบบ stub — `src/PersonalPage/Views/`
- [x] T008 [P] **EN**: Add core static assets (style.css and main.js, BEM-ready) | **TH**: เพิ่มไฟล์ assets พื้นฐาน เช่น CSS และ JS ตามแนว BEM — `src/PersonalPage/wwwroot/`
- [x] T009 [P] **EN**: Create xUnit test project with sample test | **TH**: สร้างโปรเจคทดสอบ xUnit พร้อมตัวอย่างเทสต์ — `tests/PersonalPage.Tests/`
- [x] T010 [P] **EN**: Add specs/docs placeholders (acceptance-checklist.md, deployment-notes.md) | **TH**: เพิ่มไฟล์ placeholder สำหรับ acceptance checklist และ deployment notes — `specs/1-create-personal-page/`

## PHASE 3 — User Story Implementation (priority order) | เฟส 3 — การพัฒนาแต่ละ User Story (เรียงตามลำดับความสำคัญ)

### User Story 1 (P1) | ผู้ใช้ Story 1 (ความสำคัญสูง)
**EN**: As a visitor I want to see the owner's name and be able to contact via email easily.
**TH**: ผู้เข้าชมต้องการเห็นชื่อเจ้าของและสามารถติดต่อทางอีเมลได้ง่าย

**Independent test | การทดสอบอิสระ**:
**EN**: Open `/` (home) on mobile and desktop and confirm name visible and email link or copy control works.
**TH**: เปิด `/` บนมือถือและเดสก์ท็อป ตรวจสอบว่าชื่อปรากฏและการคลิกอีเมลหรือการคัดลอกทำงาน

- [x] T011 [US1] **EN**: Implement HomeController to return Index view with Owner data | **TH**: สร้าง HomeController เพื่อส่งข้อมูล Owner ไปยัง Index view — `src/PersonalPage/Controllers/HomeController.cs`
- [x] T012 [US1] **EN**: Implement Owner data provider (hard-coded or config-based) | **TH**: สร้างบริการ OwnerProvider เพื่อคืนข้อมูล Owner — `src/PersonalPage/Services/OwnerProvider.cs`
- [x] T013 [US1] **EN**: Implement Index.cshtml to render name and email (mailto and copy-to-clipboard) | **TH**: เขียน view เพื่อแสดงชื่อและอีเมลพร้อม mailto และปุ่มคัดลอก — `src/PersonalPage/Views/Home/Index.cshtml`
- [x] T014 [US1] **EN**: Implement CSS (BEM) for mobile-first responsive layout and focus styles | **TH**: เขียน CSS แบบ BEM ให้เป็น mobile-first และมีสไตล์ focus ที่เข้าถึงได้ — `src/PersonalPage/wwwroot/css/style.css`
- [x] T015 [P] [US1] **EN**: Implement JavaScript for copy-email with Clipboard API and fallback | **TH**: เขียน JS สำหรับคัดลอกอีเมลโดยใช้ Clipboard API พร้อม fallback — `src/PersonalPage/wwwroot/js/main.js`
- [x] T016 [US1] **EN**: Add unit tests for Owner model validation | **TH**: เพิ่ม unit test สำหรับการตรวจสอบ Owner model — `tests/PersonalPage.Tests/OwnerTests.cs`
- [x] T017 [US1] **EN**: Add integration test (TestServer) to verify `/` returns 200 with name/email | **TH**: เพิ่ม integration test ที่เรียก `/` และตรวจสอบสถานะ 200 และเนื้อหา — `tests/PersonalPage.Tests/HomeIntegrationTests.cs`
- [x] T018 [US1] **EN**: Add acceptance checklist for US1 with test steps (mobile/desktop, mailto, copy) | **TH**: เพิ่มไฟล์ acceptance checklist พร้อมขั้นตอนทดสอบ — `specs/1-create-personal-page/acceptance-checklist.md`

## PHASE 4 — Polish & Cross-cutting Concerns | เฟส 4 — งานปรับแต่งและข้ามฟังก์ชัน

- [x] T019 [P] **EN**: Add accessibility fixes and checks (ARIA, keyboard, focus) | **TH**: ทำการปรับปรุง accessibility และบันทึกเป็นเอกสาร — `specs/1-create-personal-page/accessibility-notes.md`
- [x] T020 [P] **EN**: Add performance tuning (inline critical CSS, keep assets < 500KB) | **TH**: ปรับแต่งประสิทธิภาพและบันทึกผล — `specs/1-create-personal-page/performance-report.md`
- [x] T021 [P] **EN**: Create Azure deployment workflow (GitHub Actions) for App Service publish | **TH**: สร้าง workflow สำหรับปรับใช้ไปยัง Azure App Service — `.github/workflows/deploy-azure.yml`
- [x] T022 [P] **EN**: Add optional Dockerfile for App Service for Containers option | **TH**: เพิ่ม Dockerfile สำหรับตัวเลือกคอนเทนเนอร์ — `src/PersonalPage/Dockerfile`
- [x] T023 [P] **EN**: Add deployment docs with `az` CLI examples and GitHub Actions secrets | **TH**: เพิ่มเอกสารคำสั่ง `az` ตัวอย่างและการตั้งค่าสำหรับ GitHub Actions — `docs/deploy-azure.md`
- [x] T024 [P] **EN**: Polish final README with local dev, build, publish, and Azure notes | **TH**: ปรับปรุง README ให้สมบูรณ์ — `README.md`

---

## DEPENDENCIES & EXECUTION ORDER | ลำดับการขึ้นต่อกันและการดำเนินการ

**EN**: US1 depends on PHASE 1 tasks (T001-T004) and PHASE 2 foundational tasks (T005-T010) being completed first. CI/CD and deployment (T021-T023) depend on a successful build and passing tests (T009, T016, T017).

**TH**: US1 ขึ้นต่อกับ T001-T010 ต้องเสร็จก่อน งานปรับใช้ขึ้นต่อกับการ build และเทสต์ที่ผ่าน

### Parallel Execution Examples | ตัวอย่างงานที่ทำพร้อมกันได้

**EN**:
- T002, T003 can be done while T001 creates the project
- T005, T006, T008 can be done in parallel (different files, no dependencies)
- T014, T015 can be worked on in parallel after T013 view is ready
- T016, T017 tests can run in parallel once foundational code is in place

**TH**:
- ขณะทำ T001, T002 และ T003 สามารถทำพร้อมกันได้
- สร้างโฟลเดอร์ เพิ่ม assets และสร้างโมเดล Owner (T005, T006, T008) สามารถทำพร้อมกันได้
- CSS และ JS (T014, T015) สามารถทำพร้อมกันหลังมี view template
- เทสต์ (T016, T017) สามารถรันพร้อมกันได้เมื่อโค้ดพื้นฐานพร้อม

---

## IMPLEMENTATION STRATEGY (MVP First) | กลยุทธ์การใช้งาน (เริ่มจาก MVP)

**EN**:
- **MVP scope**: Implement only US1 (T011-T018) to show owner's name and working email. Keep minimal: server-rendered view with hard-coded or config-based Owner data.
- **Iteration 1 (MVP)**: Complete T001-T010 (setup + foundational) + T011-T015 (rendering + basic UI). Run CI build to ensure it compiles.
- **Iteration 2**: T016-T018 (unit/integration tests) + T019-T020 (accessibility & performance fixes).
- **Iteration 3**: T021-T023 (deployment CI/CD + Docker optional) and T024 (README polish).

**TH**:
- **ขอบเขต MVP**: ทำแค่ US1 (T011-T018) เพื่อแสดงชื่อและอีเมล เก็บข้อมูล Owner แบบ hard-coded หรือ config
- **รอบแรก (MVP)**: ทำ T001-T015 พร้อมรัน CI
- **รอบสอง**: เทสต์และปรับปรุง (T016-T020)
- **รอบสุดท้าย**: การปรับใช้และเอกสาร (T021-T024)

---

## SUMMARY | สรุป

- **Total tasks**: 24 (TH: จำนวนงานรวม 24)
- **US1 (User Story 1)**: 8 tasks (T011-T018) (TH: 8 งาน)
- **Setup/Foundation/Polish**: 16 tasks (T001-T010, T019-T024) (TH: 16 งาน)
- **Parallel opportunities**: T002, T003, T005, T006, T008, T009, T015, T016, T017, T019-T024 (TH: งานที่ทำพร้อมกันได้)

---

## INDEPENDENT TEST CRITERIA (per story) | เกณฑ์การทดสอบอิสระ (ต่อแต่ละ story)

### User Story 1 | User Story 1

**EN**: 
1. Open `/` on mobile and desktop and verify:
   - Owner name is clearly visible and readable
   - Email is present and clicking opens mail client (mailto:) or copy control works
   - Keyboard navigation focuses the email control and pressing Enter activates link or copy
2. Automated tests: Integration test (T017) must assert HTTP 200 and response contains configured Owner name and email

**TH**:
1. เปิด `/` บนอุปกรณ์ต่าง ๆ และตรวจสอบ:
   - ชื่อปรากฏชัดเจนและอ่านได้
   - อีเมลอยู่และการคลิกเปิด mail client หรือคัดลอกได้
   - การนำทางด้วยคีย์บอร์ดทำงานกับคอนโทรลอีเมล
2. เทสต์ integration ต้องตรวจสอบ HTTP 200 และเนื้อหาชื่อ/อีเมล

---

## MVP RECOMMENDATION | ข้อเสนอ MVP

**EN**: Implement only US1 (T011-T018) for MVP. All other tasks are polish, accessibility, performance, and deployment—these can follow once MVP is green.

**TH**: แนะนำเริ่มจาก US1 เท่านั้นเป็น MVP งานอื่นเป็นการปรับปรุงและเอกสาร ทำได้หลังจาก MVP ผ่าน

---

## FORMAT VALIDATION | การยืนยันรูปแบบ

**EN**: All tasks follow the required checklist format: `- [ ] TNNN [P]? [USX]? Description | TH: Description — file path`

**TH**: งานทั้งหมดปฏิบัติตามรูปแบบ checklist ที่กำหนด

---

Generated by speckit.tasks on behalf of the feature `specs/1-create-personal-page` (bilingual TH/EN).