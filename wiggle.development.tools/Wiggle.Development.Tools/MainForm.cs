using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Wiggle.Development.Common;

namespace Xml_Json_Converter
{
    public partial class MainForm : Form
    {
        private readonly XmlToJsonConverter _xmlToJsonConverter;
        private readonly DelimiterFinder _delimiterFinder;

        public MainForm()
        {
            InitializeComponent();
            _xmlToJsonConverter = new XmlToJsonConverter();
            _delimiterFinder = new DelimiterFinder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = string.Empty;
            try
            {
                result = _xmlToJsonConverter.ConvertToXml(richTextBox1.Text, tbRootElement.Text, "Wiggle." + tbNamespace.Text);
            }
            catch (Exception ex)
            {
                logTextBox.Text = ex.Message;
            }

            richTextBox2.Text = result;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var result = string.Empty;

            try
            {
                result = _xmlToJsonConverter.ConvertToJSon(richTextBox2.Text);
            }
            catch (Exception ex)
            {
                logTextBox.Text = ex.Message;
            }

            richTextBox1.Text = result;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                tbDelimitersList.Text = string.Join(Environment.NewLine, _delimiterFinder.GetDelimiters(tbDelimiterText.Text));
            }
            catch (Exception ex)
            {
                logTextBox.Text = ex.Message;
            }
        }
    }
}
