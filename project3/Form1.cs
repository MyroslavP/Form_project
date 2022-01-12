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

namespace project3
{
    public partial class Form1 : Form
    {
        private double xd;
        private double x;
        private double xg;
        private double eps;
        private double h;
        private int size = 1;

        private double xd1;
        private double xg1;
        private double eps1;
        private double eps2;

        public Form1()
        {
            InitializeComponent();
            Table.Visible = false;
            chartFunkcji.Visible = false;
            wart.Enabled = true;
            tabel.Enabled = true;
            graf.Enabled = true;

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //------------------------------- VARIABLES -----------------------------------------------------//

        private void textBox1_TextChanged(object sender, EventArgs e) //// X
        {
            double.TryParse(niezależna_X.Text, out x);
           

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) //// H 
        {
            double.TryParse(H.Text, out h);

        }

        private void Xd_TextChanged(object sender, EventArgs e) //// XD
        {
            double.TryParse(Xd.Text, out xd);
        }

        private void Xg_TextChanged(object sender, EventArgs e) //// XG
        {
            double.TryParse(Xg.Text, out xg);
        }

        private void Eps_TextChanged(object sender, EventArgs e) //// EPS
        {
            double.TryParse(Eps.Text, out eps);
        }

        private void textBox3_TextChanged(object sender, EventArgs e) //// XD1
        {
            double.TryParse(textBox3.Text, out xd1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e) //// XG1
        {
            double.TryParse(textBox4.Text, out xg1);
        }

        private void textBox5_TextChanged(object sender, EventArgs e) ///// EPS1
        {
            double.TryParse(textBox5.Text, out eps1);
        }

        private void textBox1_TextChanged_3(object sender, EventArgs e) ///// EPS2
        {
            double.TryParse(textBox1.Text, out eps2);


        }

        private void Grub_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(Grub.Text, out size);
        } //// TEXT SIZE

        //------------------------------- MAIN FUNCTIONS  -----------------------------------------------------//

        private void wart_Click(object sender, EventArgs e)
        {

            string res = x.ToString();

            if (res == "0" || String.IsNullOrEmpty(res))
            {
                return;
            }
            else
            { 
                double sum = Sum(x, eps, out int n);
                Otpow.Text = sum.ToString("0.00"); 
            }
        }

        private void tabel_Click(object sender, EventArgs e)
        {

            string epsx = eps.ToString();
            string xds = xd.ToString();
            string xgs = xg.ToString();
            string hs = h.ToString();

            chartFunkcji.Visible = false;
            Table.Visible = true;

            double x = xd;

            if ((epsx == "0" || String.IsNullOrEmpty(epsx)) || (xds == "0" || String.IsNullOrEmpty(xds)) || (xgs == "0" || String.IsNullOrEmpty(xgs)) || (hs == "0" || String.IsNullOrEmpty(hs)))
            {
                Table.Visible = false;
                return;
            }
            else
            {
                while (x < xg)
                {
                    double sum = Sum(x, eps, out int n);
                    Table.Rows.Add(x.ToString("0.000"), sum.ToString("0.000"));

                    x += h;

                }
                tabel.Enabled = false;
            }
        }

        private void graf_Click(object sender, EventArgs e)
        {
            string epsx = eps.ToString();
            string xds = xd.ToString();
            string xgs = xg.ToString();
            string hs = h.ToString();

            Table.Visible = false;
            chartFunkcji.Visible = true;

            double x = xd;

            if ((epsx == "0" || String.IsNullOrEmpty(epsx)) || (xds == "0" || String.IsNullOrEmpty(xds)) || (xgs == "0" || String.IsNullOrEmpty(xgs)) || (hs == "0" || String.IsNullOrEmpty(hs)))
            {
                chartFunkcji.Visible = false;
                return;
            }
            else
            {
                while (x < xg)
                {
                    double sum = Sum(x, eps, out int n);
                    chartFunkcji.Series[0].Points.AddXY(x.ToString("0.000"), sum.ToString("0.000"));
                    chartFunkcji.Series[0].BorderWidth = size;
                    chartFunkcji.ChartAreas[0].AxisX.Title = "Wartości X";
                    chartFunkcji.ChartAreas[0].AxisY.Title = "Wartości F(x)";
                    x += h;

                }

                graf.Enabled = false;
            }
        }



        //------------------------------- EMPTY  -----------------------------------------------------//

        private void Form1_Load(object sender, EventArgs e)
        {

        }//// EMPTY
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//// EMPTY
        private void textBox1_TextChanged_2(object sender, EventArgs e) /// Obliczenie funkcji F(x)
        {

        }//// EMPTY
        private void chartFunkcji_Click(object sender, EventArgs e)
        {

        } //// EMPTY
        private void styliToolStripMenuItem_Click(object sender, EventArgs e)
        {

        } //// EMPTY


        //--------------------------------------- RESET ---------------------------------------------//

        private void button2_Click(object sender, EventArgs e) 
        {
            niezależna_X.Text = string.Empty;
            H.Text = string.Empty;
            Xd.Text = string.Empty;
            Xg.Text = string.Empty;
            Eps.Text = string.Empty;
            Otpow.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox1.Text = string.Empty;

            Table.Rows.Clear();
            Table.Refresh();
            Table.Visible = false;

            chartFunkcji.Series[0].Points.Clear();
            chartFunkcji.Refresh();
            chartFunkcji.Visible = false;

            wart.Enabled = true;
            tabel.Enabled = true;
            graf.Enabled = true;

            comboBox2.Text = "Wybór do wyświetlenia";
            comboBox1.Text = "Wybierz metodę całkowania";
        }  

        //------------------------------- READ AND WRITE -----------------------------------------------------//

        private void zapiszTablicęWPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog stf = new SaveFileDialog();

            if (stf.ShowDialog() == DialogResult.OK)

            {

                TextWriter writer = new StreamWriter(stf.FileName);
                for (int i = 0; i < Table.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < Table.Columns.Count; j++)
                    {
                        writer.Write("\t" + Table.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                    }

                    writer.WriteLine(" ");
                }
                writer.Close();
            }
        }

        private void odczytajTablicęZPlikuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog stf = new OpenFileDialog();

            
            if (stf.ShowDialog() == DialogResult.OK)

            {
                string[] lines = File.ReadAllLines(stf.FileName);
                string[] values;


                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('|');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    Table.Rows.Add(row);
                    Table.Visible = true;
                }
            }
        }

        //-------------------------------------CLOSE APP-----------------------------------------------//

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //----------------------------------- CHART COLOR -------------------------------------------------//

        private void kolorTłaWykresuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                chartFunkcji.BackColor = colorDialog1.Color;
            }
        }

        private void kolorLiniiWykresuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                chartFunkcji.Series["Wartość funkcji F(x)"].Color = colorDialog1.Color;
            }
        }

        private void kolorCzcionkiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
               
                chartFunkcji.ChartAreas[0].AxisX.LineColor = colorDialog1.Color;
                chartFunkcji.ChartAreas[0].AxisX.MajorGrid.LineColor = colorDialog1.Color;
                chartFunkcji.ChartAreas[0].AxisX.LabelStyle.ForeColor = colorDialog1.Color;

                chartFunkcji.ChartAreas[0].AxisY.LineColor = colorDialog1.Color;
                chartFunkcji.ChartAreas[0].AxisY.MajorGrid.LineColor = colorDialog1.Color;
                chartFunkcji.ChartAreas[0].AxisY.LabelStyle.ForeColor = colorDialog1.Color;
            }
        }

        //----------------------------------- STYLI LINII -------------------------------------------------//

        private void kropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
        }

        private void kreskowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
        }

        private void kreskowokropkowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
        }

        private void ciągłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
        }



        //------------------------------------ GRUBOŚĆ LINII ------------------------------------------------//
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderWidth = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderWidth = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderWidth = 3;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderWidth = 4;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderWidth = 5;
        }


        //----------------------------------- TRACKBAR -- GRUBOŚĆ LINII -------------------------------------------------//


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            chartFunkcji.Series["Wartość funkcji F(x)"].BorderWidth = trackBar1.Value;
        }


        //------------------------------------- KRÓJ PISMA -----------------------------------------------//
        private void krójPismaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = label1.Font;
            fontDialog1.Color = label1.ForeColor;

            fontDialog1.Font = label2.Font;
            fontDialog1.Color = label2.ForeColor;

            fontDialog1.Font = label3.Font;
            fontDialog1.Color = label3.ForeColor;

            fontDialog1.Font = label4.Font;
            fontDialog1.Color = label4.ForeColor;

            fontDialog1.Font = label5.Font;
            fontDialog1.Color = label5.ForeColor;

            fontDialog1.Font = label6.Font;
            fontDialog1.Color = label6.ForeColor;

            fontDialog1.Font = label12.Font;
            fontDialog1.Color = label12.ForeColor;

            fontDialog1.Font = label9.Font;
            fontDialog1.Color = label9.ForeColor;

            fontDialog1.Font = label10.Font;
            fontDialog1.Color = label10.ForeColor;

            fontDialog1.Font = label11.Font;
            fontDialog1.Color = label11.ForeColor;

            fontDialog1.Font = label8.Font;
            fontDialog1.Color = label8.ForeColor;

            fontDialog1.Font = label7.Font;
            fontDialog1.Color = label7.ForeColor;

            fontDialog1.Font = Otpow.Font;
            fontDialog1.Color = Otpow.ForeColor;

            fontDialog1.Font = niezależna_X.Font;
            fontDialog1.Color = niezależna_X.ForeColor;

            fontDialog1.Font = Eps.Font;
            fontDialog1.Color = Eps.ForeColor;

            fontDialog1.Font = Xd.Font;
            fontDialog1.Color = Xd.ForeColor;

            fontDialog1.Font = Xg.Font;
            fontDialog1.Color = Xg.ForeColor;

            fontDialog1.Font = H.Font;
            fontDialog1.Color = H.ForeColor;

            fontDialog1.Font = comboBox1.Font;
            fontDialog1.Color = comboBox1.ForeColor;

            fontDialog1.Font = button1.Font;
            fontDialog1.Color = button1.ForeColor;

            fontDialog1.Font = textBox6.Font;
            fontDialog1.Color = textBox6.ForeColor;

            fontDialog1.Font = textBox3.Font;
            fontDialog1.Color = textBox3.ForeColor;

            fontDialog1.Font = textBox4.Font;
            fontDialog1.Color = textBox4.ForeColor;

            fontDialog1.Font = textBox5.Font;
            fontDialog1.Color = textBox5.ForeColor;

            fontDialog1.Font = Grub.Font;
            fontDialog1.Color = Grub.ForeColor;

            fontDialog1.Font = wart.Font;
            fontDialog1.Color = wart.ForeColor;

            fontDialog1.Font = tabel.Font;
            fontDialog1.Color = tabel.ForeColor;

            fontDialog1.Font = graf.Font;
            fontDialog1.Color = graf.ForeColor;

            fontDialog1.Font = button2.Font;
            fontDialog1.Color = button2.ForeColor;


            


            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                label1.Font = fontDialog1.Font;
                label1.ForeColor = fontDialog1.Color;

                label2.Font = fontDialog1.Font;
                label2.ForeColor = fontDialog1.Color;

                label3.Font = fontDialog1.Font;
                label3.ForeColor = fontDialog1.Color;

                label4.Font = fontDialog1.Font;
                label4.ForeColor = fontDialog1.Color;

                label5.Font = fontDialog1.Font;
                label5.ForeColor = fontDialog1.Color;

                label6.Font = fontDialog1.Font;
                label6.ForeColor = fontDialog1.Color;

                label12.Font  = fontDialog1.Font;
                label12.ForeColor  = fontDialog1.Color;

                label9.Font = fontDialog1.Font ;
                label9.ForeColor = fontDialog1.Color ;

                label10.Font = fontDialog1.Font ;
                label10.ForeColor = fontDialog1.Color ;

                label11.Font = fontDialog1.Font ;
                label11.ForeColor = fontDialog1.Color ;

                label8.Font = fontDialog1.Font ;
                label8.ForeColor = fontDialog1.Color ;

                label7.Font = fontDialog1.Font ;
                label7.ForeColor = fontDialog1.Color ;

                Otpow.Font = fontDialog1.Font ;
                Otpow.ForeColor = fontDialog1.Color ;

                niezależna_X.Font = fontDialog1.Font ;
                niezależna_X.ForeColor = fontDialog1.Color ;

                Eps.Font = fontDialog1.Font ;
                Eps.ForeColor = fontDialog1.Color ;

                Xd.Font = fontDialog1.Font ;
                Xd.ForeColor = fontDialog1.Color ;

                Xg.Font = fontDialog1.Font ;
                Xg.ForeColor = fontDialog1.Color ;

                H.Font = fontDialog1.Font ;
                H.ForeColor = fontDialog1.Color ;

                comboBox1.Font  = fontDialog1.Font;
                comboBox1.ForeColor = fontDialog1.Color;

                button1.Font  = fontDialog1.Font;
                button1.ForeColor = fontDialog1.Color ;

                textBox6.Font = fontDialog1.Font ;
                textBox6.ForeColor = fontDialog1.Color ;

                textBox3.Font = fontDialog1.Font ;
                textBox3.ForeColor = fontDialog1.Color ;

                textBox4.Font = fontDialog1.Font ;
                textBox4.ForeColor = fontDialog1.Color ;

                textBox5.Font = fontDialog1.Font ;
                textBox5.ForeColor = fontDialog1.Color ;

                Grub.Font = fontDialog1.Font ;
                Grub.ForeColor = fontDialog1.Color;

                wart.Font = fontDialog1.Font ;
                wart.ForeColor = fontDialog1.Color ;

                tabel.Font = fontDialog1.Font ;
                tabel.ForeColor = fontDialog1.Color ;

                graf.Font = fontDialog1.Font ;
                graf.ForeColor = fontDialog1.Color ;

                button2.Font = fontDialog1.Font ;
                button2.ForeColor = fontDialog1.Color ;

                

            }
        }

        private void stylToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = Table.Font;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Table.Font = fontDialog1.Font;
            }
        }

        private void kolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Table.ForeColor;
            
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Table.ForeColor = colorDialog1.Color;
            }
        }

        private void kolorBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Table.DefaultCellStyle.BackColor;

            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Table.DefaultCellStyle.BackColor = colorDialog1.Color;
            }
        }


        //----------------------------------- OBLICZENIE CAŁKI METODĄ PROSTOKĄTÓ I TRAPEZÓW -------------------------------------------------//


        private void button1_Click(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            if (selected == "metodę prostokątów")
            {
                Table.Visible = true;

                

                    double sc = MetodProst(eps1, xd1, xg1, eps2, out int LicznikPrzedziałów, out double SzerokośćPrzedziału);
                    textBox6.Text = sc.ToString("0.00");

                    
                
            }

            if (selected == "metodę trapezów")
            {

                double tc = CałkaTrap(eps1, xd1, xg1, out int LicznikIteracji, out int n);
                textBox6.Text = tc.ToString("0.00");
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);

            if (selected == "Tabela")
            {
                chartFunkcji.Visible = false;
                Table.Visible = true;
            }

            if (selected == "Grafik")
            {
                Table.Visible = false;
                chartFunkcji.Visible = true;
            }
        }

        static double Sum(double x, double Eps, out int n)
        {

            double mpsum = 0;
            double mpprev = Eps + 1;
            n = 0;
            while (Math.Abs(mpsum - mpprev) >= Eps)
            {
                double fact;

                double up = Math.Pow((x + 1), n);

                fact = 1;
                for (int j = 1; j <= n; j++)
                {
                    fact *= j;
                }

                mpprev = mpsum;

                mpsum += up / fact;

                n++;

            }
            return mpsum;
        }
        
        private double MetodProst(double eps1, double xd1,double xg1, double eps2, out int LicznikPrzedziałów, out double SzerokośćPrzedziału )
        {
            int num = 0;
            double H, Ci, Ci_1, SumaFx;
            int LicznikWyrazówSzeregu;
            double X;

            LicznikPrzedziałów = 1;

            Ci = (xg1 - xd1) * Sum((xd1 - xg1) / 2.0F, eps1, out LicznikWyrazówSzeregu);

            do
            {
                Ci_1 = Ci;
                LicznikPrzedziałów = LicznikPrzedziałów + LicznikPrzedziałów;

                H = (xg1 - xd1) / LicznikPrzedziałów;

                X = xd1 + H / 2.0F;

                SumaFx = 0.0F;

                for (ushort i = 0; i < LicznikPrzedziałów; i++)
                {
                    SumaFx += Sum(X + i * H, eps1, out LicznikWyrazówSzeregu);
                }

                Ci = H * SumaFx;

                Table.Rows.Add(LicznikPrzedziałów, Ci.ToString("0.000"));

                num++;

            } while (Math.Abs(Ci - Ci_1) > eps2);

            SzerokośćPrzedziału = H;

            return Ci;
        }

        private double CałkaTrap(double xd1, double xg1, double eps1, out int LicznikIteracji, out int n)
        {
            double H, Ci, Ci_1, SumaFx;

            H = xg1 - xd1;

            double SumaFaFb = Sum(xd1, eps1, out n) + Sum(xg1, eps1, out n);

            Ci = H * SumaFaFb;
            LicznikIteracji = 1;

            do
            {
                Ci_1 = Ci;
                LicznikIteracji++;
                H = (xg1 - xd1) / LicznikIteracji;

                SumaFx = 0.0F;

                for (int j = 1; j < LicznikIteracji; j++)

                    SumaFx = SumaFx + Sum(xd1 + j * H, eps1, out n);

                Ci = H * (SumaFaFb + SumaFx);
                       
            } while (Math.Abs(Ci - Ci_1) > eps1);

            return Ci;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            niezależna_X.Text = string.Empty;
            H.Text = string.Empty;
            Xd.Text = string.Empty;
            Xg.Text = string.Empty;
            Eps.Text = string.Empty;
            Otpow.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox1.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            const bool t = true;
            const bool f = false;

            if (wart.Enabled == t && tabel.Enabled == t && graf.Enabled == t && button1.Enabled == t && button3.Enabled == t && button2.Enabled == t)
            {
                wart.Enabled = false;
                tabel.Enabled = false;
                graf.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
                button2.Enabled = false;
            }
            else if (wart.Enabled == f && tabel.Enabled == f && graf.Enabled == f && button1.Enabled == f && button3.Enabled == f && button2.Enabled == f)
            {
                wart.Enabled = true;
                tabel.Enabled = true;
                graf.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
