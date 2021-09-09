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
using System.Xml.Linq;

namespace XML_Olusturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlTextWriter dosya = new XmlTextWriter(@"seriler.xml", Encoding.UTF8);
            dosya.Formatting = Formatting.Indented;
            dosya.WriteStartDocument();
            dosya.WriteStartElement("URUNLER");
            dosya.WriteEndElement();
            dosya.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XDocument xdosya = XDocument.Load(@"seriler.xml");
            XElement rootelement = xdosya.Root;
            XElement GTIN = new XElement("GTIN", textBox1.Text);
            XElement BN = new XElement("BN", textBox2.Text);
            XElement XD = new XElement("XD", textBox4.Text);


            for (int i = 0; i < Convert.ToInt32(textBox5.Text); i++)
            {
                XElement element = new XElement("URUN");
                XElement SN = new XElement("SN", richTextBox1.Lines[i]);
                element.Add(GTIN, BN, SN, XD);
                
                rootelement.Add(element);
            }


            xdosya.Save(@"seriler.xml");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int seriNoCountes = richTextBox1.Lines.Length - 1;
            textBox5.Text = Convert.ToString(seriNoCountes);
        }
    }
}
