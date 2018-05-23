using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PreAPI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*  for (int i = 0; i < Class_Data.NumberOfUsers; i++)
              {
                  Directory.CreateDirectory(Class_Data.GeneralPathToFileSystem + @"/User" + (i + 1).ToString());
              }*/

            Class_Data c = new Class_Data();

           KeyFunctions.SaveNewFile(Class_Data.NuberOfCopies, Class_Data.FileName, Class_Data.InitialFile, Class_Data.NumberOfUsers, Class_Data.GeneralPathToSave, Class_Data.FinalLocation,Class_Data.GeneralPathToDisconnectedUsers, Class_Data.DataList, Class_Data.FileNameToOuterID);
        }
    }
}