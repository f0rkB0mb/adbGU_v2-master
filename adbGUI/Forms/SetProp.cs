namespace adbGUI.Forms
{
    using System;
    using System.Windows.Forms;
    using Methods;

    /// <summary>
    /// 
    /// </summary>
    public partial class SetProp : Form
    {
        private readonly CmdProcess _adb;
        private readonly FormMethods _formMethods;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adbFrm"></param>
        /// <param name="fMethods"></param>
        public SetProp(CmdProcess adbFrm, FormMethods fMethods)
        {
            _adb = adbFrm;
            _formMethods = fMethods;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData != Keys.Escape) return base.ProcessCmdKey(ref msg, keyData);
            Close();
            return true;
        }

        private void Btn_setProp_Click(object sender, EventArgs e)
        {
            _adb.StartProcessing("adb shell su root setprop " + txt_setPropKey.Text + " " + txt_setPropValue.Text,
                _formMethods.SelectedDevice());
        }
    }
}