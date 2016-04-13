using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using FactorioModMan.Properties;

namespace FactorioModMan
{
    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Settings.Default.Reload();

            Settings.Default.PropertyChanged +=
                (object sender, PropertyChangedEventArgs e) => { Settings.Default.Save(); };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ManagerUi());
        }

        public static string GetMd5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }
        public static void RecursiveDelete(DirectoryInfo baseDir)
        {
            if (!baseDir.Exists)
                return;

            foreach (DirectoryInfo dir in baseDir.EnumerateDirectories())
            {
                RecursiveDelete(dir);
            }
            baseDir.Delete(true);
        }
        public static void CleanFolderContents(string basefolder)
        {
            //a little workaround to NOT delete the base... just the contents
            DirectoryInfo di = new DirectoryInfo(basefolder);
            foreach (DirectoryInfo directory in di.EnumerateDirectories())
            {
                RecursiveDelete(directory);
            }
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
        }

    }
}