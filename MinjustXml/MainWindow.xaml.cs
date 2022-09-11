using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;

namespace MinjustXml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public void Open_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.ShowDialog();
            OpenXml();
        }
        private void OpenXml()
        {
            string text = "";
            using (StreamReader reader = new StreamReader(openFileDialog.FileName))
            {
                text = reader.ReadToEnd();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(openFileDialog.FileName);
            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("RegPP");
            var rootAttribute = new XmlRootAttribute();
            rootAttribute.ElementName = "RegPP";
            XmlSerializer serializer = new XmlSerializer(typeof(RegPP), rootAttribute);
            for (int i = 1; i < elemList.Count; i++)
            {
                using (StringReader reader = new StringReader(elemList[i].InnerXml))
                {
                    var k = elemList[i].InnerXml.Insert(0, "<RegPP>");
                    k = k.Insert(k.Length, "</RegPP>");

                    var s = (RegPP)serializer.Deserialize(new StringReader(k));
                    MessageBox.Show(s?.FIO_PLAT);
                }
            }
            //RegPP reg = new RegPP();
            //XmlDocument xml = new XmlDocument();
            //xml.Load(openFileDialog.FileName);
            //XmlElement element=xml.DocumentElement;
            //foreach (XmlNode xmlNode in element)
            //{
            //    if (xmlNode.Attributes.Count > 0)
            //    {
            //        XmlNode attr = xmlNode.Attributes.GetNamedItem("FIO_PLAT");
            //        if (attr != null)
            //        {
            //            peoplesGrid.Items.Add(reg);
            //        }
            //    }
            //}
        }
        
         
    }
}
