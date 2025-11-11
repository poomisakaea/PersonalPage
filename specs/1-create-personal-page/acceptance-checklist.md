# Acceptance Checklist for User Story 1 | รายการตรวจยืนยันสำหรับ User Story 1

**User Story**: As a visitor I want to see the owner's name and be able to contact via email easily.
**TH**: ผู้เข้าชมต้องการเห็นชื่อเจ้าของและสามารถติดต่อทางอีเมลได้ง่าย

---

## Manual Testing | การทดสอบด้วยตนเอง

### Mobile Testing (< 768px) | ทดสอบบนมือถือ

- [ ] Open application on smartphone (iPhone, Android, or mobile browser)
  - [ ] TH: เปิดแอปพลิเคชันบนโทรศัพท์สมาร์ท
  
- [ ] Name is clearly visible and readable
  - [ ] TH: ชื่อปรากฏชัดเจนและอ่านได้
  - Expected: Large, dark text on white background, no overflow
  - TH: คาดหวัง: ข้อความขนาดใหญ่สีเข้มบนพื้นหลังขาว ไม่มีการล้นจอ

- [ ] Email link (mailto:) works
  - [ ] TH: ลิงก์อีเมล (mailto:) ทำงาน
  - Expected: Clicking email opens mail application with "To" field pre-filled
  - TH: คาดหวัง: การคลิกอีเมลเปิด mail application พร้อมเติมช่อง "To"

- [ ] Copy button is visible and clickable
  - [ ] TH: ปุ่มคัดลอกปรากฏและคลิกได้
  - Expected: Button displayed next to email, responds to tap
  - TH: คาดหวัง: ปุ่มแสดงอยู่ข้างอีเมล ตอบสนองต่อการแตะ

- [ ] Copy button works
  - [ ] TH: ปุ่มคัดลอกทำงาน
  - Expected: Clicking copies email to clipboard, shows "Copied" feedback for 2 seconds
  - TH: คาดหวัง: การคลิกคัดลอกอีเมลไปยังคลิปบอร์ด แสดง "Copied" เป็นเวลา 2 วินาที

- [ ] Layout is responsive (no horizontal scroll, text readable)
  - [ ] TH: เลย์เอาต์ตอบสนอง (ไม่มีการเลื่อนในแนวนอน ข้อความอ่านได้)
  - Expected: Content fits within viewport, no overflow, touch targets > 44px
  - TH: คาดหวัง: เนื้อหาพอดีกับวิวพอร์ต ไม่มีการล้น touch targets > 44px

### Desktop Testing (≥ 768px) | ทดสอบบนเดสก์ท็อป

- [ ] Open application on desktop (1280x800 or larger)
  - [ ] TH: เปิดแอปพลิเคชันบนเดสก์ท็อป

- [ ] Name is prominently displayed
  - [ ] TH: ชื่อแสดงเด่นชัด
  - Expected: Large heading (2.5rem+), centered or left-aligned with good whitespace
  - TH: คาดหวัง: ส่วนหัวขนาดใหญ่ จัดตำแหน่งที่ดี มีพื้นที่ว่าง

- [ ] Email and copy button are functional
  - [ ] TH: อีเมลและปุ่มคัดลอกทำงาน
  - Expected: Same as mobile

- [ ] Layout is centered and well-proportioned
  - [ ] TH: เลย์เอาต์จัดตำแหน่งที่ดี
  - Expected: Card component centered on page, max-width 600px, consistent padding
  - TH: คาดหวัง: องค์ประกอบการ์ดจัดตำแหน่งที่ตรงกลาง max-width 600px

### Keyboard Navigation | การนำทางด้วยคีย์บอร์ด

- [ ] Tab key cycles through interactive elements
  - [ ] TH: คีย์ Tab วนรอบองค์ประกอบโต้ตอบ
  - Expected: Email link focused first, then copy button
  - TH: คาดหวัง: โฟกัสลิงก์อีเมลก่อน จากนั้นปุ่มคัดลอก

- [ ] Shift + Tab reverses focus order
  - [ ] TH: Shift + Tab ย้อนกลับลำดับโฟกัส
  - Expected: Focus moves backward through elements
  - TH: คาดหวัง: โฟกัสเลื่อนย้อนกลับผ่านองค์ประกอบ

- [ ] Enter key activates email link (opens mail client)
  - [ ] TH: คีย์ Enter เปิดใช้ลิงก์อีเมล
  - Expected: Same as clicking email link
  - TH: คาดหวัง: เหมือนการคลิกลิงก์อีเมล

