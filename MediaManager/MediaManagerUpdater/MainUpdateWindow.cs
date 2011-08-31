using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace MediaManagerUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                WebClient wcDownloader = new WebClient();
                textBox1.AppendText("Checking MediaManager.exe\n");
                #region MediaManager.exe
                if (!File.Exists("MediaManager.exe"))
                {
                    textBox1.AppendText("No MediaManager.exe found, downloading latest version.\n");
                    wcDownloader.DownloadFile("https://github.com/downloads/mmatt555/Media-Manager/MediaManager.exe", "MediaManager.exe");
                    textBox1.AppendText("MediaManager.exe successfully downloaded from (https://github.com/downloads/mmatt555/Media-Manager/MediaManager.exe)\n");
                }
                else
                {
                    textBox1.AppendText("Downloading MediaManager.exe...\n");
                    wcDownloader.DownloadFile("https://github.com/downloads/mmatt555/Media-Manager/MediaManager.exe", "MediaManagerUpdate.exe");
                    textBox1.AppendText("File Downloaded.\n");
                    if (!FilesAreEqual("MediaManager.exe", "MediaManagerUpdate.exe"))
                    {
                        textBox1.AppendText("Update found, replacing MediaManager.exe");
                        File.Delete("MediaManager.exe");
                        File.Move("MediaManagerUpdate.exe", "MediaManager.exe");

                    }
                    else
                    {
                        textBox1.AppendText("MediaManager.exe up to date.\n");
                        File.Delete("MediaManagerUpdate.exe");
                    }
                }
                #endregion

                textBox1.AppendText("Checking MediaManager.exe.config\n");
                #region MediaManager.exe.config
                if (!File.Exists("MediaManager.exe.config"))
                {
                    textBox1.AppendText("No MediaManager.exe.config found, downloading latest version.\n");
                    wcDownloader.DownloadFile("https://github.com/downloads/mmatt555/Media-Manager/MediaManager.exe.config", "MediaManager.exe.config");
                    textBox1.AppendText("MediaManager.exe.config successfully downloaded from (https://github.com/downloads/mmatt555/Media-Manager/MediaManager.exe.config)\n");
                }
                else
                {
                    textBox1.AppendText("Downloading MediaManager.exe.config...\n");
                    wcDownloader.DownloadFile("https://github.com/downloads/mmatt555/Media-Manager/MediaManager.exe.config", "MediaManagerUpdate.exe.config");
                    textBox1.AppendText("File Downloaded.\n");
                    if (!FilesAreEqual("MediaManager.exe.config", "MediaManagerUpdate.exe.config"))
                    {
                        textBox1.AppendText("Update found, replacing MediaManager.exe.config");
                        File.Delete("MediaManager.exe.config");
                        File.Move("MediaManagerUpdate.exe.config", "MediaManager.exe.config");

                    }
                    else
                    {
                        textBox1.AppendText("MediaManager.exe.config up to date.\n");
                        File.Delete("MediaManagerUpdate.exe.config");
                    }
                }
                
                #endregion

                textBox1.AppendText("Checking System.Data.SQLite.dll\n");
                if (!File.Exists("System.Data.SQLite.dll"))
                {
                    textBox1.AppendText("No System.Data.SQLite.dll found, downloading latest version.\n");
                    wcDownloader.DownloadFile("https://github.com/downloads/mmatt555/Media-Manager/System.Data.SQLite.txt", "System.Data.SQLite.dll");
                    textBox1.AppendText("System.Data.SQLite.dll successfully downloaded from (https://github.com/downloads/mmatt555/Media-Manager/System.Data.SQLite.txt)\n");
                }
                else
                {
                    textBox1.AppendText("Downloading System.Data.SQLite.dll...\n");
                    wcDownloader.DownloadFile("https://github.com/downloads/mmatt555/Media-Manager/System.Data.SQLite.txt", "System.Data.SQLiteUpdate.dll");
                    textBox1.AppendText("File Downloaded.\n");
                    if (!FilesAreEqual("System.Data.SQLite.dll", "System.Data.SQLiteUpdate.dll"))
                    {
                        textBox1.AppendText("Update found, replacing System.Data.SQLite.dll");
                        File.Delete("System.Data.SQLite.dll");
                        File.Move("System.Data.SQLiteUpdate.dll", "System.Data.SQLite.dll");

                    }
                    else
                    {
                        textBox1.AppendText("System.Data.SQLite.dll up to date.\n");
                        File.Delete("System.Data.SQLiteUpdate.dll");
                    }
                }

            }
            catch (Exception ex) { };
        }

        static bool FilesAreEqual(string fileName1, string fileName2)
        {
            bool equal = new FileInfo(fileName1).Length == new FileInfo(fileName2).Length;

            if (equal)
            {
                byte[] a = GetFileHash(fileName1);
                byte[] b = GetFileHash(fileName2);

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }

        static byte[] GetFileHash(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return System.Security.Cryptography.MD5.Create().ComputeHash(fs);
            }
        }

    }
}
