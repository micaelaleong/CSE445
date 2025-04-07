// Name: Micaela Leong
// ASU ID: 1225320759
// CSE445 Assignment 4

using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/

namespace ConsoleApp1
{
    public class Program
    {
        public static string xmlURL = "https://micaelaleong.github.io/CSE445/Hotels.xml";
        public static string xmlErrorURL = "https://micaelaleong.github.io/CSE445/HotelsErrors.xml";
        public static string xsdURL = "https://micaelaleong.github.io/CSE445/Hotels.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            // referencing StackOverflow and Microsoft documentation:
            // https://stackoverflow.com/questions/751511/validating-an-xml-against-referenced-xsd-in-c-sharp
            // https://learn.microsoft.com/en-us/dotnet/standard/data/xml/xml-schema-xsd-validation-with-xmlschemaset

            XmlReaderSettings hotelSettings = new XmlReaderSettings();
            hotelSettings.Schemas.Add(null, XmlReader.Create(xsdUrl));
            hotelSettings.ValidationType = ValidationType.Schema;

            // set default message to be "No Error" --> xml file fits xsd

            string errorMessage = "No Error";

            hotelSettings.ValidationEventHandler += (sender, args) =>
            {
                // if there is a validation error, change message to be the validation error
                errorMessage = args.Message;
            };

            using (XmlReader hotelsReader = XmlReader.Create(xmlUrl, hotelSettings))
            {
                while (hotelsReader.Read()) { }
            }

            return errorMessage;
            //return "No Error" if XML is valid. Otherwise, return the desired exception message.
        }

        public static string Xml2Json(string xmlUrl)
        {
            // referencing StackOverflow:
            // https://stackoverflow.com/questions/814001/how-to-convert-json-to-xml-or-xml-to-json-in-c

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlUrl);

            string jsonText = JsonConvert.SerializeXmlNode(doc);

            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))
            return jsonText;
        }
    }

}
