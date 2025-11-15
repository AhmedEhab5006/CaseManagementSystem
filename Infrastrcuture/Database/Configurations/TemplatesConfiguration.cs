using Infrastrcuture.AuditingAndIntegration;
using Infrastrcuture.HelperEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastrcuture.Database.Configurations
{
    public class TemplatesConfiguration : IEntityTypeConfiguration<ContractTemplate>
    {
        public void Configure(EntityTypeBuilder<ContractTemplate> builder)
        {
            builder.HasData(
                new ContractTemplate
                {
                    id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Name = "عقد إيجار",
                    TypeId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Content = @"<!DOCTYPE html>
<html lang=""ar"">
<head>
<meta charset=""UTF-8"">
<title>عقد إيجار</title>
<style>
    body {
        direction: rtl; /* الكتابة من اليمين لليسار */
        font-family: 'Arial', sans-serif;
        background-color: #f9f9f9;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
    }

    .paper {
        background-color: white;
        width: 800px;
        padding: 40px;
        box-shadow: 0 0 20px rgba(0,0,0,0.2);
        border: 1px solid #ccc;
    }

    h1 {
        text-align: center;
        margin-bottom: 40px;
    }

    p {
        font-size: 18px;
        line-height: 1.8;
        margin: 20px 0;
    }

    input {
        border: none;
        border-bottom: 1px solid #000;
        width: 300px;
        font-size: 18px;
        outline: none;
    }
</style>
</head>
<body>
    <div class=""paper"">
        <h1>عقد إيجار</h1>
        <p>تم الاتفاق بين السيد/السيدة <input type=""text"" placeholder=""الاسم""> بتاريخ <input type=""text"" placeholder=""التاريخ""></p>
        <p>مدة العقد: <input type=""text"" placeholder=""عدد الأيام""> أيام</p>
        <p>القيمة: <input type=""text"" placeholder=""المبلغ""> جنيه</p>
        <p>تفاصيل إضافية: <input type=""text"" placeholder=""أدخل التفاصيل""></p>
    </div>
</body>
</html>
",
                    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                    createdBy = "SystemSeed"
                },
               new ContractTemplate
               {
                   id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                   Name = "فاتورة مبيعات",
                   TypeId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                   Content = @"
<html lang='ar'>
<head>
<meta charset='UTF-8'>
<style>
    body {
        direction: rtl;
        font-family: 'Arial', sans-serif;
        background-color: #f9f9f9;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
    }
    .paper {
        background-color: white;
        width: 800px;
        padding: 40px;
        box-shadow: 0 0 20px rgba(0,0,0,0.2);
        border: 1px solid #ccc;
    }
    h1 { text-align: center; margin-bottom: 40px; }
    p { font-size: 18px; line-height: 1.8; margin: 20px 0; }
    input { border: none; border-bottom: 1px solid #000; width: 300px; font-size: 18px; outline: none; }
</style>
</head>
<body>
    <div class='paper'>
        <h1>فاتورة مبيعات</h1>
        <p>تم إصدار الفاتورة للعميل: <input type='text' placeholder='اسم العميل'></p>
        <p>تاريخ الفاتورة: <input type='text' placeholder='التاريخ'></p>
        <p>المبلغ: <input type='text' placeholder='المبلغ'> جنيه</p>
        <p>ملاحظات: <input type='text' placeholder='أدخل الملاحظات'></p>
    </div>
</body>
</html>",
                   createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
                   createdBy = "SystemSeed"
               },

new ContractTemplate
{
    id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
    Name = "تقرير متابعة",
    TypeId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
    Content = @"
<html lang='ar'>
<head>
<meta charset='UTF-8'>
<style>
    body {
        direction: rtl;
        font-family: 'Arial', sans-serif;
        background-color: #f9f9f9;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
    }
    .paper {
        background-color: white;
        width: 800px;
        padding: 40px;
        box-shadow: 0 0 20px rgba(0,0,0,0.2);
        border: 1px solid #ccc;
    }
    h1 { text-align: center; margin-bottom: 40px; }
    p { font-size: 18px; line-height: 1.8; margin: 20px 0; }
    input { border: none; border-bottom: 1px solid #000; width: 300px; font-size: 18px; outline: none; }
</style>
</head>
<body>
    <div class='paper'>
        <h1>تقرير متابعة</h1>
        <p>تم إعداد التقرير للعميل: <input type='text' placeholder='اسم العميل'></p>
        <p>تاريخ التقرير: <input type='text' placeholder='التاريخ'></p>
        <p>ملاحظات: <input type='text' placeholder='أدخل الملاحظات'></p>
        <p>إجراء لاحق: <input type='text' placeholder='الإجراء التالي'></p>
    </div>
</body>
</html>",
    createdAt = new DateTime(2025, 11, 13, 0, 0, 0, DateTimeKind.Utc),
    createdBy = "SystemSeed"
}           );
        }
    }
}
