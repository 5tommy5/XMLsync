using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLsync
{
    public partial class Form1 : Form
    {
        Logic lg = new Logic();
        string flexpath { get; set; }
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = "Загружен!";
            // сохраняем текст в файл
            label4.Text = filename;
            lg.mainFile = XElement.Load(openFileDialog1.FileName);
            MessageBox.Show("Файл загружен");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = "Загружен!";
            // сохраняем текст в файл
            label5.Text = filename;
            flexpath = openFileDialog1.FileName;
            lg.flexfile = XElement.Load(flexpath);
            MessageBox.Show("Файл загружен");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(xmlCompare.Check(lg.mainFile, lg.flexfile))
            {
                label1.Text = "Равны!";
                label1.BackColor = Color.Green;
                
            }
            else
            {
                label1.Text = "Не равны!";
                label1.BackColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xmlCompare.EvenUp(lg.mainFile, lg.flexfile);
            using (FileStream SourceStream = File.Open(flexpath, FileMode.OpenOrCreate))
            {
                lg.flexfile.Save(SourceStream);
            }

            MessageBox.Show("Файлы синхронизированы!");
        }
    }
}
