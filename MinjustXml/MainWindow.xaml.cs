using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace MinjustXml
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.DateTime date_pp;
        private string nom_paydoc;

        public string GetPP
        {
            get { return date_pp.ToString("dd.MM.yyyy"); }
            set { datepp.Text = value; }
        }

        List<RegPP> regs = new List<RegPP>();

        public MainWindow()
        {
            InitializeComponent();
        }
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Multiselect = true,
            Title = "Выберите файлы "
        };
        public void Open_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "XML files (*.XML)|*.XML";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName == String.Empty)
            {
                return;
            }
            regs = new List<RegPP>();
            foreach (string file in openFileDialog.FileNames)
            {
                OpenXml(file);
            }
            peoplesGrid.ItemsSource = regs;
            string filterText = findName.Text;
            ICollectionView viewSource = CollectionViewSource.GetDefaultView(peoplesGrid.ItemsSource);
            if (filterText == "")
            {
                viewSource.Filter = null;
            }
            else
            {
                viewSource.Filter = o =>
                {
                    RegPP p = o as RegPP;
                    return p.FIO_PLAT.ToString().Contains(filterText);
                };
            }
            peoplesGrid.ItemsSource = viewSource;
        }
        private void OpenReport(string fileName)
        {
            try
            {
                string text1 = "";
                using (StreamReader reader = new StreamReader(fileName))
                {
                    text1 = reader.ReadToEnd(); 
                }
                XmlDocument doc=new XmlDocument();
                doc.Load(fileName);
                XmlNodeList elementList = doc.GetElementsByTagName("Report");
                var qwe = doc.GetElementsByTagName("NOM_PP");
                var rootAttribute = new XmlRootAttribute();
                rootAttribute.ElementName = "Report";
                XmlSerializer serializer = new XmlSerializer(typeof(Report), rootAttribute);
                for (int i = 1; i < elementList.Count; i++)
                {
                    using (StringReader reader = new StringReader(elementList[i].InnerXml))
                    {
                        var j = elementList[i].InnerXml.Insert(0, "<Report>");
                        j = j.Insert(j.Length, "</Report>");
                        var s = (RegPP)serializer.Deserialize(new StringReader(j));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка чтения XML файла.");
                return;
            }
        }
        private void OpenXml(string fileName)
        {
            try
            {
                string text = "";
                using (StreamReader reader = new StreamReader(fileName))
                {
                    text = reader.ReadToEnd();
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNodeList elemList = doc.GetElementsByTagName("RegPP");
                var zxc = doc.GetElementsByTagName("DATE_PP");
                date_pp = DateTime.Parse(zxc[0].InnerXml);
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
                    reg.SUM_REESTR_PP = regex1.Replace(reg.SUM_REESTR_PP, "$1.00");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения XML файла.");
                return;
            }
            countregs.Text = "Количество человек: " + regs.Count().ToString();
            datepp.Text = "Дата платежного поручения: " + GetPP;
        }
        private void peoplesGrid_CellEditEnding_1(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("Нельзя редактировать записи!");
            return;
        }

        private void findName_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(findName.Text)) {
                peoplesGrid.ItemsSource = regs;
                return;
            }
            //var s = regs.Where(_ => _.FIO_PLAT.ToLower().Contains(findName.Text.ToLower())).ToList();
            //peoplesGrid.ItemsSource = s;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(findName.Text))
            {
                peoplesGrid.ItemsSource = regs;
                return;
            }
            var s = regs.Where(_ => _.FIO_PLAT.ToLower().Contains(findName.Text.ToLower())).ToList();
            peoplesGrid.ItemsSource = s;
        }
    }
}