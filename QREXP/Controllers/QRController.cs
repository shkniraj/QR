using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace QREXP.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {

            QRCodeGenerator qr = new QRCodeGenerator();
            string encodedString = "fdedfeaa455fe2244e4618c059623eaacd1025e0a9af70584c56ecac1c054961";
            byte[] data = Convert.FromBase64String(encodedString);
            string decodedString = System.Text.Encoding.UTF8.GetString(data);
            QRCodeData qrCodeData = qr.CreateQrCode(decodedString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Base64QRCode qrCodes = new Base64QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(40);
            var barcodeBitmap = new System.Drawing.Bitmap(qrCodeImage);
            string path = Server.MapPath("~/images/QRImage.jpg");
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path,
                   FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }

            return View();
        }
    }
}