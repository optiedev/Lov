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
            public string joke { get; set; }
            public string setup { get; set; }
            public string delivery { get; set; }
        }
        public async Task GetJokeAsync()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                using var client = new HttpClient();
                var response = await client.GetFromJsonAsync<JokeResponseModel>("https://v2.jokeapi.dev/joke/Programming");
                if (String.IsNullOrWhiteSpace(response.joke))
                {
                    Console.WriteLine(response.setup);
                    Console.WriteLine(response.delivery);
                }
                else
                {
                    Console.WriteLine(response.joke);
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
    }
}