- [ ] Space or Enter key activates copy button
  - [ ] TH: คีย์ Space หรือ Enter เปิดใช้ปุ่มคัดลอก
  - Expected: Same as clicking copy button
  - TH: คาดหวัง: เหมือนการคลิกปุ่มคัดลอก

- [ ] Focus indicators are visible
  - [ ] TH: ตัวบ่งชี้โฟกัสมองเห็นได้
  - Expected: Focused elements have clear outline or highlight (2px solid blue)
  - TH: คาดหวัง: องค์ประกอบโฟกัสมี outline ที่ชัดเจน

### Email Functionality | ฟังก์ชันอีเมล

- [ ] Email address is valid format
  - [ ] TH: ที่อยู่อีเมลเป็นรูปแบบที่ถูกต้อง
  - Expected: Matches standard email pattern (name@domain.ext)
  - TH: คาดหวัง: ตรงกับรูปแบบอีเมลมาตรฐาน

- [ ] Mailto link opens default mail client
  - [ ] TH: ลิงก์ mailto เปิด mail client ค่าเริ่มต้น
  - Expected: Mail client (Outlook, Gmail, Mail.app, etc.) opens with "To" pre-filled
  - TH: คาดหวัง: mail client เปิดพร้อมเติม "To"

- [ ] Copy to clipboard works on all browsers
  - [ ] TH: คัดลอกไปยังคลิปบอร์ดทำงานบนเบราว์เซอร์ทั้งหมด
  - Expected: Tested on Chrome, Firefox, Safari, Edge
  - TH: คาดหวัง: ทดสอบบน Chrome Firefox Safari Edge

---

## Automated Testing | การทดสอบอัตโนมัติ

### Unit Tests | เทสต์หน่วย

- [ ] Owner model validates non-empty name
  - [ ] TH: โมเดล Owner ตรวจสอบชื่อ
  - Test: `OwnerTests.cs` → `TestOwnerNameRequired()`
  
- [ ] Owner model validates email format
  - [ ] TH: โมเดล Owner ตรวจสอบรูปแบบอีเมล
  - Test: `OwnerTests.cs` → `TestOwnerEmailValid()`

### Integration Tests | เทสต์การรวม

- [ ] GET `/` returns HTTP 200
  - [ ] TH: GET `/` ส่งกลับ HTTP 200
  - Test: `HomeIntegrationTests.cs` → `TestHomePageReturns200()`

- [ ] Response contains owner name
  - [ ] TH: การตอบสนองมีชื่อเจ้าของ
  - Test: `HomeIntegrationTests.cs` → `TestHomePageContainsOwnerName()`

- [ ] Response contains owner email
  - [ ] TH: การตอบสนองมีอีเมลเจ้าของ
  - Test: `HomeIntegrationTests.cs` → `TestHomePageContainsOwnerEmail()`

- [ ] Response HTML is valid
  - [ ] TH: HTML การตอบสนองถูกต้อง
  - Test: Run W3C HTML Validator on response

---

## Performance & Accessibility | ประสิทธิภาพและการเข้าถึง

- [ ] Page load time < 3 seconds
  - [ ] TH: เวลาโหลดหน้า < 3 วินาที
  - Tool: Chrome DevTools Lighthouse

- [ ] Lighthouse accessibility score ≥ 90/100
  - [ ] TH: คะแนน accessibility Lighthouse ≥ 90/100
  - Tool: Chrome DevTools Lighthouse

- [ ] Lighthouse performance score ≥ 85/100
  - [ ] TH: คะแนน performance Lighthouse ≥ 85/100
  - Tool: Chrome DevTools Lighthouse

- [ ] WCAG 2.1 AA compliance verified
  - [ ] TH: ยืนยันการทำตามข้อกำหนด WCAG 2.1 AA
  - Tool: axe DevTools Browser Extension

---

## Sign-Off | ลงนาม

- [ ] All manual tests passed
  - [ ] TH: ทดสอบด้วยตนเองทั้งหมดผ่าน
  
- [ ] All automated tests passed
  - [ ] TH: เทสต์อัตโนมัติทั้งหมดผ่าน
  
- [ ] Product Owner approved
  - [ ] TH: เจ้าของผลิตภัณฑ์อนุมัติ

**Date Completed | วันที่เสร็จสิ้น**: _______________

**Tester Name | ชื่อผู้ทดสอบ**: _______________

**Notes | หมายเหตุ**:
