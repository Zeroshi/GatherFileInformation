using FileInformationEngine.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FileInformationEngine
{
    public class Logic : ILogic
    {
        private readonly ISaving _saving;
        private readonly ILogger _logger;

        public Logic(ISaving saving, ILogger<Logic> logger)
        {
            _saving = saving;
            _logger = logger;
        }

        public void InitialDirFiles(string initialDirectory)
        {
            _logger.LogInformation("Directory Search Initiated");
            GatherFileInformation(initialDirectory);
        }

        public void DirSearch(string directory)
        {
            try
            {
                foreach (var subDirectories in Directory.GetDirectories(directory))
                {
                    GatherFileInformation(subDirectories);
                    DirSearch(subDirectories);
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            _logger.LogInformation("File information gathering completed");
        }

        public void GatherFileInformation(string directory)
        {
            var files = Directory.GetFiles(directory);

            Parallel.ForEach(files, file =>
            {
                var fileInformation = new FileInformation();
                var fileMeta = new FileInfo(file);
                fileInformation.FullName = fileMeta.FullName;
                fileInformation.Size = fileMeta.Length.ToString();

                byte[] hash = MD5.Create().ComputeHash(fileMeta.OpenRead());
                fileInformation.Hash = BitConverter.ToString(hash);

                _saving.AddToDb(fileInformation);
            });
        }

        public void AddToDb(FileInformation fileInformation)
        {
            _saving.AddToDb(fileInformation);
        }

        public void ClearDbTable()
        {
            _saving.ClearDbTable();
            _logger.LogInformation("Table cleared");
        }
    }
}