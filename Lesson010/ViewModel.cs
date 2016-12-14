using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Lesson010
{
    class ViewModel : NotifyPropertyChangedObject
    {
        public string SourceXml
        {
            get { return _SourceXml; }
            set { SetValue(ref _SourceXml, value, "SourceXml"); }
        }
        private string _SourceXml;

        public string XPath
        {
            get { return _XPath; }
            set { SetValue(ref _XPath, value, "XPath"); }
        }
        private string _XPath;

        public List<XElement> QueryResult
        {
            get { return _QueryResult; }
            set { SetValue(ref _QueryResult, value, "QueryResult"); }
        }
        private List<XElement> _QueryResult;

        public void Load(string aFileName)
        {
            SourceXml = XDocument.Load(aFileName).ToString();
        }
        public void Query()
        {
            XDocument aXDocument = XDocument.Parse(SourceXml);
            QueryResult = aXDocument.XPathSelectElements(XPath).ToList();
        }
    }
}