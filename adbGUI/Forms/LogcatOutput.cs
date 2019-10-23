namespace adbGUI.Forms
{
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public partial class LogcatOutput : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public LogcatOutput()
        {
            InitializeComponent();
        }

        private void LogcatOutput_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }
    }
}