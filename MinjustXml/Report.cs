using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MinjustXml
{
    public class Report
    {
        [XmlArrayItem]
        public List<RegPP> RegPPs { get; set; }
    }
}
