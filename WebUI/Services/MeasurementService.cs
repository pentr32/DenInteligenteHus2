using WebUI.Constants;
using WebUI.Data;
using WebUI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IGenericRepository _genericRepository;
        Measurement myMeasurement;

        public MeasurementService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
            myMeasurement = new Measurement();
        }

        public async Task<Measurement> GetNewestMeasurementAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.EndPoint,
                Query = "results=1"
            };

            var measurement = await _genericRepository.GetAsync<Root>(builder.ToString());

            if (measurement != null)
            {
                myMeasurement.Temperature = float.Parse(measurement.feeds[0].field1);
                myMeasurement.Humidity = float.Parse(measurement.feeds[0].field2);
                myMeasurement.UpdatedMeasurementTime = measurement.feeds[0].created_at;
            }

            return myMeasurement;
        }

        public async Task<List<Measurement>> GetAllMeasurementsAsync(MeasurementFilterBy FilterBy)
        {
            List<Measurement> thMeasurements = new List<Measurement>();

            int queryResults = 0;
            switch (FilterBy)
            {
                case MeasurementFilterBy.ByNewestTime:
                    queryResults = 3;
                    break;

                case MeasurementFilterBy.ByNewestDay:
                    queryResults = 8;
                    break;

                case MeasurementFilterBy.ByNewestWeek:
                    queryResults = 10;
                    break;

                default:
                    break;
            }

            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = $"{ApiConstants.EndPoint}",
                Query = $"results={queryResults}"
            };

            var measurements = await _genericRepository.GetAsync<Root>(builder.ToString());

            if (measurements != null)
            {
                foreach (var feed in measurements.feeds)
                {
                    thMeasurements.Add(new Measurement
                    {
                        Temperature = float.Parse(feed.field1),
                        Humidity = float.Parse(feed.field2),
                        UpdatedMeasurementTime = feed.created_at
                    });
                }
            }

            return thMeasurements;
        }
    }
}
