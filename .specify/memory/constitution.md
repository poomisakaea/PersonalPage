<!--
Sync Impact Report

Version change: unknown -> 1.0.0

Modified principles:
- (new) PRINCIPLE_1 -> ชัดเจนและกระชับ / Clear & Concise
- (new) PRINCIPLE_2 -> มือถือเป็นอันดับแรก (Responsive) / Mobile-first
- (new) PRINCIPLE_3 -> การเข้าถึง (Accessibility) / Accessibility
- (new) PRINCIPLE_4 -> ประสิทธิภาพและความเป็นส่วนตัว / Performance & Privacy
- (new) PRINCIPLE_5 -> ความเรียบง่ายและการบำรุงรักษา / Simplicity & Maintainability

Added sections:
- ข้อจำกัดทางเทคนิค / Technical Constraints
- กระบวนการพัฒนา / Development Process

Removed sections: none

Templates requiring updates:
- .specify/templates/plan-template.md: ✅ aligned (no edit required)
- .specify/templates/spec-template.md: ✅ aligned (no edit required)
- .specify/templates/tasks-template.md: ✅ aligned (no edit required)
- .specify/templates/checklist-template.md: ✅ aligned (no edit required)
- .specify/templates/agent-file-template.md: ✅ aligned (no edit required)

Follow-up TODOs:
- RATIFICATION_DATE set to adoption date (2025-11-10). No deferred placeholders remain.
-->

# รัฐธรรมนูญ: หน้าเว็บบุคคล  
# Constitution: Personal Page

## Core Principles / หลักการหลัก

### ชัดเจนและกระชับ | Clear & Concise
TH: ทุกหน้าต้อง "ต้อง" ถ่ายทอดข้อมูลสำคัญให้เห็นได้ทันที: ชื่อ (หรือชื่อที่ใช้งาน), บทบาท/คำอธิบายสั้น ๆ, วิธีติดต่อที่ชัดเจน และลิงก์สำคัญ (เช่น CV, โซเชียลหลัก, โปรเจคตัวอย่าง). ข้อมูลต้องเรียงลำดับตามลำดับความสำคัญและไม่เกินความจำเป็นเพื่อรักษาความเข้าใจได้ง่าย.

EN: Every page MUST convey the essential information immediately: display name (or preferred name), role/short description, a clear contact method, and primary links (e.g., CV, main social, sample projects). Content should be ordered by importance and kept to the minimum necessary for quick comprehension.

เหตุผล | Rationale:
TH: หน้าเดียวต้องทำหน้าที่เป็นบัตรแนะนำตัวที่อ่านเข้าใจได้ภายใน 5–10 วินาที.
EN: A single page should act as a business-card-style summary that is readable within 5–10 seconds.

### มือถือเป็นอันดับแรก (Responsive) | Mobile-first
TH: เนื้อหาทุกชิ้น "ต้อง" แสดงผลได้ดีบนหน้าจอมือถือด้วยการจัดวางที่ตอบสนองและการปรับขนาดภาพ/ตัวอักษร. การทดสอบบนมือถือ (viewport ขนาดต่าง ๆ) ต้องถูกรันก่อนปล่อยเวอร์ชันใหม่.

EN: Content MUST render well on mobile screens using responsive layout and appropriately scaled images/typography. Mobile viewport testing across sizes should be performed before release.

เหตุผล | Rationale:
TH: ผู้ชมส่วนใหญ่เข้าจากมือถือ การออกแบบ mobile-first ลดงานแก้ไขซ้ำและปรับปรุงประสบการณ์ผู้ใช้.
EN: Majority of visitors come from mobile; mobile-first reduces rework and improves UX.

