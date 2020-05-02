using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Parser
{
    /* Class for deciding which vendor logic to use. Add future vendor parsing methods here */

    public static class VendorSelection
    {
        public static DataClass ParseData(string pdfData)
        {
            DataClass data = new DataClass();

            if (pdfData.Contains("Delta"))
            {
                return deltaLogic.parseDelta(pdfData, data);
            }

            return data;
        }




    }
}
