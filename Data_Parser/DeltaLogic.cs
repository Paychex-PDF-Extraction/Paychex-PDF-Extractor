using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Parser
{
    public static class deltaLogic
    {
        public static DataClass parseDelta(string data, DataClass DataStore)
        {
            /*temporarily modified bc of possible issue with instantiating multiple instances of static class object: added 
             second parameter 'DataClass DataStore' to parseDelta function and commented out new DataClass declaration immediately
             below (4/27/2019) */

            //DataClass DataStore = new DataClass();
            DataStore.VEND_NAME = "Delta Airlines"; // since Delta appeared in receipt, Delta is vend_name
            DataStore.VEND_ID = 0001; // Delta ID is 0001




            /* Logic for parsing customer names */
            string tempName;

            // using look behind we can start reading a certain point until the specified ending
            tempName = storeMatch(data, @"(?<=INFORMATION).+?(?=Sky)");
            tempName = tempName.Trim(); // trim the leading a tailing white space so split method can work
            string[] names = tempName.Split(' ');
            DataStore.EMP_FNAME = names[0];
            DataStore.EMP_LNAME = names[names.Length - 1];


            /* Logic for parsing DOP */

            string date = storeMatch(data, @"(?<=Date of Purchase: ).+?(?=Flight)");
            date = date.Trim();
            var tempDate = DateTime.Parse(date);
            date = tempDate.ToShortDateString();
            DataStore.DOP = date;


            /* Logic for parsing TOTAL */

            string tempTotalPrice = storeMatch(data, @"(?<=Total Price:).+?(?=USD)");
            tempTotalPrice = tempTotalPrice.Trim();
            tempTotalPrice = tempTotalPrice.Remove(0, 1); // remove the $

            double totalPrice = double.Parse(tempTotalPrice);
            DataStore.TOTAL = totalPrice;


            /* Getting today's date */

            DateTime tempTodaysDate = DateTime.Today;
            string todaysDate = tempTodaysDate.ToShortDateString();
            DataStore.DOE = todaysDate;


            return DataStore;
        }

        public static string storeMatch(string text, string regex)
        {
            MatchCollection mc = Regex.Matches(text, regex);
            string test = mc[0].ToString();
            return test;
        }

    }
}
