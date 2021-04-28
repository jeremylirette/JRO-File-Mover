using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace ReportRenamer
{
    public partial class Form1 : Form
    {
        private string num = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please ensure Reports are created before running", "", MessageBoxButtons.OK);
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            num = txtJobNum.Text;

            string path = "\\\\JRO-SERVER\\Jobs\\";
            if (chbShared.Checked)
            {
                path = "C:\\TeklaStructuresModels";
            }
            
            IEnumerable<string> list = Directory.GetDirectories(path, num + "*", SearchOption.TopDirectoryOnly);
            IEnumerator<string> s = list.GetEnumerator();
            if (s.MoveNext())
            { 
                if (!chbShared.Checked)
                {
                    path = s.Current + "\\x-steel";
                }
                list = Directory.GetDirectories(path, num + "*", SearchOption.TopDirectoryOnly);
                s = list.GetEnumerator();
                while (s.MoveNext())
                {
                    Reports(s.Current);
                }
                MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Unable to find job folder, please verify inputs and try again.");
                txtJobNum.Focus();
                txtJobNum.SelectAll();
            }
        }

        /// <summary>
        /// Goes to the Reports folder of the specified job, iterates through all reports, moving them to For Fabrication and renaming them.
        /// </summary>
        /// <param name="path">Path to job folder</param>
        /// <param name="forFab">Path to For Fabrication folder</param>
        private void Reports(string path)
        {
            try
            {
                path += "\\Reports";
                var files = Directory.EnumerateFiles(path, "*.xsr");
                foreach (string file in files)
                {
                    string text = File.ReadAllText(file);
                    text = text.Replace("NOTED", num);
                    File.WriteAllText(@"C:\Users\JeremyL\Desktop\Testing Folder\_Transmittal.xsr", text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,ex.GetType().ToString());
            }
        }

    }
}
