using Tales.cybermagic.Tales;

namespace Tales
{
    public class TalesCreator
    {
        public TextParser TextParser { get; private set; }
        public TalesCreator(TextParser textParser)
        {
            TextParser = textParser;
        }

        public Tale CreateTaleFromFile(string s)
        {
            return new Tale();
        }
    }
}