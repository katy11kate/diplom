using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Reflection;
using System.Text;
using WebApplication3.Models;
using WebApplication3.ModelsDTO;
using WebApplication3.Utils;
using static System.Collections.Specialized.BitVector32;

namespace WebApplication3.Controllers
{
    public class PaycheckController : Controller
    {
        [HttpPost]
        [Route("/paycheck")]
        public async Task<ActionResult> PaycheckSave([FromBody] List<PaycheckDTO> paycheckDTO)
        {
            var ctx = new ProjectContext();

            string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            MyFontResolver.Apply();

            MigraDoc.DocumentObjectModel.Document document = new MigraDoc.DocumentObjectModel.Document();
            MigraDoc.DocumentObjectModel.Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;//стандартный размер страницы

            section.PageSetup.BottomMargin = 10;//нижний отступ
            section.PageSetup.TopMargin = 10;//верхний отступ
            Paragraph paragraph = new Paragraph();
            section.Add(paragraph);
            var today1 = DateOnly.FromDateTime(DateTime.Now);
            paragraph.AddText("номер чека: 10");
            paragraph.AddText("\n");
            paragraph.AddDateField("Дата заказа: " + today1.ToShortDateString());

            paragraph.AddText("\n");
            foreach (var paycheck in paycheckDTO)
            {
                var product = ctx.Products.Where(x => x.IdProduct == paycheck.productId).FirstOrDefault();

                int? totalprice = product.Cost * paycheck.quantity;
                paragraph.AddFormattedText(product.NameProduct+" "+product.Size + " " + product.Color + " " + product.Cost.ToString() + " " + totalprice.ToString()+ "\n");
            }
            paragraph.AddText("\r\n");
            paragraph.AddText("ФИО покупателя: Ефименкова Екатерина Дмитриевна");
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();
            pdfRenderer.Document = document;
            pdfRenderer.Language = "ru";
            pdfRenderer.RenderDocument();
            pdfRenderer.PdfDocument.Save(@"C:\Users\yefim\Desktop\NEWFILE.pdf");// сохраняем
            return File(System.IO.File.ReadAllBytes(@"C:\Users\yefim\Desktop\NEWFILE.pdf"), "application/pdf");
        }
    }
}
