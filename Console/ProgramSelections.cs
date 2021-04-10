namespace Console
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    class ProgramSelections : IProgramSelections
    {
        class JokeResponseModel
        {
            public string Joke { get; set; }
            public string Setup { get; set; }
            public string Delivery { get; set; }
        }
        class Position
        {
            public float Lat { get; set; }
            public float Lon { get; set; }
            public string City { get; set; }
        }
        class weather 
        {
            public dataseries[] dataseries { get; set; }
        }
        class dataseries
        {
            public int temp2m { get; set; }
        }
        public async Task GetJokeAsync()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                using var client = new HttpClient();
                var response = await client.GetFromJsonAsync<JokeResponseModel>("https://v2.jokeapi.dev/joke/Programming");
                if (String.IsNullOrWhiteSpace(response.Joke))
                {
                    Console.WriteLine(response.Setup);
                    Console.WriteLine(response.Delivery);
                }
                else
                {
                    Console.WriteLine(response.Joke);
                }

                Console.WriteLine();
                Console.WriteLine("Vill du se en till? J/N");
                var input = Console.ReadKey();
                if (input.KeyChar == 'N' || input.KeyChar == 'n')
                {
                    isRunning = false;
                }
            }
        }

        public void PlayGame()
        {
            throw new NotImplementedException();
        }

        public void TextSaver()
        {
            throw new NotImplementedException();
        }

        public async Task ShowLocalWeather()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                var ip = "";
                using var client = new HttpClient();
                var locationResponse = await client.GetFromJsonAsync<Position>("http://ip-api.com/json/"+ip);

                Console.WriteLine("vänta...");

                string url = $"http://www.7timer.info/bin/api.pl?lon={locationResponse.Lon}&lat={locationResponse.Lat}&product=civil&output=json";

                var weatherResponse = await client.GetFromJsonAsync<weather>(url);
                //while (weatherResponse is null)
                //{
                //    await Task.Delay(TimeSpan.FromMilliseconds(100));
                //    Console.Write(".");
                //}

                var currentWeather = weatherResponse.dataseries[0].temp2m;
                Console.Clear();
                Console.WriteLine("stad/område:\t" + locationResponse.City);
                Console.WriteLine("latitud:\t " + locationResponse.Lat);
                Console.WriteLine("longitud:\t" + locationResponse.Lon);
                Console.WriteLine("temperatur:\t" + currentWeather);
                Console.WriteLine("\ntryck e för at komma tillbaks till huvudmenyn"); 


                var input = Console.ReadKey();
                if (input.KeyChar is 'e' or 'E')
                {
                    isRunning = false;
                }
            }
        }
    }
}
//i've never used visual studio code 