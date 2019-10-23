namespace adbGUI.Methods
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// 
    /// </summary>
    public class AdbDeviceList : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> GetDevicesList { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string GetDevicesRaw { set; get; }
    }
}