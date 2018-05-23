using System;
using System.Collections.Generic;
using System.Text;

namespace PreAPI
{
    class Class_TypeClass
    {
        
    }
    public class Data
    {


        public int InnerID { get; set; }
        public int OuterID { get; set; }
        public int Location { get; set; }




        public Data(int TempOuterID, int TempInnerID, int TempLocation)
        {
            InnerID = TempInnerID;
            OuterID = TempOuterID;
            Location = TempLocation;



        }
    }
    class Item
    {
        public byte[] ItemValue { get; set; }
        public int ItemLength { get; set; }
        public int ItemInnerId { get; set; }
        public int FileOuterId { get; set; }


        public Item(int ItemInnerLengthTemperar, int ItemInnerIdTemperar, int FileOuterIdTemperar  /*,byte?[] ItemValue*/)
        {
            ItemValue = new byte[ItemInnerLengthTemperar];
            ItemLength = ItemInnerLengthTemperar;
            ItemInnerId = ItemInnerIdTemperar;
            FileOuterId = FileOuterIdTemperar;
        }
    }
}
