using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using week06.MnbServiceReference;

namespace week06
{
    public partial class Form1 : Form
    {
        //string result2 { get; set; }
        RichTextBox rb1 = new RichTextBox();
        RichTextBox rb2 = new RichTextBox();
        BindingList<RateData> Rates = new BindingList<RateData>();
        BindingList<RateData> Currencies = new BindingList<RateData>();

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Rates;
            GetCurrs();
            comboBox1.DataSource = Currencies;
            RefreshData();

            Console.WriteLine();

        }
        public void GetExchangeRates()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = comboBox1.Items.ToString(),
                startDate = dateTimePicker1.Value.Tostring(),
                endDate = dateTimePicker2.Value.Tostring()
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;

            rtb1.Text = result;

        }
        public void RefreshData()
        {
            Rates.Clear();
            GetExchangeRates();
            XMLFunction();
            dataGridView1.DataSource = Rates;
        }
        public void GetCurrs()
        {
            var mnbService2 = new MNBArfolyamServiceSoapClient();
            var req2 = new GetCurrenciesRequestBody();
            var resp2 = mnbService2.GetCurrenciesAsync(req2);
            var result2 = resp2.GetCurrenciesResult;

            var xml2 = new XmlDocument();
            xml2.LoadXml(result2);
            foreach (XmlDocument element in xml2.DocumentElement)
            {
                var curr = new RateData();
                Currencies.Add(curr);



            }


        }
        public void XMLFunction()
        {
            var xml = new XmlDocument();
            xml.LoadXml(rtb1.Text.Tostring());
            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData() >
                    Rates.Add(rate);
                rate.Date = DateTime.Parse(element.GetAttribute("date"))
                    var childElement = (XmlElement)element.ChildNodes[0];
                if (childElement == null)
                    continue;
                rate.Currency = childElement.GetAttribute("curr");

                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
               
            }
            public void grafikon()
            {
                chartRateData.DataSource = Rates;
                var series = chartRateData.Series[0];
                series.ChartType = SeriesChartType.Line;
                series.XValueMember = "Date";
                series.YValueMembers = "Value";
                series.BorderWidth = 2;

                var legend = chartRateData.Legends[0];
                legend.Enabled = false;

                var chartArea = chartRateData.ChartAreas[0];
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.AxisY.IsStartedFromZero = false;

            }

          
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
