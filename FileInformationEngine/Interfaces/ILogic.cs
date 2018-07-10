using System;
using System.Collections.Generic;
using System.Text;

namespace FileInformationEngine.Interfaces
{
    public interface ILogic
    {
        void InitialDirFiles(string initialDirectory);

        void DirSearch(string directory);

        void GatherFileInformation(string directory);
        void AddToDb(FileInformation fileInformation);
        void ClearDbTable();
    }
}