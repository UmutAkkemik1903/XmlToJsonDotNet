using System.Xml;
using Newtonsoft.Json;

namespace tetacode.Services
{
    public class XmlParserService
    {
        // XML'i JSON formatına dönüştüren metot
        public string ProcessXmlToJson(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // XML deklarasyonunu kaldırmak
            if (xmlDoc.FirstChild is XmlDeclaration xmlDeclaration)
            {
                xmlDoc.RemoveChild(xmlDeclaration);
            }

            // Ad alanlarını (xmlns) kaldırmak
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("*"))
            {
                if (node.Attributes != null && node.Attributes["xmlns"] != null)
                {
                    node.Attributes.RemoveNamedItem("xmlns");
                }
            }

            // XML'i JSON formatına dönüştür
            string jsonResult = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);

            // Yanlış karakter kodlamalarını düzelt
            jsonResult = System.Web.HttpUtility.HtmlDecode(jsonResult);

            return jsonResult; // JSON formatında döndür
        }
    }
}
