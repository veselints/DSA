namespace Directories
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TestTasks
    {
        static IList<string> logs = new List<string>();

        private static void Main()
        {
            string sourceDirectory = @"C:\WINDOWS";

            DirectoryInfo startDirectoryInfo = new DirectoryInfo(sourceDirectory);

            //IList<string> collectedFiles = new List<string>();

            //collectedFiles = WalkDirectoryTree(startDirectoryInfo, collectedFiles);

            //foreach (var fileName in collectedFiles)
            //{
            //    Console.WriteLine(fileName);
            //}

            //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            //foreach (var exeption in logs)
            //{
            //    Console.WriteLine(exeption);
            //}

            var cDirectoryFolderTree = new Folder(sourceDirectory);
            cDirectoryFolderTree = CreateFolderTree(cDirectoryFolderTree);
            Console.WriteLine("Done!");

            var windowsFolderSize = cDirectoryFolderTree.FolderSize();
            Console.WriteLine("The size of Windows folder on this computer is {0:N} bytes", windowsFolderSize);
        }

        private static IList<string> WalkDirectoryTree(DirectoryInfo root, IList<string> alreadyCollectedFiles)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirectories = null;

            try
            {
                files = root.GetFiles("*.exe");
            }
            catch (UnauthorizedAccessException e)
            {
                logs.Add(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo currentFileInfo in files)
                {
                    alreadyCollectedFiles.Add(currentFileInfo.FullName);
                }

                subDirectories = root.GetDirectories();

                foreach (DirectoryInfo directoriesInfo in subDirectories)
                {
                    WalkDirectoryTree(directoriesInfo, alreadyCollectedFiles);
                }
            }

            Console.Write(".");

            return alreadyCollectedFiles;
        }

        private static Folder CreateFolderTree(Folder root)
        {
            DirectoryInfo startDirectoryInfo = new DirectoryInfo(root.Name);

            try
            {
                var currentFiles = startDirectoryInfo.GetFiles();
                foreach (var file in currentFiles)
                {
                    var currentFile = new File(file.Name, file.Length);
                    root.AddFile(currentFile);
                }

                var currentSubdirectories = startDirectoryInfo.GetDirectories();

                foreach (var directory in currentSubdirectories)
                {
                    var currentSubdirectory = new Folder(directory.FullName);
                    root.AddFolder(currentSubdirectory);
                    CreateFolderTree(currentSubdirectory);
                }
            }
            catch (Exception e)
            {
                logs.Add(e.Message);
            }

            Console.Write(".");

            return root;
        }
    }
}

                    
