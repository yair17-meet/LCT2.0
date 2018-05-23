using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreAPI
{
    class Class_GeneralClass
    {
    }
    public class Class_Data
    {
        public static string GeneralPathToFileSystem = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Project3.0\FileSystem";
        public static byte[] InitialFile = File.ReadAllBytes(@"C:\Users\Yair\Desktop\OriginalFileLocation\JPGFile1.jpg");
        public static int NuberOfCopies = 3;
        public static int[] FolderFirstCopy = new int[] { 1, 2, 3 };
        public static int[] FolderSecondCopy = new int[] { 1, 2, 3 };
        public static int OuterID = 0;
        public static int NumberOfUsers = 8;
        public static string[] FileNamearr = Directory.GetFiles(@"C:\Users\Yair\Desktop\OriginalFileLocation\JPGFile1.jpg");
        public static string FileName = FileNamearr[0];
        public static string GeneralPathToSave = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\FileSystem\User";
        public static string FinalLocation = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\FinalLocation\";
        public static List<Data> DataList = new List<Data>();
        public static Dictionary<string, int> FileNameToOuterID = new Dictionary<string, int>();
        public static string GeneralPathToDisconnectedUsers = @"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\UnconnectedUsers\User";
        public static int[] UnconnectedUsers = new int[1];

    }
    
    class Class_DisconnectedUser
    {
        public static int IdentifyUser(string GeneralPathToSave, int NumberOfUsers, int[] UnconnectedUsers)
        {
            int UserToDisconnect = 0;

            int Count1 = 0;
            int a = 0;
            for (int i = 0; i < NumberOfUsers; i++)
            {
                if (Directory.Exists(GeneralPathToSave + (Count1 + 1)))
                {
                    Count1++;

                }
                else
                {
                    i = NumberOfUsers + 1;
                }
            }
            int[] ExistingUsersArrey = new int[Count1];
            while (a < 1)
            {
                Random rnd = new Random();
                UserToDisconnect = rnd.Next(1, NumberOfUsers);
                if (Directory.Exists(GeneralPathToSave + UserToDisconnect))
                {
                    a = 4;
                }
            }
            Console.WriteLine(UserToDisconnect);

            for (int i = 0; i < UnconnectedUsers.Length; i++)
            {
                if (UnconnectedUsers[i] == 0)
                {
                    UnconnectedUsers[i] = UserToDisconnect;
                    i = UnconnectedUsers.Length + 3;
                }
            }

            return UserToDisconnect;
        }

        public static void MoveToDisconnected(int UserToDisconnect, string GeneralPathToSave, string GeneralPathToDisconnectedUsers)
        {
            string a = GeneralPathToSave + UserToDisconnect.ToString();
            string c = GeneralPathToDisconnectedUsers + UserToDisconnect.ToString();

            Directory.Move(a, c);

        }

    }
    class Class_FilePartition
    {

        //--------------------------------------------------------------------------------

        // finds the number of the last bytes in the file that are not in any item

        public static int LastBitsPart(int InitialFileLength, int ItemLength)
        {
            int NumberOfRegularLengthItems = InitialFileLength / ItemLength;
            return InitialFileLength - NumberOfRegularLengthItems * ItemLength;
        }

        //--------------------------------------------------------------------------------

        // recives a file byte arr and returns a a list of items made out of the original file 

        public static List<Item> FileDivision(byte[] InitialFile, int ItemLength, int LastBytes, int OuterId)
        {
            int ByteCounter = 0;
            int NumberOfRegularLengthItems = InitialFile.Length / ItemLength;
            Item TemporarLastItem = new Item(LastBytes, NumberOfRegularLengthItems, OuterId);
            List<Item> ItemsList = new List<Item>();
            for (int i = 0; i < NumberOfRegularLengthItems; i++)
            {
                Item TemporarItem = new Item(ItemLength, i, OuterId);
                for (int g = 0; g < ItemLength; g++)
                {
                    TemporarItem.ItemValue[g] = InitialFile[ByteCounter];
                    ByteCounter++;
                }
                ItemsList.Add(TemporarItem);
            }
            for (int i = 0; i < LastBytes; i++)
            {
                TemporarLastItem.ItemValue[i] = InitialFile[ByteCounter];
                ByteCounter++;
            }
            ItemsList.Add(TemporarLastItem);
            return ItemsList;
        }

        //--------------------------------------------------------------------------------

        // find the length of every item acording to the size of the original file

        public static int ItemLength(int InitialFileLength)
        {

            if (InitialFileLength <= 1000)
            {
                return 10;
            }
            if ((InitialFileLength > 1000) && (InitialFileLength <= 100000))
            {
                return 50;
            }
            if ((InitialFileLength > 100000) && (InitialFileLength <= 1000000))
            {
                return 1000;
            }
            else
            {
                return 50000;
            }

        }




        //--------------------------------------------------------------------------------

        //---------- Chooses a random Outer Id that has not been chosen yet ---------

        public static int ChooseOuterID(List<Data> DataList)
        {
            int OuterID = 0;

            Random rnd = new Random();
            int aaa = 0;
            while (aaa < 1)
            {
                aaa = 2;
                OuterID = rnd.Next(1, 999999999);
                foreach (Data DataItem in DataList)
                {
                    if (DataItem.OuterID == OuterID)
                    {

                        aaa = 0;
                    }

                }
            }
            return OuterID;
        }


        //------------------------------------------------------------------------------------------

        //-------- Make the name of the File Unique ----------

        public static Dictionary<string, int> FileNameSpacielDic(string OriginalName, Dictionary<string, int> FileNameToOuterID)
        {
            int Counter1 = 1;
            string FinalFileName = "";
            int a1 = OriginalName.LastIndexOf(".");
            string Name1 = OriginalName.Substring(0, a1);
            string Ending1 = "";
            for (int i = a1; i < OriginalName.LastIndexOf("") + 1; i++)
            {
                Ending1 = Ending1 + OriginalName[i];
            }
            string FileName = Name1 + "(" + Counter1.ToString() + ")" + Ending1;
            for (int i = 0; i < Counter1; i++)
            {
                foreach (string NameFromCollectioin in FileNameToOuterID.Keys)
                {
                    if (FileName == NameFromCollectioin)
                    {
                        Counter1++;
                        int a = OriginalName.LastIndexOf(".");
                        string Name = OriginalName.Substring(0, a);
                        string Ending = "";
                        for (int g = a; g < OriginalName.LastIndexOf("") + 1; g++)
                        {
                            Ending = Ending + OriginalName[g];
                        }
                        FinalFileName = Name + "(" + Counter1.ToString() + ")" + Ending;
                    }
                }
            }

            return FileNameToOuterID;




        }
        public static string FileNameSpacielName(string OriginalName, Dictionary<string, int> FileNameToOuterID)
        {
            int Counter1 = 1;
            string FinalFileName = "";
            int a1 = OriginalName.LastIndexOf(".");
            string Name1 = OriginalName.Substring(0, a1);
            string Ending1 = "";
            for (int i = a1; i < OriginalName.LastIndexOf("") + 1; i++)
            {
                Ending1 = Ending1 + OriginalName[i];
            }
            string FileName = Name1 + "(" + Counter1.ToString() + ")" + Ending1;
            for (int i = 0; i < Counter1; i++)
            {
                foreach (string NameFromCollectioin in FileNameToOuterID.Keys)
                {
                    if (FileName == NameFromCollectioin)
                    {
                        Counter1++;
                        int a = OriginalName.LastIndexOf(".");
                        string Name = OriginalName.Substring(0, a);
                        string Ending = "";
                        for (int g = a; g < OriginalName.LastIndexOf("") + 1; g++)
                        {
                            Ending = Ending + OriginalName[g];
                        }
                        FinalFileName = Name + "(" + Counter1.ToString() + ")" + Ending;
                    }
                }
            }

            return FileName;

        }
        
    }
    class Class_FileRecovery
    {
        public static List<Data> FinalRestoredFileDataList(int OuterIDToRecover, List<Data> DataList)
        {



            var queryAllCustomers = from data in DataList
                                    where data.OuterID == OuterIDToRecover
                                    orderby data.InnerID
                                    select data;
            List<Data> list = queryAllCustomers.ToList();
            List<Data> FinalList = new List<Data>();
            int Counter1 = 0;
            foreach (Data item in list)
            {

                if ((Counter1 + 1) != list.Count)
                {
                    if ((list[Counter1].InnerID) == list[Counter1 + 1].InnerID)
                    {
                        Counter1++;
                    }
                    else
                    {
                        Counter1++; FinalList.Add(item);
                    }
                }
                else
                {
                    FinalList.Add(item);
                }

            }
            return FinalList;
        }

        public static byte[] FileRecreation(List<Data> FinalDataList, string GeneralPathToSave)
        {
            int FinalFileLength = 0;
            int Counter1 = 0;
            foreach (Data DataPart in FinalDataList)
            {
                FinalFileLength = FinalFileLength + File.ReadAllBytes(GeneralPathToSave + DataPart.Location + @"\" + DataPart.OuterID + "_" + DataPart.InnerID + ".dsys").Length;
            }
            byte[] FinalFile = new byte[FinalFileLength];

            foreach (Data DataPart in FinalDataList)
            {
                byte[] TempItem = File.ReadAllBytes(GeneralPathToSave + DataPart.Location + @"\" + DataPart.OuterID + "_" + DataPart.InnerID + ".dsys");
                for (int i = 0; i < TempItem.Length; i++)
                {
                    FinalFile[Counter1] = TempItem[i];
                    Counter1++;
                }

            }


            return FinalFile;
        }
    }
    class Class_ItemStorage
    {
        public static int[] PathDetermination(List<Item> ItemList, int NumberOfUsers, string GeneralPath)
        {
            int Counter2 = 0;
            int a = 2;
            int Folder = 0;
            Random rnd = new Random();
            int[] Folders = new int[ItemList.Count];

            foreach (Item ItemToSave in ItemList)
            {
                while (a > 1)
                {
                    Folder = rnd.Next(1, (NumberOfUsers + 1));
                    if ((File.Exists(GeneralPath + Folder + @"\" + ItemToSave.FileOuterId + "_" + ItemToSave.ItemInnerId + ".dsys")))
                    {
                        a = 2;
                    }
                    else
                    {
                        a = 0;
                    }
                }

                Folders[Counter2] = Folder;
                Counter2++;

                a = 2;

            }

            return Folders;
        }


        public static void ItemSaving(List<Item> ItemList, int[] folders, string GeneralPath)
        {

            int Counter1 = 0;
            foreach (Item ItemToSave in ItemList)
            {
                string Name = @"\" + ItemToSave.FileOuterId + "_" + ItemToSave.ItemInnerId + ".dsys";
                File.WriteAllBytes(GeneralPath + folders[Counter1] + Name, ItemToSave.ItemValue);
                Counter1++;


            }

        }
    }
    class Class_Maintainance
    {

        public static List<Data> MissingItems(List<Data> DataList, string GeneralPathToSave)
        {
            List<Data> MissisngData = new List<Data>();
            foreach (Data DataItem in DataList)
            {
                string path = GeneralPathToSave + DataItem.Location + @"\" + DataItem.OuterID + "_" + DataItem.InnerID + ".dsys";
                if (File.Exists(path) == false)
                {
                    MissisngData.Add(DataItem);
                }
            }
            return MissisngData;
        }

        public static int[] FindingNewUserToSave(List<Data> MissingItemsList, int NumberOfUsers, string GeneralPathToSave, List<Data> DataList)
        {
            int[] NewUser = new int[MissingItemsList.Count];
            int Count2 = 0;
            foreach (Data MissingItem in MissingItemsList)
            {
                Random rnd = new Random();
                int Count1 = 0;
                int NewItemLocation = -1;
                while (Count1 < 1)
                {
                    NewItemLocation = rnd.Next(1, (NumberOfUsers + 1));
                    if (Directory.Exists(GeneralPathToSave + NewItemLocation) == true)
                    {
                        var queryAllCustomers = from data in DataList
                                                where (data.OuterID == MissingItem.OuterID) && (data.InnerID == MissingItem.InnerID) && (data.Location == NewItemLocation)
                                                select data;
                        List<Data> IsThereTheSameItem = queryAllCustomers.ToList();
                        if (IsThereTheSameItem.Count == 0)
                        {
                            Count1 = 3;
                            NewUser[Count2] = NewItemLocation;
                            Count2++;
                        }
                    }
                }
            }
            return NewUser;

        }

        public static List<Data> Replace(int[] NewLocations, List<Data> MissingItems, List<Data> DataList, string GeneralPathToSave)
        {
            int Counter1 = 0;
            foreach (Data DataToDelete in MissingItems)
            {

                DataList.Remove(DataToDelete);

            }
            foreach (Data MissingItem in MissingItems)
            {
                var queryAllCustomers = from data in DataList
                                        where (data.OuterID == MissingItem.OuterID) && (data.InnerID == MissingItem.InnerID)
                                        select data;
                List<Data> ListOfDuplicationOptions = queryAllCustomers.ToList();
                Data ItemToDuplicate = ListOfDuplicationOptions.First();
                string NewPath = GeneralPathToSave + NewLocations[Counter1] + @"\" + MissingItem.OuterID + "_" + MissingItem.InnerID + ".dsys";
                byte[] NewValue = File.ReadAllBytes(GeneralPathToSave + ItemToDuplicate.Location + @"\" + ItemToDuplicate.OuterID + "_" + ItemToDuplicate.InnerID + ".dsys");
                File.WriteAllBytes(NewPath, NewValue);
                Data DataToSave = new Data(MissingItem.OuterID, MissingItem.InnerID, NewLocations[Counter1]);
                DataList.Add(DataToSave);

                Counter1++;
            }
            return DataList;
        }
    }
    class Class_ReconnectUser
    {
        public static int[] DisconnectedList(int NumberOfUsers, string GeneralPathToDisconnectedUsers)
        {
            int NumberOfDisconnected = 0;
            for (int i = 0; i < NumberOfUsers; i++)
            {
                if (Directory.Exists(@"C:\Users\Yair\OneDrive\יאיר כללי\לימודים כללי\פרויקט מדעית\Windows Form App 2.0\UnconnectedUsers\User" + (i + 1)))
                {
                    NumberOfDisconnected++;

                }
            }
            int[] DisconnectedUsers = new int[NumberOfDisconnected];
            int Counter1 = 0;
            for (int i = 0; i < NumberOfUsers; i++)
            {
                if (Directory.Exists(GeneralPathToDisconnectedUsers + (i + 1)))
                {
                    DisconnectedUsers[Counter1] = i + 1;
                    Counter1++;
                }
            }

            return DisconnectedUsers;


        }

        public static List<Data> DataUpdate(int UserToDataUpdate, string GeneralPathToSave, List<Data> DataList)
        {
            string[] Names = Directory.GetFileSystemEntries(GeneralPathToSave + UserToDataUpdate);
            foreach (string NameP in Names)
            {
                int NameBegin = NameP.LastIndexOf(@"\");
                string Name = "";
                for (int g = NameBegin + 1; g < NameP.LastIndexOf("") + 1; g++)
                {
                    Name = Name + NameP[g];
                }

                int OuterIdIntLocation = Name.LastIndexOf("_");
                string OuterIDString = Name.Substring(0, OuterIdIntLocation);
                int OuterID = int.Parse(OuterIDString);
                //int InnerIDIntLocation = Name.LastIndexOf(".");
                Name = "";
                for (int g = NameP.LastIndexOf("_") + 1; g < NameP.LastIndexOf("."); g++)
                {
                    Name = Name + NameP[g];
                }

                int InnerID = int.Parse(Name.Substring(0, Name.Length));
                int Location = UserToDataUpdate;
                Data TempDataToSave = new Data(OuterID, InnerID, Location);
                DataList.Add(TempDataToSave);



            }
            return DataList;
        }


    }
}


