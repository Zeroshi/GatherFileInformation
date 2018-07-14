using FileInformationEngine.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileInformationEngine
{
    public class Saving : ISaving
    {
        private const string TRUNCATE_TABLE_FILEINFORMATION = "TRUNCATE TABLE FileInformation";
        private readonly ILogger _logger;

        public Saving(ILogger<Saving> logger)
        {
            _logger = logger;
        }

        public void AddToDb(FileInformation fileInformation)
        {
            try
            {
                using (var db = new FileInformationContext())
                {
                    db.FileInformation.Add(fileInformation);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }

        public void ClearDbTable()
        {
            try
            {
                using (var db = new FileInformationContext())
                {
                    db.Database.ExecuteSqlCommand(TRUNCATE_TABLE_FILEINFORMATION);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}