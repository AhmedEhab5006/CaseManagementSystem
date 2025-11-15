using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastrcuture.Migrations
{
    /// <inheritdoc />
    public partial class AddLitigantCrime1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContractTemplates",
                keyColumn: "id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "Content",
                value: "<!DOCTYPE html>\r\n<html lang=\"ar\">\r\n<head>\r\n<meta charset=\"UTF-8\">\r\n<title>عقد إيجار</title>\r\n<style>\r\n    body {\r\n        direction: rtl; /* الكتابة من اليمين لليسار */\r\n        font-family: 'Arial', sans-serif;\r\n        background-color: #f9f9f9;\r\n        display: flex;\r\n        justify-content: center;\r\n        align-items: center;\r\n        height: 100vh;\r\n        margin: 0;\r\n    }\r\n\r\n    .paper {\r\n        background-color: white;\r\n        width: 800px;\r\n        padding: 40px;\r\n        box-shadow: 0 0 20px rgba(0,0,0,0.2);\r\n        border: 1px solid #ccc;\r\n    }\r\n\r\n    h1 {\r\n        text-align: center;\r\n        margin-bottom: 40px;\r\n    }\r\n\r\n    p {\r\n        font-size: 18px;\r\n        line-height: 1.8;\r\n        margin: 20px 0;\r\n    }\r\n\r\n    input {\r\n        border: none;\r\n        border-bottom: 1px solid #000;\r\n        width: 300px;\r\n        font-size: 18px;\r\n        outline: none;\r\n    }\r\n</style>\r\n</head>\r\n<body>\r\n    <div class=\"paper\">\r\n        <h1>عقد إيجار</h1>\r\n        <p>تم الاتفاق بين السيد/السيدة <input type=\"text\" placeholder=\"الاسم\"> بتاريخ <input type=\"text\" placeholder=\"التاريخ\"></p>\r\n        <p>مدة العقد: <input type=\"text\" placeholder=\"عدد الأيام\"> أيام</p>\r\n        <p>القيمة: <input type=\"text\" placeholder=\"المبلغ\"> جنيه</p>\r\n        <p>تفاصيل إضافية: <input type=\"text\" placeholder=\"أدخل التفاصيل\"></p>\r\n    </div>\r\n</body>\r\n</html>\r\n");

            migrationBuilder.UpdateData(
                table: "ContractTemplates",
                keyColumn: "id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "Content",
                value: "\r\n<html lang='ar'>\r\n<head>\r\n<meta charset='UTF-8'>\r\n<style>\r\n    body {\r\n        direction: rtl;\r\n        font-family: 'Arial', sans-serif;\r\n        background-color: #f9f9f9;\r\n        display: flex;\r\n        justify-content: center;\r\n        align-items: center;\r\n        height: 100vh;\r\n        margin: 0;\r\n    }\r\n    .paper {\r\n        background-color: white;\r\n        width: 800px;\r\n        padding: 40px;\r\n        box-shadow: 0 0 20px rgba(0,0,0,0.2);\r\n        border: 1px solid #ccc;\r\n    }\r\n    h1 { text-align: center; margin-bottom: 40px; }\r\n    p { font-size: 18px; line-height: 1.8; margin: 20px 0; }\r\n    input { border: none; border-bottom: 1px solid #000; width: 300px; font-size: 18px; outline: none; }\r\n</style>\r\n</head>\r\n<body>\r\n    <div class='paper'>\r\n        <h1>فاتورة مبيعات</h1>\r\n        <p>تم إصدار الفاتورة للعميل: <input type='text' placeholder='اسم العميل'></p>\r\n        <p>تاريخ الفاتورة: <input type='text' placeholder='التاريخ'></p>\r\n        <p>المبلغ: <input type='text' placeholder='المبلغ'> جنيه</p>\r\n        <p>ملاحظات: <input type='text' placeholder='أدخل الملاحظات'></p>\r\n    </div>\r\n</body>\r\n</html>");

            migrationBuilder.UpdateData(
                table: "ContractTemplates",
                keyColumn: "id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "Content",
                value: "\r\n<html lang='ar'>\r\n<head>\r\n<meta charset='UTF-8'>\r\n<style>\r\n    body {\r\n        direction: rtl;\r\n        font-family: 'Arial', sans-serif;\r\n        background-color: #f9f9f9;\r\n        display: flex;\r\n        justify-content: center;\r\n        align-items: center;\r\n        height: 100vh;\r\n        margin: 0;\r\n    }\r\n    .paper {\r\n        background-color: white;\r\n        width: 800px;\r\n        padding: 40px;\r\n        box-shadow: 0 0 20px rgba(0,0,0,0.2);\r\n        border: 1px solid #ccc;\r\n    }\r\n    h1 { text-align: center; margin-bottom: 40px; }\r\n    p { font-size: 18px; line-height: 1.8; margin: 20px 0; }\r\n    input { border: none; border-bottom: 1px solid #000; width: 300px; font-size: 18px; outline: none; }\r\n</style>\r\n</head>\r\n<body>\r\n    <div class='paper'>\r\n        <h1>تقرير متابعة</h1>\r\n        <p>تم إعداد التقرير للعميل: <input type='text' placeholder='اسم العميل'></p>\r\n        <p>تاريخ التقرير: <input type='text' placeholder='التاريخ'></p>\r\n        <p>ملاحظات: <input type='text' placeholder='أدخل الملاحظات'></p>\r\n        <p>إجراء لاحق: <input type='text' placeholder='الإجراء التالي'></p>\r\n    </div>\r\n</body>\r\n</html>");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ContractTemplates",
                keyColumn: "id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "Content",
                value: "<html>\r\n<body>\r\n<h1>عقد إيجار</h1>\r\n<p>تم الاتفاق بين السيد/السيدة ______________________ بتاريخ ______________________</p>\r\n<p>مدة العقد: ______________________ أيام</p>\r\n<p>القيمة: ______________________ جنيه</p>\r\n<p>تفاصيل إضافية: ______________________</p>\r\n</body>\r\n</html>");

            migrationBuilder.UpdateData(
                table: "ContractTemplates",
                keyColumn: "id",
                keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                column: "Content",
                value: "<html>\r\n<body>\r\n<h1>فاتورة مبيعات</h1>\r\n<p>تم إصدار الفاتورة للعميل: ______________________</p>\r\n<p>تاريخ الفاتورة: ______________________</p>\r\n<p>المبلغ: ______________________ جنيه</p>\r\n<p>ملاحظات: ______________________</p>\r\n</body>\r\n</html>");

            migrationBuilder.UpdateData(
                table: "ContractTemplates",
                keyColumn: "id",
                keyValue: new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                column: "Content",
                value: "<html>\r\n<body>\r\n<h1>تقرير متابعة</h1>\r\n<p>تم إعداد التقرير للعميل: ______________________</p>\r\n<p>تاريخ التقرير: ______________________</p>\r\n<p>ملاحظات: ______________________</p>\r\n<p>إجراء لاحق: ______________________</p>\r\n</body>\r\n</html>");
        }
    }
}
