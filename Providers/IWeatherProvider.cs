using System.Collections.Generic;
using Mess.Models;

namespace Mess.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
