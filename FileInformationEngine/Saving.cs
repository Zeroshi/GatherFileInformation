using FileInformationEngine.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileInformationEngine
{
    public class Saving : ISaving
    {
        private const string TRUNCATE_TABLE_FILEINFORMATION = "TRUNCATE TABLE FileInformation";

        public void AddToDb(FileInformation fileInformation)
        {
            using (var db = new FileInformationContext())
            {
                db.FileInformation.Add(fileInformation);
                db.SaveChanges();
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}