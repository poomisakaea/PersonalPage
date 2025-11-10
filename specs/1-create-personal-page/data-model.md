# เอกสารโมเดลข้อมูล | Data Model Documentation

## เอนทิตี้หลัก | Core Entities

### เอนทิตี้เจ้าของ | Owner Entity
```typescript
interface Owner {
  name: string;        // TH: ชื่อที่แสดงของเจ้าของหน้าเว็บ | EN: Display name of the page owner
  email: string;       // TH: อีเมลสำหรับติดต่อ | EN: Contact email address
}
```

### เอนทิตี้ทรัพยากร (ตัวเลือก) | Asset Entity (Optional)
```typescript
interface Asset {
  type: 'image' | 'font' | 'style';
  path: string;       // TH: เส้นทางสัมพัทธ์ไปยังทรัพยากร | EN: Relative path to the asset
  size: number;       // TH: ขนาดไฟล์เป็นไบต์ | EN: File size in bytes
  metadata?: {        // TH: ข้อมูลเพิ่มเติม (ตัวเลือก) | EN: Optional metadata
    alt?: string;     // TH: ข้อความทดแทนสำหรับรูปภาพ | EN: Alt text for images
    width?: number;   // TH: ความกว้างเดิมของรูปภาพ | EN: Original width for images
    height?: number;  // TH: ความสูงเดิมของรูปภาพ | EN: Original height for images
    format?: string;  // TH: รูปแบบไฟล์ | EN: File format
  }
}
```

## การไหลของข้อมูล | Data Flow

1. การโหลดข้อมูลแบบคงที่ | Static Data Loading
   TH:
   - ข้อมูลเจ้าของโหลดจาก HTML แบบคงที่
   - ทรัพยากรถูกโหลดล่วงหน้าตามความสำคัญ

   EN:
   - Owner information loaded from static HTML
   - Assets preloaded based on importance

2. การโต้ตอบกับอีเมล | Email Interaction
   TH:
   - การจัดการลิงก์ mailto:
   - การแสดงที่อยู่อีเมลพร้อมฟังก์ชันคัดลอก

   EN:
   - mailto: link handling
   - Email address display with copy functionality

## กฎการตรวจสอบความถูกต้อง | Validation Rules

### ข้อมูลเจ้าของ | Owner Data
TH:
- ชื่อ: จำเป็นต้องมี, ต้องไม่เป็นข้อความว่าง
- อีเมล: จำเป็นต้องมี, ต้องเป็นรูปแบบอีเมลที่ถูกต้อง

EN:
- Name: Required, non-empty string
- Email: Required, valid email format

### ทรัพยากร | Assets
TH:
- รูปภาพ: ต้องมีข้อความทดแทน (alt text)
- ขนาดรวม: ต้องอยู่ภายในงบประมาณ 500KB
- ฟอนต์: ต้องรองรับตัวอักษรภาษาไทย

EN:
- Images: Must have alt text
- Total size: Must fit within 500KB budget
- Fonts: Must support Thai characters

## การจัดการสถานะ | State Management

นี่เป็นหน้าเว็บแบบคงที่ที่มีสถานะน้อยที่สุด | This is a static page with minimal state:

### สถานะการโหลดหน้า | Page Load State
TH:
- เริ่มต้น: กำลังโหลดทรัพยากร
- พร้อม: แสดงเนื้อหา
- ผิดพลาด: การโหลดล้มเหลว (จัดการผ่าน error boundaries)

EN:
- Initial: Loading assets
- Ready: Content displayed
- Error: Load failure (handled via error boundaries)

### สถานะการโต้ตอบกับอีเมล | Email Interaction State
TH:
- ค่าเริ่มต้น: โหมดแสดงผล
- กำลังคัดลอก: การตอบสนองแบบภาพระหว่างคัดลอก
- คัดลอกแล้ว: การตอบสนองเมื่อสำเร็จ
- ผิดพลาด: การตอบสนองเมื่อคัดลอกล้มเหลว

EN:
- Default: Display mode
- Copying: Visual feedback during copy
- Copied: Success feedback
- Error: Copy failure feedback

## การจัดเก็บ | Storage

TH: ข้อมูลทั้งหมดถูกจัดเก็บแบบคงที่ในไฟล์ HTML/CSS/JS ไม่จำเป็นต้องใช้ฐานข้อมูลหรือพื้นที่จัดเก็บในเครื่อง

EN: All data is stored statically in the HTML/CSS/JS files. No database or local storage required.