namespace Directories
{
    public class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public long Size { get; private set; }
        public string Name { get; private set; }
    }
}
