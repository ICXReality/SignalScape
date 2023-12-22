using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class MeasurementManager : MonoBehaviour
    {
        /// <summary>
        /// Invoked when there is a new measurement.
        /// </summary>
        public UnityEvent<Measurement> OnNewMeasurement;
        
        /// <summary>
        /// The transform that will represent the position of the scanner. 
        /// </summary>
        [SerializeField] private Transform scannerTransform;
        
        /// <summary>
        /// A list of measurements that have been collected by the scanners.
        /// </summary>
        [SerializeField] private List<Measurement> measurements = new List<Measurement>();
        
        /// <summary>
        /// A list of scanners that provide measurements.
        /// </summary>
        [SerializeField] private List<Scanner> scanners = new List<Scanner>();

        private void Start()
        {
            foreach (var scanner in scanners)
            {
                AddScannerEvents(scanner);
                scanner.IsScanning = true;
            }
        }

        /// <summary>
        /// Gets all measurements taken. 
        /// </summary>
        /// <param name="since"></param>
        public Measurement[] GetMeasurements(DateTime? since = null)
        {
            return measurements
                .Where(m => since == null || m.Date >= since.Value)
                .ToArray();
        }

        /// <summary>
        /// Gets all measurements taken. 
        /// </summary>
        /// <param name="since"></param>
        public MeasurementT<T>[] GetMeasurementsOfType<T>(DateTime? since = null)
        {
            return measurements
                .Where(m => since == null || m.Date >= since.Value)
                .OfType<MeasurementT<T>>()
                .ToArray();
        }

        private void AddScannerEvents(Scanner scanner)
        {
            scanner.OnNewMeasurement += OnNewScannerMeasurement;
        }

        private void OnNewScannerMeasurement(object sender, Measurement measurement)
        {
            Debug.Log("New measurements!");
            measurements.Append(measurement);
            OnNewMeasurement.Invoke(measurement);
        }
    }
}