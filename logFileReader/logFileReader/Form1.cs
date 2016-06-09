using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logFileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                int totalSentCounter = 0;
                int totalSuccessCounter = 0;
                int totalFailCounter = 0;
                string line;
                while ((line = file.ReadLine()) != null)
                {

                    if (line.Contains("File,"))
                    {
                        totalSentCounter++;

                        if (file.ReadLine().Contains("ERROR"))
                        {
                            String[] errorFile = line.Split(',');
                            failedTextBox.AppendText(errorFile[3] + "\n");
                            totalFailCounter++;
                        }
                        else
                        {
                            String[] successFile = line.Split(',');
                            successTextBox.AppendText(successFile[3] + "\n");
                            totalSuccessCounter++;
                        }
                    }

                }

                file.Close();
                numberSent.Text = totalSentCounter.ToString();
                numberSuccess.Text = totalSuccessCounter.ToString();
                numberFailed.Text = totalFailCounter.ToString();
                button2.Visible = true;
                chart1.Series["Number"].Points.Add(totalSuccessCounter).Name="Success";
                chart1.Series["Number"].Points.Add(totalFailCounter);

            }
        }

        private void failedTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void createPieChart(int success, int failed)
        {
            //Chart pieChart = new Chart();
            
        }
    }

}
