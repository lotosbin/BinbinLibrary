using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace WebScan.WpfApplication
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string urlText = this.textBox1.Text.Trim();
            Uri uri = new Uri(urlText);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            var response = request.GetResponse();
            string doc;
            using (var stream = response.GetResponseStream())
            {
                var sr = new StreamReader(stream);
                doc = sr.ReadToEnd();
            }
            List<Uri> links = ParseUrlDoc(uri, doc);
            foreach (var link in links)
            {
                var listBoxItem = new ListBoxItem();
                listBoxItem.Content = link.ToString();
                this.listBox1.Items.Add(listBoxItem);
                //ParseUrl(link);
            }
        }

        private List<Uri> ParseUrl(Uri link)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            var response = request.GetResponse();
            string doc;
            using (var stream = response.GetResponseStream())
            {
                var sr = new StreamReader(stream);
                doc = sr.ReadToEnd();
            }
            return ParseUrlDoc(link, doc);
        }
        static List<string> GetAllLinksFromStringByRegex(string myHtmlString)
        {
            const string txtFileExp = "href=\"([^\\\"]*)\"";

            MatchCollection textFileLinkMatches = Regex.Matches(myHtmlString, txtFileExp, RegexOptions.IgnoreCase);
            List<string> foundTextFiles = (from Match m in textFileLinkMatches select m.Groups[1].ToString()).ToList();

            return foundTextFiles.ToList();
        }


        private List<Uri> ParseUrlDoc(Uri uri, string doc)
        {
            Uri baseUri = new Uri("http://" + uri.Host + ":" + uri.Port);
            var links = GetAllLinksFromStringByRegex(doc);
            var list = (from link in links where link.StartsWith("http://") select new Uri(link)).ToList();
            list.AddRange(from link1 in links where link1.StartsWith("/") select new Uri(baseUri, link1));
            return list.ToList();
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            var optionWindow = new OptionWindow();
            optionWindow.ShowDialog();
        }
    }
}
