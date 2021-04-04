namespace Console
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
       
        static async Task Main(string[] args)
        {
            IProgramSelections programSelections = new ProgramSelections();
            SetStyling();
            
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra idag?");
                
                Console.WriteLine("0: Avsluta");
                Console.WriteLine("1: Optitech Textsparare");
                Console.WriteLine("2: Optitech Spelspelare");
                Console.WriteLine("3: Optitech Väderservice");

                char input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    programSelections.TextSaver();
                }
                else if (input == '2')
                {
                    programSelections.PlayGame();
                }
                else if (input == '3')
                {
                    programSelections.GetWeather();
                }
                else if (input == '0')
                {
                    isRunning = false;
                    Console.WriteLine("Tack för att du använde Optitechs program...");
                }
                else
                {
                    Console.Clear();

                    Console.WriteLine("Felaktig inmatning");
                    for (int i = 0; i < 10; i++)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(100));
                        Console.Write(".");
                    }
                }
            }

        }

        private static void SetStyling()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    class ProgramSelections : IProgramSelections
    {
        public void GetWeather()
        {
            throw new NotImplementedException();
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
    interface IProgramSelections
    {
        void TextSaver();
        void PlayGame();
        void GetWeather();
    }
}
