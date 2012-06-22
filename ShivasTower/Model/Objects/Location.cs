using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ShivasTower.Model.Objects
{
    [Serializable]
    class Location : IComparable<Location>
    {
        public int x { set; get; }
        public int y { set; get; }

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(Location location)
        {
            if (location.x == x && location.y == y)
                return 0;
            else
                return -1;
        }

        //Move to Central Library Location
        public T DeepClone<T>(T objOriginal)
        {
            //Fix MemoryStream with alternate StreamType
            using (Stream objStream = new MemoryStream())
            {
                BinaryFormatter objSerializer = new BinaryFormatter();
                objSerializer.Serialize(objStream, objOriginal);
                objStream.Position = 0;
                return (T)objSerializer.Deserialize(objStream);
            }
        }
    }
}