using System;
using System.Collections.Generic;
using System.Text;

namespace PreAPI
{
    class KeyFunctions
    {
        public static void SaveNewFile(int NumberOfCopies, string InitialFileName, byte[] InitialFile, int NumberOfUsers, string GeneralPathToSave, string FinalLocation, string GeneralPathToDisconnectedUsers, List<Data> DataList, Dictionary<string,int> FileNameToOuterID)
        {
            int OuterID = Class_FilePartition.ChooseOuterID(DataList);
            string FileName = Class_FilePartition.FileNameSpacielName(InitialFileName, FileNameToOuterID);
            FileNameToOuterID = Class_FilePartition.FileNameSpacielDic(InitialFileName, FileNameToOuterID);
            FileNameToOuterID.Add(FileName, OuterID);
            int ItemLength = Class_FilePartition.ItemLength(InitialFile.Length);
            int LastBytesLength = Class_FilePartition.LastBitsPart(InitialFile.Length, ItemLength);
            List<Item> ItemList = Class_FilePartition.FileDivision(InitialFile, ItemLength, LastBytesLength, OuterID);

            for (int i = 0; i < NumberOfCopies; i++)
            {
                int[] FoldersFirstCopy = Class_ItemStorage.PathDetermination(ItemList, NumberOfUsers, Class_Data.GeneralPathToSave);
                for (int g = 0; g < FoldersFirstCopy.Length; g++)
                {
                    Data DataToList = new Data(OuterID, g, FoldersFirstCopy[g]);
                    DataList.Add(DataToList);
                }
                Class_ItemStorage.ItemSaving(ItemList, FoldersFirstCopy, Class_Data.GeneralPathToSave);

            }


            //-----------------------------------------Data Update------------------------------------------------


            Class_Data.DataList = DataList;
            Class_Data.FileNameToOuterID = FileNameToOuterID;



        }
        public static void Maintainace()
        {

        }
        public static byte[] Restore()
        {
            byte[] ttt = new byte[5];
            return ttt;
        }
    }
}
