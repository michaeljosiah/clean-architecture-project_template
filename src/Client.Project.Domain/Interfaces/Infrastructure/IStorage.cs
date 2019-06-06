using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Client.Project.Domain.Interfaces.Infrastructure
{
    public interface IStorage
    {
        /// <summary>
        /// Saves the file into the storage
        /// </summary>
        /// <param name="container">Target folder e.g. Customers</param>
        /// <param name="path">SubFolders anf file path e.g. \983\images\1.jpg</param>
        /// <param name="stream">file stream</param>
        /// <param name="root">Determinates page location e.g. ../Data/ or /Data/</param>
        void SaveFile(string container, string path, Stream stream, string root = null);

        /// <summary>
        /// Gets URL of stored file
        /// </summary>
        /// <param name="container">Target folder e.g. Customers</param>
        /// <param name="path">SubFolders anf file path e.g. \983\images\1.jpg</param>
        /// <param name="root">Determinates page location e.g. ../Data/ or /Data/</param>
        /// <returns>External(http://) or Internal(../Data/) Url</returns>
        string GetFileUrl(string container, string path, string root = null);

        /// <summary>
        /// Deletes file from the storage if exists
        /// </summary>
        /// <param name="container">Target folder e.g. Customers</param>
        /// <param name="path">SubFolders anf file path e.g. \983\images\1.jpg</param>
        /// /// <param name="root">Determinates page location e.g. ../Data/ or /Data/</param>
        void DeleteFile(string container, string path, string root = null);

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="container">Target folder e.g. Customers</param>
        /// <param name="path">SubFolders anf file path e.g. \983\images\1.jpg</param>
        /// <param name="root">Determinates page location e.g. ../Data/ or /Data/</param>
        /// <returns>true is exists</returns>
        bool FileExists(string container, string path, string root = null);

        /// <summary>
        /// Returns file from storage represented as array of bytes
        /// </summary>
        /// <param name="container">Target folder e.g. Customers</param>
        /// <param name="path">SubFolders anf file path e.g. \983\images\1.jpg</param>
        /// <param name="root">Determinates page location e.g. ../Data/ or /Data/</param>
        /// <returns></returns>
        byte[] GetFileArrayBytes(string container, string path, string root = null);

        /// <summary>
        /// Copies an existing file to a new file.
        /// </summary>
        /// <param name="recipientContainer"></param>
        /// <param name="recipientPath"></param>
        /// <param name="targetContainer"></param>
        /// <param name="targetPath"></param>
        void Copy(string recipientContainer, string recipientPath, string targetContainer, string targetPath);

        /// <summary>
        /// Returns a list of file urls for specific folder 
        /// </summary>
        /// <param name="container">Target folder e.g. Customers</param>
        /// <param name="path">SubFolders anf file path e.g. \983\images\</param>
        /// <param name="root">Determinates page location e.g. ../Data/ or /Data/</param>
        /// <param name="searchPattern">search by specific filename</param>
        /// <returns></returns>
        string[] GetFilesUrls(string container, string path, string root, string searchPattern = null);
    }
}
