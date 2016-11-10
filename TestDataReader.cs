using System.Xml.Linq;
using System.Xml.XPath;

namespace AutomatedTests
{
    /// <summary>
    /// Class for reading params from TestEnvironmentConfiguration xml file
    /// </summary>
    public class TestDataReader
    {
        private readonly XDocument _xmlDoc;

        /// <summary>
        /// initialize reader
        /// </summary>
        /// <param name="pathToConfigurationXml">path to xml file with test envoronment configuration</param>
        public TestDataReader(string pathToConfigurationXml)
        {
            _xmlDoc = XDocument.Load(pathToConfigurationXml);
        }

        /// <summary>
        /// returns value from attribute value of xml element
        /// </summary>
        /// <param name="xpathToElement">xpath to element</param>
        /// <returns></returns>
        public string GetValue(string xpathToElement)
        {
            return _xmlDoc.XPathSelectElement(xpathToElement).Attribute("value").Value;
        }
    }
}
