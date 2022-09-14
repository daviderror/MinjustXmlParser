using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

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
            openFileDialog.Filter = "XML files (*.XML)|*.XML";
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
            XmlNodeList elemList = doc.GetElementsByTagName("RegPP");
            var rootAttribute = new XmlRootAttribute();
            rootAttribute.ElementName = "RegPP";
            XmlSerializer serializer = new XmlSerializer(typeof(RegPP), rootAttribute);
            List<RegPP> regs = new List<RegPP>();
            for (int i = 1; i < elemList.Count; i++)
            {
                using (StringReader reader = new StringReader(elemList[i].InnerXml))
                {
                    var k = elemList[i].InnerXml.Insert(0, "<RegPP>");
                    k = k.Insert(k.Length, "</RegPP>");

                    var s = (RegPP)serializer.Deserialize(new StringReader(k));
                    regs.Add(s);
                    
                }
            }
            Regex regex = new Regex(".*ОПЛАТА ЗА:(.*)");
            foreach (var reg in regs)
            {
                reg.PURPOSE = regex.Replace(reg.PURPOSE, "$1");
            }
            peoplesGrid.ItemsSource = regs;
        }
        private void searchData_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            searchData.Clear();
        }
    }
}
