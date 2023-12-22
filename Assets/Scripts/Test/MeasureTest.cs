using Measurements;
using UnityEngine;

namespace DefaultNamespace.Test
{
    public class MeasureTest : MonoBehaviour
    {
        public void OnNewMeasurement(Measurement measurement)
        {
            if (measurement is not MeasurementT<WiFiMeasurementData> wifiMeasurement) return;
            
            var wifi = wifiMeasurement.Data[0];
            Debug.Log($"ssid: {wifi.SSID}, rssi: {wifi.RSSI}");
        }
    }
}