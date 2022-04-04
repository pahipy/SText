namespace SText.Formats
{
    public interface IFormat
    {

        public string Path { get; }

        public string ReadFile();
        public void WriteFile(string content);

    }
}