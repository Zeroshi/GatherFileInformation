using System;
using System.Collections.Generic;
using System.Text;

namespace FileInformationEngine.Interfaces
{
    public interface ISaving
    {
        void AddToDb(FileInformation fileInformation);
        void ClearDbTable();
    }
}
