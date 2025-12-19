using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ReportRenamer
{
    public partial class Form1 : Form
    {
        private string num = "";
        private string structNum = "";
        private string destNum = "";
        private string rev = "";
        private string phase = "";
        private string iss = "";
        private string forFab = "";
        private string forFabRoot = "";
        private string forFabZip = "";
        private string modelNum = "";
        private string powerfabDrawings = "";
        private bool fabtrol = false;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display splash message, hide uneeded controls, check Powerfab radio button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please ensure Reports,NC Files, and all Drawings are created before running.", "", MessageBoxButtons.OK);
            lblStruct.Hide();
            lblStruct2.Hide();
            txtStruct.Hide();
            rdoPowerfab.Checked = true;
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            num = txtJobNum.Text;
            structNum = txtStruct.Text;
            if (num.Contains("SJ"))
            {
                destNum = "0" + num;
            }
            else
            {
                destNum = num;
            }

            if (chbSplit.Checked)
            {
                modelNum = txtStruct.Text;
            }
            else
            {
                modelNum = num;
            }

            phase = txtPhase.Text;
            rev = "R" + txtRevision.Text;

            if (phase.Contains("ISS"))
            {
                int issStart = phase.IndexOf("ISS") + 3;
                iss = phase.Substring(issStart, 1);

                int phaseEnd = issStart - 4;
                phase = phase.Substring(0, phaseEnd);
            }
            else
            {
                iss = "";
            }

            string path = "\\\\JRO-FS\\Jobs\\";
            if (chbShared.Checked)
            {
                path = "C:\\TeklaStructuresModels";
            }

            IEnumerable<string> list = Directory.GetDirectories(path, modelNum + "*", SearchOption.TopDirectoryOnly);
            IEnumerator<string> s = list.GetEnumerator();
            if (s.MoveNext())
            {
                if (chbShared.Checked)
                {
                    IEnumerable<string> l = Directory.GetDirectories("\\\\JRO-FS\\Jobs\\", destNum + "*", SearchOption.TopDirectoryOnly);
                    IEnumerator<string> s2 = l.GetEnumerator();
                    if (s2.MoveNext())
                    {
                        forFabRoot = s2.Current + "\\to Send\\For Fabrication\\";
                        if (iss != "")
                        {
                            forFabZip = s2.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase + "#" + iss;
                            forFab = s2.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase + "#" + iss + "\\" + rev;
                            powerfabDrawings = s2.Current + "\\to Send\\For Fabrication\\Drawings For Records" + num + " " + phase + "#" + iss;
                        }
                        else
                        {
                            forFabZip = s2.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase;
                            forFab = s2.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase + "\\" + rev;
                            powerfabDrawings = s2.Current + "\\to Send\\For Fabrication\\Drawings For Records - " + num + " " + phase;
                        }
                    }
                }
                else
                {
                    forFabRoot = s.Current + "\\to Send\\For Fabrication\\";
                    if (iss != "")
                    {
                        forFabZip = s.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase + "#" + iss;
                        forFab = s.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase + "#" + iss + "\\" + rev;
                    }
                    else
                    {
                        forFabZip = s.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase;
                        forFab = s.Current + "\\to Send\\For Fabrication\\" + num + "_" + DateTime.Now.ToString("MMM dd") + " " + phase + "\\" + rev;
                    }
                }

                if (!Directory.Exists(forFab))
                {
                    Directory.CreateDirectory(forFab);
                    Directory.CreateDirectory(forFab);
                    if (fabtrol)
                    {
                        Directory.CreateDirectory(forFab + "\\Fabrication");
                        Directory.CreateDirectory(forFab + "\\Parts");
                    }
                    if (!fabtrol)
                    {
                        Directory.CreateDirectory(powerfabDrawings + "\\Fabrication");
                        Directory.CreateDirectory(powerfabDrawings + "\\Parts");
                    }
                }
                if (!chbShared.Checked)
                {
                    path = s.Current + "\\x-steel";
                }
                list = Directory.GetDirectories(path, modelNum + "*", SearchOption.TopDirectoryOnly);
                s = list.GetEnumerator();
                while (s.MoveNext())
                {
                    NCFiles(s.Current);

                    if (chbSplit.Checked)
                    {
                        SwitchJobNumber(s.Current);
                    }

                    Reports(s.Current);

                    if (fabtrol)
                    {
                        Drawings(s.Current);

                        SWFWSADrawings(s.Current);
                    }

                    if (!fabtrol)
                    {
                        string PowerfabFolder = forFab + "\\Powerfab";
                        if (!Directory.Exists(PowerfabFolder))
                        {
                            Directory.CreateDirectory(PowerfabFolder);
                            Powerfab(s.Current);
                            PowerfabDrawings(s.Current);
                        }

                    }
                    DXFFiles(s.Current);
                    STPFiles(s.Current);
                    TubeNCFile(s.Current);
                    EDrawings(s.Current);
                }
                Zip();
                MessageBox.Show("Completed. Please verify that everything was moved/renamed properly before sending.");
            }
            else
            {
                MessageBox.Show("Unable to find job folder, please verify inputs and try again.");
                txtJobNum.Focus();
                txtJobNum.SelectAll();
            }
        }

        /// <summary>
        /// Move and rename Powerfab
        /// </summary>
        /// <param name="path"></param>
        private void Powerfab(string path)
        {
            try
            {
                if(Directory.Exists(path + "\\Tekla EPM"))
                {
                    path += "\\Tekla EPM";
                }
                else
                {
                    path += "\\Tekla PowerFab";
                }
                
                if (chbSplit.Checked)
                {
                    string newNum = num;
                    string oldNum = structNum;
                    var filesPF = Directory.EnumerateFiles(path);
                    foreach (string file in filesPF)
                    {
                        string oldFile = file;

                        int startIndex = file.LastIndexOf("\\") + 1;
                        string oldName = file.Substring(startIndex, file.Length - startIndex);

                        oldName = oldName.Remove(0, 6);

                        string newName = newNum + oldName;

                        string newFile = oldFile.Remove(startIndex, file.Length - startIndex) + newName;

                        //File.Copy(oldFile, newFile);

                        //File.Delete(oldFile);

                        string extractPath = newFile.Remove(newFile.Length - 4, 4);

                        ZipFile.ExtractToDirectory(newFile, extractPath);
                        File.Delete(newFile);

                        var files2 = Directory.EnumerateFiles(extractPath);
                        foreach (string file2 in files2)
                        {
                            if (file2.Contains(".xml"))
                            {
                                //int startIndex2 = file2.LastIndexOf(oldNum);
                                //string tempName = file2.Substring(startIndex2, file2.Length - startIndex2);
                                //tempName = tempName.Replace(oldNum, newNum);

                                //string newXML = file2.Remove(startIndex2, tempName.Length) + tempName;

                                //File.Move(file2, newXML);

                                XmlDocument doc = new XmlDocument();

                                doc.Load(file2);

                                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                                {
                                    if (node.Name == "ProjectData")
                                    {
                                        foreach (XmlNode node2 in node.ChildNodes)
                                        {
                                            if (node2.Name == "ContractData")
                                            {
                                                foreach (XmlNode node3 in node2.ChildNodes)
                                                {
                                                    if (node3.Name == "ProjectId")
                                                    {
                                                        foreach (XmlNode node4 in node3.ChildNodes)
                                                        {
                                                            if (node4.Name == "ProjectNumber")
                                                            {
                                                                node4.InnerText = newNum;
                                                                doc.Save(file2);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        ZipFile.CreateFromDirectory(extractPath, newFile);
                        Directory.Delete(extractPath, true);
                    }
                }
                var files = Directory.EnumerateFiles(path);
                foreach (string file in files)
                {
                    string destination = forFab + "\\Powerfab\\" + num + "_" + phase + "-ISS" + iss + "_" + rev + ".zip";
                    string extractPath = file.Remove(file.Length - 4, 4);
                    ZipFile.ExtractToDirectory(file, extractPath);
                    File.Delete(file);
                    var files2 = Directory.EnumerateFiles(extractPath);
                    foreach (string file2 in files2)
                    {
                        if (file2.Contains(".xml"))
                        {
                            int startIndex = file2.LastIndexOf(num);
                            string tempName = file2.Substring(startIndex, file2.Length - startIndex);
                            string newXML = file2.Remove(startIndex, tempName.Length);
                            tempName = tempName.Remove(0, tempName.Length - 4);
                            tempName = num + "_" + phase + "-ISS" + iss + "_" + rev + tempName;
                            newXML = newXML + tempName;
                            File.Move(file2, newXML);
                            ZipFile.CreateFromDirectory(extractPath, file);
                            Directory.Delete(extractPath, true);
                        }
                        
                    }
                    File.Move(file, destination);
                    File.Delete(file);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Create Zip folder of package (Drawings, Reports, NC Files)
        /// </summary>
        private void Zip()
        {
            try
            {
                string startPath = forFabZip;
                string zipPath = forFabZip + ".zip";
                if (!File.Exists(zipPath))
                {
                    ZipFile.CreateFromDirectory(startPath, zipPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Move and sort drawings. (Erection Drawings)
        /// </summary>
        /// <param name="path"></param>
        private void EDrawings(string path)
        {
            try
            {
                path += "\\Plotfiles";
                string search = num + "_" + phase + "*" + ".pdf";
                var files = Directory.EnumerateFiles(path, search);
                foreach (string file in files)
                {
                    if (file.Contains(phase))
                    {
                        string destination = forFabRoot + Path.GetFileName(file);
                        File.Move(file, destination);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Move and sort drawings. (Field Work, Shop Work, Shop Assembly)
        /// </summary>
        /// <param name="path"></param>
        private void SWFWSADrawings(string path)
        {
            try
            {
                path += "\\Plotfiles";
                var files = Directory.EnumerateFiles(path);
                foreach (string file in files)
                {

                    string destinationFW = forFab + "\\Field Work Drawings\\";
                    string destinationSW = forFab + "\\Shop Work Drawings\\";
                    string destinationSA = forFab + "\\Shop Assembly Drawings\\";

                    if (!Directory.Exists(destinationFW))
                    {
                        Directory.CreateDirectory(destinationFW);
                    }
                    if (!Directory.Exists(destinationSW))
                    {
                        Directory.CreateDirectory(destinationSW);
                    }
                    if (!Directory.Exists(destinationSA))
                    {
                        Directory.CreateDirectory(destinationSA);
                    }

                    if (file.Contains("JFW"))
                    {
                        File.Move(file, destinationFW + Path.GetFileName(file));
                    }
                    if (file.Contains("JSW"))
                    {
                        File.Move(file, destinationSW + Path.GetFileName(file));
                    }
                    if (file.Contains("JSA") || file.Contains("SA"))
                    {
                        File.Move(file, destinationSA + Path.GetFileName(file));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void PowerfabDrawings(string path)
        {
            try
            {
                path += "\\Plotfiles";
                string search = "";
                if (iss != "")
                {
                    search = "*" + phase + "-ISS" + iss + ".pdf";
                }
                else
                {
                    search = "*" + phase + ".pdf";
                }
                var files = Directory.EnumerateFiles(path, search);
                foreach (string file in files)
                {
                    string destinationPart = powerfabDrawings + "\\Parts\\" + Path.GetFileName(file);
                    string destinationFabrication = powerfabDrawings + "\\Fabrication\\" + Path.GetFileName(file);
                    if (file.Contains("LM"))
                    {
                        File.Move(file, destinationPart);
                    }
                    else
                    {
                        File.Move(file, destinationFabrication);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void TubeNCFile(string path)
        {
            try
            {
                var files = Directory.EnumerateFiles(path);
                foreach(string file in files)
                {
                    if (file.Contains("TubeNC.xml"))
                    {
                        string newXML = forFab + "\\" + num + "_" + phase + "-ISS" + iss + "_" + rev + "_" + "TubeNC.xml";
                        File.Move(file, newXML);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DXFFiles(string path)
        {
            try
            {
                Directory.CreateDirectory(forFab + "\\DXF Files");
                path += "\\plotfiles";
                string search = "*.dxf";
                var files = Directory.EnumerateFiles(path, search);
                foreach (string file in files)
                {
                    string destination = forFab + "\\DXF Files\\" + Path.GetFileName(file);
                    File.Move(file, destination);
                }

                if(IsDirectoryEmpty(forFab + "\\DXF Files"))
                {
                    Directory.Delete(forFab + "\\DXF Files");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void STPFiles(string path)
        {
            try
            {
                string STPpath = path + "\\STP_files";
                Directory.CreateDirectory(forFab + "\\STP Files");
                if (Directory.Exists(STPpath))
                {
                    string[] files = Directory.GetFiles(STPpath);

                    foreach (string s in files)
                    {
                        string fileName = Path.GetFileName(s);
                        string destFile = Path.Combine(forFab + "\\STP Files", fileName);
                        File.Copy(s, destFile, true);
                        File.Delete(s);
                    }
                }
                if (IsDirectoryEmpty(forFab + "\\STP Files"))
                {
                    Directory.Delete(forFab + "\\STP Files");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Move and sort drawings. (Parts and Fabrication)
        /// </summary>
        /// <param name="path"></param>
        private void Drawings(string path)
        {
            try
            {
                path += "\\Plotfiles";
                string search = "";
                if (iss != "")
                {
                    search = "*" + phase + "-ISS" + iss + ".pdf";
                }
                else
                {
                    search = "*" + phase + ".pdf";
                }
                var files = Directory.EnumerateFiles(path, search);
                foreach (string file in files)
                {
                    string destinationPart = forFab + "\\Parts\\" + Path.GetFileName(file);
                    string destinationFabrication = forFab + "\\Fabrication\\" + Path.GetFileName(file);
                    if (file.Contains("LM"))
                    {
                        File.Move(file, destinationPart);
                    }
                    else
                    {
                        File.Move(file, destinationFabrication);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
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
                    int startIndex = file.LastIndexOf("\\") + 1;
                    string f = file.Substring(startIndex, file.Length - startIndex);

                    if (iss != "")
                    {
                        switch (f)
                        {
                            case "_Bolt_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_BL_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_Bought Out Items list.xsr":
                                File.Move(file, forFab + "\\" + num + "_BOI_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_FabTrol Assembly Parts List-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_ISS" + iss + "_" + rev + "_FabTrol Assembly Parts List-v30.xsr");
                                break;
                            case "_FabTrol Drawing List-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_ISS" + iss + "_" + rev + "_FabTrol Drawing List-v30.xsr");
                                break;
                            case "_FabTrol Drawing Revision List-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_ISS" + iss + "_" + rev + "_FabTrol Drawing Revision List-v30.xsr");
                                break;
                            case "_FabTrol Assembly Parts List Metric-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_ISS" + iss + "_" + rev + "_FabTrol Assembly Parts List Metric-v30.xsr");
                                break;
                            case "_FabTrol Drawing List Metric-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_ISS" + iss + "_" + rev + "_FabTrol Drawing List Metric-v30.xsr");
                                break;
                            case "_FabTrol Drawing Revision List Metric-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_ISS" + iss + "_" + rev + "_FabTrol Drawing Revision List Metric-v30.xsr");
                                break;
                            case "_Material_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_ML_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_Shop-Bolt_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_SBL_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_Std_Part_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_STD_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_Std_Part_List_Field.xsr":
                                File.Move(file, forFab + "\\" + num + "_STDF_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_Stud List.xsr":
                                File.Move(file, forFab + "\\" + num + "_SL_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_Transmittal.xsr":
                                File.Move(file, forFab + "\\" + num + "_TM_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                            case "_GRIP SPAN PURCHASE list.xsr":
                                File.Move(file, forFab + "\\" + num + "_BOI_" + phase + "_ISS" + iss + "_" + rev + ".xsr");
                                break;
                        }
                    }
                    else
                    {
                        switch (f)
                        {
                            case "_Bolt_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_BL_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_Bought Out Items list.xsr":
                                File.Move(file, forFab + "\\" + num + "_BOI_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_FabTrol Assembly Parts List-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_" + rev + "_FabTrol Assembly Parts List-v30.xsr");
                                break;
                            case "_FabTrol Drawing List-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_" + rev + "_FabTrol Drawing List-v30.xsr");
                                break;
                            case "_FabTrol Drawing Revision List-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_" + rev + "_FabTrol Drawing Revision List-v30.xsr");
                                break;
                            case "_FabTrol Assembly Parts List Metric-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_" + rev + "_FabTrol Assembly Parts List Metric-v30.xsr");
                                break;
                            case "_FabTrol Drawing List Metric-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_" + rev + "_FabTrol Drawing List Metric-v30.xsr");
                                break;
                            case "_FabTrol Drawing Revision List Metric-v30.xsr":
                                File.Move(file, forFab + "\\" + num + "_" + phase + "_" + rev + "_FabTrol Drawing Revision List Metric-v30.xsr");
                                break;
                            case "_Material_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_ML_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_Shop-Bolt_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_SBL_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_Std_Part_List.xsr":
                                File.Move(file, forFab + "\\" + num + "_STD_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_Stud List.xsr":
                                File.Move(file, forFab + "\\" + num + "_SL_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_Transmittal.xsr":
                                File.Move(file, forFab + "\\" + num + "_TM_" + phase + "_" + rev + ".xsr");
                                break;
                            case "_GRIP SPAN PURCHASE list.xsr":
                                File.Move(file, forFab + "\\" + num + "_BOI_" + phase + "_" + rev + ".xsr");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        /// <summary>
        /// Check if NC Files exist, move and rename the folder if they do.
        /// </summary>
        /// <param name="path">Path to job folder</param>
        /// <param name="forFab">Path to For Fabrication folder</param>
        private void NCFiles(string path)
        {
            try
            {
                string ncPath = path + "\\NC_files";
                if (Directory.Exists(ncPath))
                {
                    if (!chbShared.Checked)
                    {
                        Directory.Move(ncPath, forFab + "\\CNCData");
                    }
                    else
                    {
                        Directory.CreateDirectory(forFab + "\\CNCData");
                        string[] files = Directory.GetFiles(ncPath);

                        foreach (string s in files)
                        {
                            string fileName = Path.GetFileName(s);
                            string destFile = Path.Combine(forFab + "\\CNCData", fileName);
                            File.Copy(s, destFile, true);
                            File.Delete(s);
                        }

                        string[] dirs = Directory.GetDirectories(ncPath);

                        foreach (string s in dirs)
                        {
                            string dirName = Path.GetFileName(s);
                            string ncPath2 = ncPath + "\\" + dirName;

                            Directory.CreateDirectory(forFab + "\\CNCData\\" + dirName);
                            string[] files2 = Directory.GetFiles(ncPath2);

                            foreach (string s2 in files2)
                            {
                                string fileName = Path.GetFileName(s2);
                                string destFile = Path.Combine(forFab + "\\CNCData\\" + dirName, fileName);
                                File.Copy(s2, destFile, true);
                                File.Delete(s2);
                            }
                            Directory.Delete(ncPath2);

                        }

                        Directory.Delete(ncPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Find and replace Structural Job Number with Misc Job Number on Reports
        /// </summary>
        /// <param name="path"></param>
        private void SwitchJobNumber(string path)
        {
            try
            {
                #region Reports
                path += "\\Reports";
                var files = Directory.EnumerateFiles(path, "*.xsr");
                foreach (string file in files)
                {
                    int startIndex = file.LastIndexOf("\\") + 1;
                    string f = file.Substring(startIndex, file.Length - startIndex);

                    string fileText = File.ReadAllText(file);
                    fileText = fileText.Replace(structNum, num);
                    File.WriteAllText(file, fileText);
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void chbSplit_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSplit.Checked)
            {
                lblStruct.Show();
                lblStruct2.Show();
                txtStruct.Show();
            }
            else
            {
                lblStruct.Hide();
                lblStruct2.Hide();
                txtStruct.Hide();
            }
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
