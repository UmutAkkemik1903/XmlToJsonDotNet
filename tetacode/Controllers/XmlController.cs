using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;

namespace tetacode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult UploadXml(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            var tempFilePath = Path.Combine(Path.GetTempPath(), file.FileName);

            try
            {
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Kodlama sağlayıcısını etkinleştir
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // XML içeriğini oku
                string xmlContent;
                try
                {
                    xmlContent = System.IO.File.ReadAllText(tempFilePath, Encoding.GetEncoding("iso-8859-9"));
                }
                catch
                {
                    xmlContent = System.IO.File.ReadAllText(tempFilePath, Encoding.UTF8);
                }

                if (string.IsNullOrWhiteSpace(xmlContent))
                    throw new Exception("XML content is empty or could not be read.");

                // XML içeriğini dosya olarak döndür
                return File(Encoding.UTF8.GetBytes(xmlContent), "application/xml");

            }
            catch (IOException ioEx)
            {
                return StatusCode(500, $"File handling error: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            finally
            {
                // Geçici dosyayı temizle
                if (System.IO.File.Exists(tempFilePath))
                    System.IO.File.Delete(tempFilePath);
            }
        }
    }
}