### การเข้าถึง (Accessibility) | Accessibility
TH: เว็บไซต์ "ต้อง" ปฏิบัติตามแนวทางพื้นฐานของการเข้าถึง: โครงสร้าง HTML เชิงความหมาย, ข้อความสำรอง (alt) สำหรับภาพ, คอนทราสต์สีที่เพียงพอ, สามารถนำทางด้วยคีย์บอร์ด, และมีโครงร่างมุมมองสำหรับเครื่องช่วยอ่าน (screen readers). ทุกหน้าที่เผยแพร่ "ต้อง" ผ่านการตรวจสอบด้วยเครื่องมือ accessibility ขั้นพื้นฐาน.

EN: The site MUST follow core accessibility guidelines: semantic HTML structure, alt text for images, sufficient color contrast, keyboard navigability, and screen-reader-friendly structure. Every published page MUST pass basic accessibility tooling checks.

เหตุผล | Rationale:
TH: การเข้าถึงเป็นข้อบังคับด้านสากลที่เพิ่มผู้ชมและลดข้อร้องเรียน.
EN: Accessibility broadens the audience and reduces potential complaints.

### ประสิทธิภาพและความเป็นส่วนตัว | Performance & Privacy
TH: หน้าเว็บ "ต้อง" มีขนาดเล็ก โหลดเร็ว (เป้าหมาย: <1MB โดยรวมสำหรับหน้าเริ่มต้นเมื่อเป็นไปได้) และจำกัดการโหลดสคริปต์ของบุคคลที่สาม. การติดตาม (analytics) ต้องเป็นแบบ opt-in หรือปิดโดยค่าเริ่มต้น; หากมีสคริปต์จากภายนอกให้ระบุเหตุผลและประเมินความเสี่ยงด้านความเป็นส่วนตัว.

EN: Pages SHOULD be small and fast (goal: <1MB total for initial page where feasible) and minimize third-party scripts. Analytics must be opt-in or disabled by default; any external scripts must be justified and privacy risk-assessed.

เหตุผล | Rationale:
TH: ประสิทธิภาพช่วยประสบการณ์ผู้ใช้และ SEO; ความเป็นส่วนตัวเป็นมาตรฐานที่ดีต่อผู้เยี่ยมชม.
EN: Performance improves UX and SEO; privacy is a best practice for visitors.

### ความเรียบง่ายและการบำรุงรักษา | Simplicity & Maintainability
TH: ซอร์สโค้ด "ต้อง" อยู่ภายใต้การควบคุมเวอร์ชัน (เช่น Git) และมีไฟล์ README สั้น ๆ สำหรับขั้นตอนการพัฒนา/ดีพลอย. การเปลี่ยนแปลงเนื้อหาเล็กน้อยควรทำได้ด้วยการแก้ไฟล์ข้อความง่าย ๆ ไม่จำเป็นต้องใช้งานหนักของระบบ. เวอร์ชันของเอกสาร/เนื้อหาใช้ MAJOR.MINOR.PATCH สำหรับการเปลี่ยนแปลงที่ชัดเจน.

EN: Source must be version-controlled (e.g., Git) with a short README for local development/publishing. Small content edits should be simple text-file changes without heavy tooling. Use MAJOR.MINOR.PATCH for content/document versioning.

เหตุผล | Rationale:
TH: ความเรียบง่ายลดภาระบำรุงรักษาและทำให้การอัพเดตปลอดภัยและรวดเร็ว.
EN: Simplicity reduces maintenance overhead and speeds safe updates.

## ข้อจำกัดทางเทคนิค | Technical Constraints
TH: เทคโนโลยีพื้นฐานต้องเป็นไปเพื่อรองรับหลักการข้างต้น:

- โครงสร้าง: Static-first (HTML/CSS/JS) หรือ SSG (เช่น eleventy, Hugo) ถ้ามีความจำเป็น
- ห้ามใช้เฟรมเวิร์กขนาดใหญ่โดยไม่มีเหตุผล (เช่น แค่เพื่อหน้าเดียว) เว้นแต่จะมีข้อดีชัดเจน
- รูปภาพต้องถูกบีบอัดและให้ขนาดที่เหมาะสม (responsive images)
- ฟอนต์เว็บ: เลือกฟอนต์ที่รองรับภาษาไทยและโหลดแบบ performance-conscious (prefetch/preload เมื่อเหมาะสม)
- การทดสอบ: lint (HTML/CSS/JS), accessibility check และ performance audit เป็นขั้นตอนใน pipeline ก่อน deploy

