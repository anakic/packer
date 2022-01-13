﻿using System.Text;

namespace Packer.Storage
{
    interface IFilesStore
    {
        public IEnumerable<string> GetFiles(string path);
        public IEnumerable<string> GetFolders(string path);
        public string ReadAsText(string path, Encoding? encoding = null);
        public byte[] ReadAsBytes(string path);
        public void Write(string path, string text, Encoding? encoding = null);
        public void Write(string path, byte[] bytes);
        bool FileExists(string path);
    }
}
