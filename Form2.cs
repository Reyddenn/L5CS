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
        string fileContent;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)).Replace(@"bin\Debug", "");
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            
            string[] predl = fileContent.Split(new[] { '.', '?', '!' });
            for (int i = 0; i < predl.Length - 1; i++)
            {
                string t = predl[i];
                if (t[0] == ' ') { predl[i] = predl[i].Replace(" ", ""); }
            }

            string[][] words = new string[predl.Length][];
            for (int i = 0; i < predl.Length; i++)
            {
                words[i] = predl[i].Split(' ');
            }

            string final = "";
            for(int i = 0; i < predl.Length-1; i++)
            {
                if (words[i][1] == " ") {
                    string temp = "";
                    for (int j = 0; j < words[i].Length; j++) {
                        temp += words[i][j] + " ";
                    }
                    final = final + "." + temp;
                }
                else
                {
                    string temp = "";
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        temp += words[i][j] + " ";
                    }
                    final = temp + "." + final;
                }

            }

            textBox1.Text = final;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
