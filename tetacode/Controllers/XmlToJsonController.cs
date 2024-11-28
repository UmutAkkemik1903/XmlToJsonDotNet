using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Xml;

namespace tetacode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlToJsonController : ControllerBase
    {
        [HttpPost("upload")]
        public IActionResult UploadXml(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                Console.WriteLine("No file uploaded or file is empty.");
                return BadRequest("Invalid file.");
            }

            var tempFilePath = Path.Combine(Path.GetTempPath(), file.FileName);

            try
            {
                // Dosyayı geçici olarak kaydet
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                Console.WriteLine($"File uploaded successfully: {tempFilePath}");

                // XML dosyasını JSON'a dönüştür
                var jsonResult = ProcessXmlToJson(tempFilePath);

                Console.WriteLine("Final JSON Output:");
                Console.WriteLine(jsonResult);

                // JSON çıktısını Postman'e gönder
                return Content(jsonResult, "application/json", Encoding.UTF8);
            }
            catch (XmlException xmlEx)
            {
                Console.WriteLine($"XML parsing error: {xmlEx.Message}");
                return BadRequest($"XML parsing error: {xmlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            finally
            {
                if (System.IO.File.Exists(tempFilePath))
                {
                    System.IO.File.Delete(tempFilePath);
                    Console.WriteLine("Temporary file deleted.");
                }
            }
        }

        private string ProcessXmlToJson(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string content;
            try
            {
                // Dosyayı kodlama ile oku
                content = System.IO.File.ReadAllText(filePath, Encoding.GetEncoding("iso-8859-9"));
                Console.WriteLine("File successfully read with iso-8859-9 encoding.");
            }
            catch
            {
                content = System.IO.File.ReadAllText(filePath, Encoding.UTF8);
                Console.WriteLine("File successfully read with UTF-8 encoding.");
            }

            if (string.IsNullOrWhiteSpace(content))
                throw new Exception("The XML file is empty or unreadable.");

            Console.WriteLine("Raw XML Content:");
            Console.WriteLine(content);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);

            Console.WriteLine("Root Node: " + xmlDoc.DocumentElement.Name);

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                Console.WriteLine($"Node Name: {node.Name}, Value: {node.InnerText}");
            }

            // XML deklarasyonunu kaldır
            if (xmlDoc.FirstChild is XmlDeclaration xmlDeclaration)
            {
                xmlDoc.RemoveChild(xmlDeclaration);
                Console.WriteLine("XML Declaration removed.");
            }

            // Boş düğümleri temizle
            RemoveEmptyNodes(xmlDoc.DocumentElement);

            Console.WriteLine("Cleaned XML Document:");
            Console.WriteLine(xmlDoc.OuterXml);

            // JSON formatına dönüştür
            string jsonResult = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);
            return jsonResult;
        }

        private void RemoveEmptyNodes(XmlNode node)
        {
            if (node == null) return;

            for (int i = node.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlNode child = node.ChildNodes[i];
                RemoveEmptyNodes(child);

                // Eğer düğüm boşsa kaldır
                if ((string.IsNullOrWhiteSpace(child.InnerText) || child.InnerText == "") && child.ChildNodes.Count == 0)
                {
                    Console.WriteLine($"Removing empty node: {child.Name}");
                    node.RemoveChild(child);
                }
            }
        }
    }
}
