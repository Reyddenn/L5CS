/*
 * Задание 1
 * Вариант 15
Дана целочисленная квадратная матрица. Определить:
• сумму элементов в тех строках, которые не содержат отрицательных элементов;
• минимум среди сумм элементов диагоналей, параллельных главной диагонали матрицы.
   Задание 2
Написать программу, которая считывает текст из файла и выводит на экран сначала предложения, начинающиеся с однобуквенных слов, а затем все остальные.
 */



using L2CS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L5CS
{
    public partial class Form1 : Form
    {
        int n = 0;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try {  n = Convert.ToInt32(textBox1.Text); } 
            catch { MessageBox.Show("Неверный ввод!"); }
            int[,] matr = new int[n,n];
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = n+1;
            dataGridView1.Rows.Add(n);
            dataGridView1.Columns[n].Name = "Сумма";

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int temp = random.Next(-10, 10);
                    matr[i, j] = temp;
                    dataGridView1.Rows[i].Cells[j].Value = temp;
                }
            }
            
            for (int i = 0; i < n; i++)
            {
                int summ = 0;
                bool fl = true;
                for (int j = 0; j < n; j++)
                {
                    if (Int32.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) < 0) fl = false;
                    summ += Int32.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                if (fl) { 
                    dataGridView1.Rows[i].Cells[n].Value = summ;
                    dataGridView1.Rows[i].Cells[n].Style.BackColor = Color.FromArgb(112, 128, 144);
                }
            }

            int tmp;
            int min = 1000000;


            for (int t = 0; t < n-1; t++)
            {
                int i1 = 0;
                int i2 = t + 1;
                tmp = 0;

                while (i1 < n && i2 < n)
                {
                    tmp += Int32.Parse(dataGridView1.Rows[i1].Cells[i2].Value.ToString());
                    i1++; i2++;
                }

                min = Math.Min(tmp, min);
                i1 = 0;
                i2 = t + 1;
                tmp = 0;

                while (i1 < n && i2 < n)
                {
                    tmp += Int32.Parse(dataGridView1.Rows[i2].Cells[i1].Value.ToString());
                    i1++; i2++;
                }
                min = Math.Min(tmp, min);
            }

            label1.Text = "Минимум среди сумм\r\n элементов диагоналей,\r\n параллельных главной\r\n диагонали матрицы: " + min.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            this.Hide();
        }
    }
}
