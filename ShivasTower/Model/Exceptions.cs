using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ShivasTower.Model
{
    abstract class Exceptions
    {
        public bool BitmapException(string path)
        {
            bool blnResult = false;
            List<string> lstAcceptedImageExts = Consts.AcceptedImageExts;

            if(lstAcceptedImageExts.Contains(Path.GetExtension(path)))
            {
                blnResult = true;
            }

            return blnResult;
        }

        public bool FileNotFoundException(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (File.Exists(path))
                {
                    return true;
                }
            }

            return false;
        }

        public string SerializationException(string strXml)
        {
            return "";
        }
    }
}