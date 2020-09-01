using ImportSpreadsheet.Application.Dtos;
using System.Collections.Generic;

namespace ImportSpreadsheet.Application.Interfaces
{
    public interface IApplicationServiceImport
    {
        object ImportSpredSheet(string directory);
    }
}