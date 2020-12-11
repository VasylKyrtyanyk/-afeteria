using Newtonsoft.Json;

namespace Сafeteria.Middlewares.HelperClasses
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}