using Client.Project.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Client.Project.Infrastructure.Storage
{
    public class LocalStorage : IStorage
    {
        public void Copy(string recipientContainer, string recipientPath, string targetContainer, string targetPath)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(string container, string path, string root = null)
        {
            throw new NotImplementedException();
        }

        public bool FileExists(string container, string path, string root = null)
        {
            throw new NotImplementedException();
        }

        public byte[] GetFileArrayBytes(string container, string path, string root = null)
        {
            throw new NotImplementedException();
        }

        public string[] GetFilesUrls(string container, string path, string root, string searchPattern = null)
        {
            throw new NotImplementedException();
        }

        public string GetFileUrl(string container, string path, string root = null)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(string container, string path, Stream stream, string root = null)
        {
            throw new NotImplementedException();
        }
    }
}
