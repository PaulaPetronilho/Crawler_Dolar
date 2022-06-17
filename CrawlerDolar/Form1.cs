using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerDolar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("User-Agent: Others");

            string pagina = webClient.DownloadString("https://economia.uol.com.br");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(pagina);
            var cotacao = document.DocumentNode.SelectNodes("//div[@class='hidden-xs']/h3[@class='tituloGrafico']/a[@class='subtituloGrafico subtituloGraficoValor']");
            txtDolar.Text = cotacao[0].FirstChild.InnerText;            
        }        
    }
}
