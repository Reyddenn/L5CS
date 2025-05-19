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

namespace L2CS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string filePath;
        string file;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).Replace(@"bin\Debug", "");
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        file = reader.ReadToEnd();
                    }
                }
            }

            string[] predl = file.Replace(". ", ".").Replace("? ", "?").Replace("! ", "!").Split(new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in predl)
            {      
                if(s.Length > 0 && isOneLetter(s.Split()[0])) 
                { textBox1.Text += s + Environment.NewLine; }
            }

            foreach (var s in predl)
            {
                if (s.Length > 0 && !isOneLetter(s.Split()[0])) 
                { textBox1.Text += s + Environment.NewLine; }
            }

        }

        bool isOneLetter(string word)
        {
            return word.Length == 1 && char.IsLetter(word[0]);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
