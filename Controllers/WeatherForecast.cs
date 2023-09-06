namespace LearnAspDotNet.Controllers
{
    public class WeatherForecast
    {
        private System.DateTime Date;
        private int TemperatureC;
        private string? Summary;

        public WeatherForecast(System.DateTime Date, int TemperatureC, string Summary)
        {
            this.Date = Date;
            this.TemperatureC = TemperatureC;
            this.Summary = Summary;
        }

        public System.DateTime getDate()
        {
            return this.Date;
        }

        public int getTemperatureC() 
        { 
            return this.TemperatureC; 
        }

        public string getSummary() {
            return this.Summary;
        }

    }
}
