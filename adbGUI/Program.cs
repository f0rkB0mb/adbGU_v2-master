namespace adbGUI
{
    using System;
    using System.Windows.Forms;
    using Forms;
    using Methods;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            //WILL BE HANDLED IN THE METHOD:
            //if (MessageBox.Show("Downloading missing Files and Dependencies?", "Beware", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            //{
                try
                {
                    CheckAndDownloadDependencies.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fehler");
                }
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}