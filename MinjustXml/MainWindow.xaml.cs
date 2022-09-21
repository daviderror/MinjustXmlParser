using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Data;
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

        private string nom_pp;

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
                var qwe = doc.GetElementsByTagName("NOM_PP");
                nom_pp = qwe[0].InnerXml;

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
                        if (nom_pp != default && date_pp != default)
                        {
                            s.NOM_PAY_DOC = nom_pp;
                            s.DATE_PAY_DOC = date_pp;
                        }
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
                    reg.SUM_REESTR_PP = reg.SUM_REESTR_PP.Replace("..", ".");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения XML файла.");
                return;
            }
            countregs.Text = "Количество человек: " + regs.Count().ToString();
        }
        private void peoplesGrid_CellEditEnding_1(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            MessageBox.Show("Нельзя редактировать записи!");
            return;
        }

        private void findName_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(findName.Text))
            {
                peoplesGrid.ItemsSource = regs;
                return;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(findName.Text))
            {
                peoplesGrid.ItemsSource = regs;
                return;
            }

            var s = regs.Where(_ => _.FIO_PLAT!.ToLower().Contains(findName.Text.ToLower()) ||
                                    _.NOM_LINE!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.NOM_PAY_DOC!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.DATE_PAY_DOC!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.GetDate!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.ID_OPER!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.SUM_REESTR_PP!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.SUM_REESTR_PP!.ToString().Contains(findName.Text.ToLower()) ||
                                    _.NOM_LINE!.ToString().Contains(findName.Text.ToLower()) 
                                    ).ToList();
            peoplesGrid.ItemsSource = s;
        }
    }
}