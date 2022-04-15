using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lb3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Filter = "(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.FileName = "";
            saveFileDialog1.Filter = "(*.txt)|*.txt|All files(*.*)|*.*";

            panel1.Visible = true;
            panel2.Visible = false;
        }

        public void p_numb(KeyPressEventArgs e)
        {
            char key = e.KeyChar;

            if (!Char.IsDigit(key) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        public bool Ferma(int num)
        {
            Random random = new Random();
            int raz = 5;
            if (num > 1)
            {
                while (raz > 0)
                {
                    int i = random.Next(1, num - 1);
                    var n = BigInteger.ModPow(i, num - 1, num);
                    if (n != 1)
                    {
                        return false;
                    }
                    raz--;
                }
            }       
            return true;      
        }
        public int Evklid(int i, int f)
        {
            if (i == 0)
                return f;
            return Evklid(f % i, i);
        }

        public int E(int f)
        {
            int e = 0;

            for (int i = 2; i < f; i++)
            {
                if (Ferma(i))
                {
                    if (Evklid(i, f) == 1)
                    {
                        e = i;
                        break;
                    }
                }
            }
            return e;
        }

        BigInteger Power(BigInteger x, int y, int N)
        {
            if (y == 0) return 1;
            BigInteger z = Power(x, y / 2, N);
            if (y % 2 == 0)
                return (z * z) % N;
            else
                return (x * z * z) % N;
        }


         int p = 0;
         int q = 0;
         int n = 0;
         int f = 0;
         int e = 0;
         int d = 0; 
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p_numb(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            p_numb(e);
        }

        private void button1_Click(object sender, EventArgs ee)
        {
            if (!String.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox2.Clear();
            string str = "";
            p = Convert.ToInt32(textBox1.Text);
            q = Convert.ToInt32(textBox2.Text);
            try
            {
                if (Ferma(p) && Ferma(q))
                {                   
     
                byte[] txt = Encoding.GetEncoding(1251).GetBytes(richTextBox1.Text);


                for (int i = 0; i < txt.Length; i++)
                {
                    richTextBox2.Text += txt[i] + " ";
                }              
                    n = p * q;
                    f = (p - 1) * (q - 1);
                    e = E(f);
                    textBox8.Text = e.ToString();
                    textBox4.Text = n.ToString();

                    for (int i = 2; i <= f; i++)
                    {
                        if (i * e % f == 1)
                        {
                            d = i;
                            textBox3.Text = d.ToString();
                            textBox5.Text = n.ToString();
                        }
                    }
                    for (int i = 0; i < txt.Length; i++)
                    {
                    BigInteger zn = Power(txt[i],e,n);
                        str += zn.ToString() + " ";
                    }

                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = saveFileDialog1.FileName;
                    System.IO.File.WriteAllText(filename, str);
                    Process.Start(filename);           
                }
                else
                {
                    MessageBox.Show("Введите простые числа");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля");
            }
            }
            else
                MessageBox.Show("Введите текст");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {          
            d = Convert.ToInt32(textBox3.Text);
            n = Convert.ToInt32(textBox5.Text);

            if ((Evklid(d, f) == 1))
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);

            textBox7.Clear();

            string x = fileText;
            x = x.Remove(x.Length - 1);

            int[] arrStr = Array.ConvertAll(x.Split(' '), int.Parse);
                
                for (int j = 0; j < arrStr.Length; j++)
            {
               BigInteger zn = Power(arrStr[j], d,n);

                string ascii = Encoding.GetEncoding(1251).GetString(zn.ToByteArray());

                textBox7.Text += ascii;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename2 = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename2, textBox7.Text);
            Process.Start(filename2);
            }
            else
                    if (!(Evklid(d, f) == 1))
                MessageBox.Show("d - не подходит!");
            }
            catch (FormatException){}
        }
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int col = 0;
            int i,j=0;
            int[] mas = new int[2];

            Random random = new Random();

            while (col !=2)
            {
                i = random.Next(101, 10000);
                if (Ferma(i))
                {
                    mas[j] = i;
                    col++;
                    j++;
                }
            }
            textBox1.Text = mas[0].ToString();
            textBox2.Text = mas[1].ToString();
        }

        int e_p = 0;
        int e_g = 0;
        int e_x = 0;
        BigInteger e_y = 0;
        int e_k = 0;
        BigInteger e_a = 0;
        BigInteger e_b = 0;
        BigInteger Power2(BigInteger x, int y)
        {
            if (y == 0) return 1;
            BigInteger z = Power2(x, y / 2);
            if (y % 2 == 0)
                return (z * z);
            else
                return (x * z * z);
        }

        public int dividMinusP(int p)
        {
            List<int> set = new List<int>();
            Random random = new Random();

            for (int i = 2; i < p; i++) {
                if (calcG(p, i)) {
                    set.Add(i);
               }             
            }
            int index = random.Next(0, set.Count);

            return set[index];
        }

        public bool calcG(int p, int a)
        {
            int last = 1;
            List<int> set = new List<int>();
            for (int i = 0; i < p - 1; i++)
            {
                last = (last * a) % p;
                if (set.FindAll(x => x == last).Count > 0)
                    return false;
                set.Add(last);
            }
            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(richTextBox3.Text))
                {
                    e_p = Convert.ToInt32(textBox6.Text);
                    e_x = Convert.ToInt32(textBox10.Text);
                    e_k = Convert.ToInt32(textBox12.Text);
                    e_g = Convert.ToInt32(textBox9.Text);

                    if (Ferma(e_p))
                    {
                        if (Evklid(e_x, e_p - 1) == 1 && 1 < e_x && e_x < e_p - 1)
                        {
                            if (Evklid(e_k, e_p - 1) == 1 && 1 < e_k && e_k < e_p - 1)
                            {
                                if (calcG(e_p, e_g))
                                {
                                    richTextBox4.Clear();
                                    string str = "";

                                    byte[] txt = Encoding.GetEncoding(1251).GetBytes(richTextBox3.Text);

                                    for (int i = 0; i < txt.Length; i++)
                                    {
                                        richTextBox4.Text += txt[i] + " ";
                                    }

                                    for (int i = 0; i < txt.Length; i++)
                                    {
                                        e_a = Power(e_g, e_k, e_p);
                                        e_b = (Power2(e_y, e_k) * txt[i]) % e_p;
                                        str += e_a.ToString() + " " + e_b.ToString() + " ";
                                    }

                                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                                        return;
                                    string filename = saveFileDialog1.FileName;
                                    System.IO.File.WriteAllText(filename, str);
                                    Process.Start(filename);
                                }
                                else
                                    MessageBox.Show("G не подходит");
                            }
                            else
                                MessageBox.Show("K не подходит");
                        }
                        else
                            MessageBox.Show("X не подходит");
                    }
                    else
                        MessageBox.Show("Введите простое p");
                }
                else
                    MessageBox.Show("Введите текст");
            }
            catch (Exception)
            { }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            bool raz = true;
            while (raz)
            {
                int i1 = random.Next(500, 1000);
                if (Ferma(i1))
                {
                    e_p = i1;
                    textBox6.Text = e_p.ToString();
                    raz = false;
                }
            }

            textBox6.Text = e_p.ToString();
            bool b = true;

            while (b)
            {
                e_x = random.Next(1, e_p);
                if (Evklid(e_x, e_p - 1) == 1 && 1 < e_x && e_x < e_p - 1)
                {
                    textBox10.Text = e_x.ToString();
                    b = false;
                }
            }

            bool c = true;
            while (c)
            {
                e_k = random.Next(1, e_p);
                if (Evklid(e_k, e_p - 1) == 1 && 1 < e_k && e_k < e_p - 1)
                {
                    textBox12.Text = e_k.ToString();
                    c = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox5.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);

            string x = fileText;
            x = x.Remove(x.Length - 1);

            int[] arrStr = Array.ConvertAll(x.Split(' '), int.Parse);
            int[] arrStr2 = new int[arrStr.Length/2];
            int[] arrStr3 = new int[arrStr.Length/2];

            int j = 0;
            int j2 = 0;

            for (int i = 0; i < arrStr.Length; i += 2)
            {
                arrStr2[j] = arrStr[i];
                j++;             
            }
            for (int i = 1; i < arrStr.Length; i += 2)
            {
                arrStr3[j2] = arrStr[i];
                j2++;
            }
            BigInteger m;
            for (int i = 0; i < arrStr2.Length; i++)
            {
                m = arrStr3[i] * Power2(arrStr2[i], e_p - 1 - e_x);
                m = m % e_p;
                string ascii = Encoding.GetEncoding(1251).GetString(m.ToByteArray());
                richTextBox5.Text += ascii.ToString();
         
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename2 = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename2, richTextBox5.Text);
            Process.Start(filename2);
            }
            catch (Exception)
            { }
        }
        private void richTextBox3_Click(object sender, EventArgs e)
        {
            richTextBox4.Clear();

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)               
                return;

            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox3.Text = fileText;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {         
            e_g = dividMinusP(e_p);
            textBox9.Text = e_g.ToString();

            e_y = Power(e_g, e_x, e_p);
            textBox11.Text = e_y.ToString();
            }
            catch (Exception)
            {}
        }
    }
}
