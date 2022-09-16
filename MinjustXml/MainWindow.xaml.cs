using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
        private System.DateTime date_pp;
        public MainWindow()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Multiselect = true,
            Title="Выберите файлы "
        };

        public void Open_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "XML files (*.XML)|*.XML";
            openFileDialog.ShowDialog();
            OpenXml();
            if (openFileDialog.FileName == String.Empty)
            {
                return;
            }
            foreach (string file in openFileDialog.FileNames)
            {
            }
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
            var zxc = doc.GetElementsByTagName("DATE_PP");
            date_pp = DateTime.Parse(zxc[0].InnerXml);
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
            Regex regex1 = new Regex("(.*)00");
            foreach (var reg in regs)
            {
                reg.SUM_REESTR_PP= regex1.Replace(reg.SUM_REESTR_PP, "$1.00");
            }
            countregs.Text = "Количество человек: " + regs.Count().ToString();
            peoplesGrid.ItemsSource = regs;
        }
    }
}