using System;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// A scanner provides measurements that the manager can utilize.
    /// </summary>
    public abstract class Scanner : MonoBehaviour
    {
        public bool IsScanning
        {
            get => isScanning;
            set
            {
                isScanning = value;
                SetIsScanning(value);
            }
        }

        private bool isScanning = false;

        /// <summary>
        /// Called when there is a new measurement.
        /// </summary>
        public event EventHandler<Measurement> OnNewMeasurement;

        /// <summary>
        /// Creates a measurement of a certain data type and emits it.
        /// </summary>
        /// <param name="Data">The data to create a measurement out of</param>
        /// <typeparam name="T">The type of data to create a measurement for</typeparam>
        protected void CreateMeasurement<T>(T[] Data)
        {
            var measurement = new MeasurementT<T>(Data);
            OnNewMeasurement?.Invoke(this, measurement);
        }
        
        /// <summary>
        /// Creates a measurement of a certain data type and emits it.
        /// </summary>
        /// <param name="Data">The data to create a measurement out of</param>
        /// <typeparam name="T">The type of data to create a measurement for</typeparam>
        protected void CreateMeasurement<T>(T Data) => CreateMeasurement(new[] { Data });

        protected abstract void SetIsScanning(bool isNowScanning);
    }
}