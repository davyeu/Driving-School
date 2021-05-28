using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BE
{
    // this class represent all the static global fields
    public class Configuration
    {
        public static int CounterTestId=0;
        public static int mimimumNumberOflessons=20;
        public static int maximumTesterAge=70;
        public static int minimumTraineeAge=18;
        public static int rangeBetweenTests=7;


        #region consts
        public const int daysOfWork = 5; // belong to tester
        public const int hourOfWork = 6; // belong to tester
        #endregion
    }   
}
