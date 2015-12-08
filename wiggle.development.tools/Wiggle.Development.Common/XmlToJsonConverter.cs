using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Wiggle.Development.Common
{
    public class XmlToJsonConverter
    {
        public string ConvertToXml(string json, string command, string ns)
        {
            var wrappedJson = $"{{ {command} :  {json} }}";

            var doc = JsonConvert.DeserializeXmlNode(wrappedJson, "Messages");

            doc.DocumentElement.Attributes.Append(CreateAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance", doc));
            doc.DocumentElement.Attributes.Append(CreateAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema", doc));
            doc.DocumentElement.Attributes.Append(CreateAttribute("xmlns", $"http://tempuri.net/{ns}", doc));
            return System.Xml.Linq.XElement.Parse(doc.OuterXml).ToString();
        }

        public string ConvertToJSon(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var jsonText = JsonConvert.SerializeXmlNode(doc);
            return jsonText;
        }

        private XmlAttribute CreateAttribute(string name, string value, XmlDocument xmlDoc)
        {
            var a = xmlDoc.CreateAttribute(name);
            a.Value = value;

            return a;
        }
    }
}
