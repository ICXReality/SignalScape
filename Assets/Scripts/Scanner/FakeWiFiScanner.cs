using System.Collections;
using Measurements;
using UnityEngine;

namespace DefaultNamespace
{
    public class FakeWiFiScanner: Scanner
    {
        [SerializeField] private float scanDelay = 5f;
        [SerializeField] private string ssid;
        [SerializeField] private string bssid;
        [SerializeField] private int frequency = 5000;
        [SerializeField] private int signalMin = 0;
        [SerializeField] private int signalMax = 100;

        private Coroutine scanCoroutine;
        
        protected override void SetIsScanning(bool isNowScanning)
        {
            if (isNowScanning && scanCoroutine == null)
            {
                scanCoroutine = StartCoroutine(Scan());
            } else if (!isNowScanning && scanCoroutine != null)
            {
                StopCoroutine(scanCoroutine);
                scanCoroutine = null;
            }
        }

        private IEnumerator Scan()
        {
            while (true)
            {
                WiFiMeasurementData data;
                data.SSID = ssid;
                data.BSSID = bssid;
                data.Frequency = frequency;
                data.RSSI = Mathf.FloorToInt(Random.Range(signalMin, signalMax));
                CreateMeasurement(data);
                yield return new WaitForSeconds(scanDelay);
            }
        }
    }
}