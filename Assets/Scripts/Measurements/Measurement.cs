using System;
using System.Collections;
using System.Collections.Generic;
using Measurements;
using UnityEngine;

/// <summary>
/// A measurement represents a signal reading taken in 3D space at a specified time.
/// </summary>
[Serializable]
public abstract class Measurement
{
    /// <summary>
    /// The date that this measurement was taken.
    /// </summary>
    public DateTime Date;

    /// <summary>
    /// The position that this measurement was taken at.
    /// </summary>
    public Vector3 Position;
}

/// <summary>
/// A measurement containing a specific type of data, such as WiFi.
/// </summary>
public class MeasurementT<T> : Measurement
{
    public MeasurementT(T[] Data)
    {
        this.Data = Data;
    }
    
    /// <summary>
    /// The data taken during this measurement.
    /// </summary>
    public readonly T[] Data;
}