EN: The technology choices MUST support the above principles:

- Structure: Static-first (HTML/CSS/JS) or SSG (e.g., eleventy, Hugo) when appropriate
- Avoid large frameworks without justification (e.g., for a single page)
- Images should be optimized and responsive
- Web fonts: prefer fonts that support Thai; load performance-conscious (prefetch/preload as appropriate)
- Testing: include linting (HTML/CSS/JS), accessibility checks, and performance audits in the pipeline prior to deploy

## กระบวนการพัฒนา | Development Process

TH:
- Workflow: ทุกการเปลี่ยนแปลงเข้าผ่าน Pull Request (หรือ commit ที่มีประวัติชัดเจนถ้าเป็นโครงการส่วนตัว)
- Review: เจ้าของโครงการ (หรือผู้ดูแลที่ได้รับมอบหมาย) ต้องตรวจสอบและอนุมัติ PR ก่อน merge
- Quality gates: PR ต้องผ่าน linter, basic accessibility check, และตรวจสอบภาพ/ขนาดโหลด
- Deployment: แนะนำเป็น static host (GitHub Pages, Netlify, Vercel) พร้อม rollback ง่าย

EN:
- Workflow: Changes are made via Pull Requests (or clear commit history for a private repo)
- Review: Project owner (or assigned maintainer) must review and approve PRs before merging
- Quality gates: PRs should pass linter, basic accessibility checks, and asset/size review
- Deployment: Prefer static hosts (GitHub Pages, Netlify, Vercel) with easy rollback

## Governance / การปกครอง

TH:
- การแก้ไข: การแก้ไขต้องทำเป็น Pull Request พร้อมคำอธิบายเหตุผลและรายการผลกระทบ. เจ้าของโครงการต้องอนุมัติการเปลี่ยนแปลงเพื่อให้มีผลบังคับ.
- นโยบายการขึ้นเวอร์ชัน:
	- MAJOR: เมื่อลบหรือเปลี่ยนแปลงหลักการในเชิงปฏิบัติที่ทำให้ไม่เข้ากันกับนโยบายเดิม (breaking governance changes).
	- MINOR: เมื่อตั้งหลักการใหม่หรือขยายคำแนะนำอย่างมีนัยสำคัญ.
	- PATCH: การแก้ไขคำอธิบาย คำสะกด หรือชี้แจงที่ไม่เปลี่ยนแก่นสาร.
- การตรวจสอบการปฏิบัติตาม: ทุกแผน/feature ที่ใช้ template ต้องรวมส่วน "Constitution Check" ซึ่งระบุการทดสอบ/กฎที่ถูกต้องตามหลักการ (เช่น accessibility, mobile-first, privacy).
- ความรับผิดชอบ: เจ้าของโครงการเป็นผู้รับผิดชอบสูงสุดในการตีความและบังคับใช้รัฐธรรมนูญ แต่การปฏิบัติตามควรถูกตรวจสอบโดยเครื่องมืออัตโนมัติเมื่อเป็นไปได้.

EN:
- Changes: Amendments must be made via Pull Request with rationale and impact notes. Project owner must approve changes for them to take effect.
- Versioning policy:
	- MAJOR: When removing or changing principles in a breaking way.
	- MINOR: When adding new principles or significant extensions.
	- PATCH: Editorial fixes, spelling, or clarifications that do not change substance.
- Compliance checks: Every plan/feature using the templates must include a "Constitution Check" that documents tests/rules for compliance (e.g., accessibility, mobile-first, privacy).
- Responsibility: The project owner is ultimately responsible for interpretation and enforcement; automated tooling should be used where possible to check compliance.

**Version**: 1.0.0 | **Ratified**: 2025-11-10 | **Last Amended**: 2025-11-10

