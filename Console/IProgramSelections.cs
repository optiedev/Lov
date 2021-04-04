using System.Threading.Tasks;

namespace Console
{
    interface IProgramSelections
    {
        void TextSaver();
        void PlayGame();
        Task GetJokeAsync();
    }
}
