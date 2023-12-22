namespace Measurements
{
    /// <summary>
    /// Data taken from a Wi-Fi Measurement.
    /// </summary>
    public struct WiFiMeasurementData
    {
        /// <summary>
        /// The network name.
        /// </summary>
        public string SSID;
        
        /// <summary>
        /// The address of the access point.
        /// </summary>
        public string BSSID;
        
        /// <summary>
        /// The detected signal level in dBm, also known as the RSSI.
        /// </summary>
        public int RSSI;
        
        /// <summary>
        /// The center frequency of the primary 20 MHz frequency (in MHz) of the channel over which the client is communicating with the access point.
        /// </summary>
        public int Frequency;
    }
}