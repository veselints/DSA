using System.Collections.Generic;

namespace Directories
{
    public class Folder
    {
        private IList<File> files;
        private IList<Folder> folders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.folders = new List<Folder>();
        }

        public string Name { get; private set; }

        public void AddFile(File currentFile)
        {
            this.files.Add(currentFile);
        }

        public void AddFolder(Folder nestedFolder)
        {
            this.folders.Add(nestedFolder);
        }

        public long FolderSize()
        {
            long result = 0;

            foreach (var file in this.files)
            {
                result += file.Size;
            }

            foreach (var folder in this.folders)
            {
                result += folder.FolderSize();
            }

            return result;
        }
    }
}
