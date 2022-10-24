namespace SText.Formats
{
    public interface IFormat
    {

        public string Path { get; }
        public bool IsReadOnly { get; }

        public string ReadFile();
        public void WriteFile(string content);
        public void CloseFile();

    }
}