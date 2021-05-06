using WebUI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public interface IMeasurementService
    {
        Task<Measurement> GetNewestMeasurementAsync();
        Task<List<Measurement>> GetAllMeasurementsAsync(MeasurementFilterBy FilterBy);
    }
}
