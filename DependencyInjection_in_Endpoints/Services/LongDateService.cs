using DependencyInjection_in_Endpoints.Interfaces;

namespace DependencyInjection_in_Endpoints.Services
{
    public class LongDateService : IDateService
    {
        public string Date()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
