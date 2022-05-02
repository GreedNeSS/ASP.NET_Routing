using DependencyInjection_in_Endpoints.Interfaces;

namespace DependencyInjection_in_Endpoints.Services
{
    public class LongTimeService : ITimeService
    {
        public string Time()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}
