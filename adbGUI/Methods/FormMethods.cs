namespace adbGUI.Methods
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    using adbGUI.Forms;

    /// <summary>
    /// FormMethods ctor 
    /// <para>
    /// Provides access to IDisposal interface.
    /// </para>
    /// </summary>
    public class FormMethods : IDisposable
    {
        private readonly CmdProcess _adb = new CmdProcess();
        private readonly MainForm _frm;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="f">An object of <c><see cref="System.Windows.Forms"/></c>.</param>
        public FormMethods(MainForm f)
        {
            //Pass the MainForm instance
            _frm = f;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _adb?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The Method SelectedDevice gets a value of any selected Device which is connected.
        /// </summary>
        /// <returns></returns>
        public string SelectedDevice()
        {
            return _frm.tsc_ConnectedDevices.Items.Count == 0 ? "" : _frm.tsc_ConnectedDevices.SelectedItem.ToString();
        }

        /// <summary>
        /// Gets an Array of connected ADB-Serials of any connected Android-Device.
        /// </summary>
        /// <param name="devices"></param>
        public void RefreshAdbSerialsInCombobox(List<string> devices)
        {
            _frm.tsc_ConnectedDevices.Items.Clear();

            foreach (var item in devices) _frm.tsc_ConnectedDevices.Items.Add(item);

            _frm.tsc_ConnectedDevices.SelectedIndex = _frm.tsc_ConnectedDevices.Items.Count - 1;
        }

        /// <summary>
        /// This Method tries to kill any Process that named "adb"
        /// </summary>
        public static void KillServer()
        {
            try
            {
                foreach (var pr in Process.GetProcessesByName("adb")) pr.Kill();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, @"Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        /// <summary>
        /// AlwaysClearConsole
        /// </summary>
        /// <returns><c><see cref="System.Boolean"/></c></returns>
        public static bool AlwaysClearConsole()
        {
            return true;
        }
    }
}