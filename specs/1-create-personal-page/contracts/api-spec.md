# สัญญา API | API Contracts

TH: เนื่องจากนี่เป็นเว็บไซต์แบบคงที่ที่แสดงเพียงชื่อและอีเมล จึงไม่จำเป็นต้องมีจุดเชื่อมต่อ API สำหรับการใช้งานพื้นฐาน

EN: Since this is a static website showing only name and email, there are no API endpoints required for the basic implementation.

## จุดเชื่อมต่อ ASP.NET Core MVC (ตัวเลือก) | ASP.NET Core MVC Endpoints (Optional)

TH: หากใช้ตัวเลือก ASP.NET Core MVC จะมีจุดเชื่อมต่อขั้นต่ำดังนี้:

EN: If using the ASP.NET Core MVC option, these would be the minimal endpoints:

```yaml
openapi: 3.0.0
info:
  title: Personal Page API
  version: 1.0.0
  description: Simple API for personal page

paths:
  /:
    get:
      summary: Get personal page | ดึงหน้าส่วนตัว
      description: Returns the main page with owner information | ส่งคืนหน้าหลักพร้อมข้อมูลเจ้าของ
      responses:
        '200':
          description: Successful response | การตอบสนองสำเร็จ
          content:
            text/html:
              schema:
                type: string
        '500':
          description: Server error | ข้อผิดพลาดของเซิร์ฟเวอร์
          content:
            application/json:
              schema:
                type: object
                properties:
                  error:
                    type: string

components:
  schemas:
    Owner:
      type: object
      required:
        - name
        - email
      properties:
        name:
          type: string
          description: Owner's display name | ชื่อที่แสดงของเจ้าของ
        email:
          type: string
          format: email
          description: Owner's contact email | อีเมลติดต่อของเจ้าของ
```

Note: For the static implementation, no API endpoints are needed. This API specification is only relevant if choosing the optional ASP.NET Core MVC implementation.