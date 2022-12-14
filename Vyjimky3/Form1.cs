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

namespace Vyjimky3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int n = Int32.Parse(textBox1.Text);
                if (n <= 0) { throw new Exception("Zadej větší číslo!"); }
                int cisel = 0;
                double soucet = 0;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        string s = "";
                        BinaryReader br = new BinaryReader(fs);
                        while (cisel < n)
                        {
                            char ch = br.ReadChar();
                            if ((int)ch == 46) { ch = ','; } 
                            s += ch;

                            if ((int)ch == 13){
                                soucet += Double.Parse(s);
                                s = "";
                                cisel++;
                            }
                        }
                    }
                    soucet /= n;
                    MessageBox.Show("Aritmeticky prumer prvnich cisel je " + soucet);
                }
            }
            catch (OverflowException) { 
                MessageBox.Show("Preteceni, zadej mensi cislo!"); 
            }
            catch (FormatException) { 
                MessageBox.Show("Špatný formát!");
            }
            catch (FileNotFoundException) { 
                MessageBox.Show("Soubor nebyl nalezen!"); 
            }
            catch (EndOfStreamException) { 
                MessageBox.Show("Konec streamu, zadej mensi cislo!");
            }
            catch (DivideByZeroException) { 
                MessageBox.Show("Deleni nulou!"); 
            }
            catch (Exception exception) { 
                MessageBox.Show(exception.Message);
            }
        }
    }
}
