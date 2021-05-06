using System;

namespace WebUI.Data
{
    public class Measurement
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public DateTime UpdatedMeasurementTime { get; set; }
    }
}
