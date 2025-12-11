# EcommerceAuth API

## 1️⃣ المتطلبات

- Visual Studio 2022 أو أحدث  
- .NET 7 SDK  
- SQL Server LocalDB أو أي نسخة SQL Server  
- Gmail account (لو هتستخدموا EmailSettings)  
- Google OAuth Client (لو هتستخدموا Google Authentication)  

---

## 2️⃣ تجهيز Environment Variables

قبل ما تشغّلوا المشروع، لازم تضيفوا القيم الحقيقية لكل Secret على جهازكم.

### **على Windows:**

1. افتحوا **Start → Environment Variables → Edit the system environment variables → Environment Variables…**
2. تحت **User variables** اضغطوا **New** لكل متغير:

| Variable Name           | Example Value |
|-------------------------|---------------|
| `JWT_KEY`               | 8dfb965a2a4f4b26840959c6688a043e |
| `EMAIL_ADDRESS`         | |
| `EMAIL_PASSWORD`        | your_email_app_password |
| `GOOGLE_CLIENT_ID`      | your_google_client_id.apps.googleusercontent.com |
| `GOOGLE_CLIENT_SECRET`  | your_google_client_secret |

> 💡 ملاحظة: App password للإيميل مهم لو هتستخدموا SMTP Gmail، مش الباسورد العادي.

---

## 3️⃣ تشغيل المشروع

1. افتحوا المشروع في Visual Studio  
2. اضغطوا **Run** (F5)  
3. المشروع هيشتغل على `https://localhost:7016`  

> 🔹 الـ `appsettings.json` تم إعدادها لاستخدام Environment Variables، فلازم تكون كل المتغيرات موجودة على جهازكم.

---

## 4️⃣ ملاحظات

- **لا ترفعوا أي Secrets على GitHub.**  
- أي متغير جديد لازم تضيفوه كـ Environment Variable بدل ما تحطوه في `appsettings.json`.  
- لو المشروع محتاج أي تحديث للـ Secrets، كل واحد يحدّث Environment Variables عنده.  

---

## 5️⃣ الاتصال بقاعدة البيانات

`appsettings.json` موجود فيه:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-MS535M4\\SQLEXPRESS;Database=EcommerceAuthDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
