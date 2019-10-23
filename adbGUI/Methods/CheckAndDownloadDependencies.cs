namespace adbGUI.Methods
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public static class CheckAndDownloadDependencies
    {
        private static readonly string DownloadToTempPath = Path.GetTempPath() + "platform-tools-latest-windows.zip";

        private static readonly string[] StrFiles = { "adb.exe", "AdbWinApi.dll", "AdbWinUsbApi.dll", "fastboot.exe", "libwinpthread-1.dll" };

        /// <summary>
        /// 
        /// </summary>
        public static string DownloadToTempPath1
        {
            get
            {
                return DownloadToTempPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string[] StrFiles1
        {
            get
            {
                return StrFiles;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Start()
        {
            if (CheckIfFilesExist()) return;
            var dialogResult = MessageBox.Show(@"Enviroment Variables not set and files missing. Should all dependencies be downloaded and extracted?",
                                                 @"Error: Missing Files",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Error);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    try
                    {
                        DownloadFiles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
                case DialogResult.No:
                    MessageBox.Show("Error!\r\nWithout the needed additional Files, the Tool is Shut down.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);
                    break;
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool CheckIfFilesExist()
        {
            return StrFiles1 != null && StrFiles1.All(File.Exists);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DownloadFiles()
        {
            ExtractionCompleted += DependenciesChecker_ExtractionCompleted;
            using (var wc = new WebClient())
            {
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileTaskAsync(new Uri("https://dl.google.com/android/repository/platform-tools-latest-windows.zip"), DownloadToTempPath1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var tr = new Thread(ExtractFiles);
            tr.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private static event ExtractionCompletedHandler ExtractionCompleted;

        /// <summary>
        /// 
        /// </summary>
        private static void ExtractFiles()
        {
            if (Directory.Exists(Path.GetTempPath() + "platform-tools"))
                Directory.Delete(Path.GetTempPath() + "platform-tools", true);

            ZipFile.ExtractToDirectory(DownloadToTempPath1, Path.GetTempPath());

            ExtractionCompleted?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DependenciesChecker_ExtractionCompleted()
        {
            var extractedFilesPath = Path.GetTempPath() + "platform-tools";


            foreach (var item in StrFiles1)
                try
                {
                    File.Copy(extractedFilesPath + "\\" + item, item);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            ExtractionCompleted -= DependenciesChecker_ExtractionCompleted;

            MessageBox.Show(@"Files downloaded, decompressed and moved successfully", @"Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        private delegate void ExtractionCompletedHandler();
    }
}