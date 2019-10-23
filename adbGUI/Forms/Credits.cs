namespace adbGUI.Forms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public partial class Credits : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public Credits()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Credits_Load(object sender, EventArgs e)
        {
            textBox1.Select(0, 0);
        }
    }
}