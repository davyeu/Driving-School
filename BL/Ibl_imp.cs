using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public class Ibl_imp : Ibl
    {

       private static DAL.Idal dal;
        #region  singelton ctor
         private static  Ibl_imp instance = null;
        private static readonly object padlock = new object();
        private Ibl_imp() { }
        public static Ibl_imp GetInstance
        { get {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Ibl_imp();
                    }
                }
                return instance; 
            } 
        }
        public static void DefinedDalInstance(string typeDal)
        {
            dal = DAL.FactoryDal.GetDal(typeDal);
        }
       
        #endregion

        public SuitableTests suit; // creating a instance of the delegate

        #region properties
        /// <summary>
        /// /// return a copy of the list
        /// </summary>
        /// <returns></returns>
        public List<Tester> GetTesters()
        {
            return dal.GetTesters();
        }

        public List<Test> GetTests()
        {
            return dal.GetTests();
        }

        public List<Trainee> GetTrainees()
        {
            return dal.GetTrainees();
        }
        #endregion
        #region functions
        public void AddTest(Test test)
        {
            DateTime Time= new DateTime();
            DateTime date = DateTime.Now;
            try
            {
                BE.Trainee trainee = dal.GetTrainee(test.IdOfTrainee);
                BE.Tester tester = dal.GetTester(test.IdOfTester);
                List<BE.Tester> allOfOpenTester = openTesters(test.TimeOfTest);
                List<Test> allTests = dal.GetTests();
                List<Trainee> allTrainee = dal.GetTrainees();
                if (trainee.NumOfLessons < 20)
                    throw new Exception("the trainee must to do minimum 20 lesonss");
                //if (test.KindOfCar != trainee.KindOfCars)
                //    throw new Exception("the kind of car in the test and the kind of car in trainee is not suitble ");
                if (allTrainee.Find(item => item.Id == trainee.Id) == null)
                    throw new Exception("the trainee not found");

                if (test.TimeOfTest.DayOfYear - trainee.LastTest.DayOfYear < 7)
                    throw new Exception("we need minimum 7 days between the tests");


                //if (tester.NumOfTestsInWeek >= tester.MaxOfTestInWeek)
                //    throw new Exception("The Tester passed the weekly premitted amount of tests");
                if (allOfOpenTester == null)
                {
                    Time = ReplacementTime(trainee);
                    string msg = Convert.ToString(Time);
                    throw new Exception("There is no free tester for this test," +
                        "but there is open time at" + " " + msg);
                }
                if (allTests.Find(item => item.TimeOfTest == test.TimeOfTest && item.IdOfTester == tester.Id) != null)
                    throw new Exception("It is forbidden to set two tests for the same Tester at the same time");

                if (allTests.Find(item => item.TimeOfTest == test.TimeOfTest && item.IdOfTrainee == trainee.Id) != null)
                    throw new Exception("It is forbidden to set two tests for the same Trainee at the same time");
                //Trainee tr = allTrainee.Find(item => item.Id == trainee.Id && item.KindOfCars == trainee.KindOfCars);//how i combine between kindofcar and score
                //if (tr != null)
                Test tes= allTests.Find(item => item.IdOfTrainee == trainee.Id && item.Score == true && item.KindOfCar == trainee.KindOfCars&&item.GearBox==test.GearBox);
                if (tes!=null)
                    throw new Exception("The trainee has already passed the test on this type of vehicle");
                IEnumerable<MyEnum.kindOfCars> templist1= from MyEnum.kindOfCars item in tester.KindOfCar
                                                         where item == trainee.KindOfCars
                                                         select item;
                List<MyEnum.kindOfCars> templist2 = new List<MyEnum.kindOfCars>();
                foreach (var item in templist1)
                    templist2.Add(item);
                if (templist2.Count==0)
                    throw new Exception("The type of specialization of the student's examiner and exam is not the same");
                dal.AddTest(test);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddTester(Tester tes)
        {
            foreach (Tester item in dal.GetTesters())
            {
                if (tes.Id == item.Id)
                    throw new Exception("There is already same id number at the list");
            }
            DateTime date = DateTime.Now;

            try
            {
                if (date.Year - tes.DateOfBirth.Year < 40)
                    throw new Exception("The tester` age is smaller then 40");
                dal.AddTester(tes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AddTrainee(Trainee tr)
        {
            foreach (Trainee item in dal.GetTrainees())
            {
                if (tr.Id == item.Id)
                    throw new Exception("There is already same id number at the list");
            }

            DateTime date = DateTime.Now;
            try
            {
                if (date.Year - tr.DateOfBirth.Year < 18)
                    throw new Exception("the Trainee age is smaller then 18");
                dal.AddTrainee(tr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteTester(Tester tes)
        {
            dal.DeleteTester(tes);
        }

        public void DeleteTrainee(Trainee tr)
        {
            dal.DeleteTrainee(tr);
        }

        public void DeleteTest(Test test)
        {
            dal.DeleteTest(test);
        }
        public List<Tester> testersInTheArae(BE.Address destination)
        {
            /// <summary>
            ///         The function find all the testers that lived at least at radious "x" (x=MaxDistance)
            ///         from the address at the argument of the function
            /// </summary>
            /// <returns> list of suitable testers </returns>
           
            double distance; 
            List<Tester> allTester = GetTesters();
            List<Tester> selectedTesters = new List<Tester>();
             
            foreach (Tester t in allTester)
            {
                try
                {
                    distance = new CalculateDistanceAndTimeThread(t.Address, destination).DistanceInKM;
                }
               catch (Exception ex)
                {
                    //chose a random number
                    Random Distance = new Random(DateTime.Now.Millisecond);
                     distance = Convert.ToDouble(Distance.Next(100)); // up to 100 kilometers
                }
                if (t.MaximumDistanceFromAddress >= distance)
                    selectedTesters.Add(t);
            }
            return selectedTesters;

            //the sentence below s h o u l d be  eqal to the code above:

            // var selectedTesters = allTester.Where(item => item.MaximumDistanceFromAddress >= distance).Select(item => item);
            //return selectedTesters.ToList();

        }

        public List<BE.Tester> openTesters(DateTime dayAndHour)
        {
            /// <summary>
            /// The function find the testers that open to work at specific day and hour
            /// <returns> list of suitable testers          </returns>

            //grouping that accepts all testers who work on a given date and time
            List<Test> arry = dal.GetTests(/*item => item.TimeOfTest == dayAndHour*/);
            
            int day = Convert.ToInt32(dayAndHour.DayOfWeek);
            // the variable "DayOfWeek" return An enumerated constant that indicates the day of the week 
            //of this System.DateTime
            if (day > 4)
                return null;
            int hour = dayAndHour.Hour;
            //the variable "Hour" return The hour component, expressed as a value between 0 and 23.
            if (hour < 9 || hour > 15)
                return null;
            hour -= 9; // decresing is nesscary in order to match the hours at the booliean matrix 
            // "ArrayOfWorkerDays" that belong to each testers
            List<Tester> allTester = GetTesters();
            List<Tester> selectedTesters = new List<Tester>();
            foreach (Tester t in allTester)
            {
                if (t.ArrayOfWorkerDays[day, hour] == false&&arry.Find(item=>item.IdOfTester==t.Id)==null)
                    selectedTesters.Add(t);
            }
            return selectedTesters;
        }
        public List<BE.Test> suitableTests()
        {/// <summary>
         /// This function recive a delegate to functions that recive object from "Test" type
         /// and return boolean value. namely the function cheak whether the recived object
         /// fullfill the condtion at the function and return true or false.
         /// fore each test this function cheak whether the test is return true for all the function 
         /// the delegate registerd to them - if it true we add it to the "selected Test".
         /// </summary>
         /// <param name="t"></param>
         /// <returns> selected Test</returns>
            List<BE.Test> allTest = GetTests();
            List<BE.Test> selectedTest = new List<BE.Test>();
            foreach (Test tes in allTest)
            {
                if (suit != null && suit(tes) == true)
                    selectedTest.Add(tes);
            }
            return selectedTest;

        }
        public List<BE.Test> NumberOftests(BE.Trainee tr)
        {
            /// <summary>
            /// This function recive a trainee and return all the tests that he rigested to them 
            /// </summary>

            List<BE.Test> allTest = GetTests();
            List<BE.Test> selectedTest = new List<BE.Test>();
            foreach (Test tes in allTest)
            {
                if (tes.IdOfTrainee == tr.Id)
                {
                    selectedTest.Add(tes);
                }
            }
            return selectedTest;
        }
        public List<BE.Test> NumberOftests(DateTime date)
        {
            /// <summary>
            /// This function recive a date and return all the tests at this day.
            /// </summary>

            List<BE.Test> allTest = GetTests();
            List<BE.Test> selectedTest = new List<BE.Test>();
            foreach (Test test in allTest)
            {
                if (test.TimeOfTest == date)
                    selectedTest.Add(test);
            }
            return selectedTest;
        }

        public bool DeservingToLicence(BE.Trainee tr)
        {
            /// <summary>
            /// This fuction recive a trainee and return true if he
            /// deserve to a licence or false if he did not deserve to.
            List<BE.Test> allTest = GetTests();
            foreach (Test tes in allTest)
            {
                if (tes.IdOfTrainee == tr.Id)
                {
                    if (tes.Score == true)
                        return true;
                }
            }
            return false;
        }

        public void UpdateTest(Test test)
        {
            dal.UpdateTest(test);
        }
        public DateTime ReplacementTime(BE.Trainee tr)
        {
            int day = 0, hour = 0;
            foreach (Tester tes in GetTesters())
            {
                
                bool flag = false;
                for (int i = 0; i <BE.Configuration.daysOfWork && flag==false; i++)
                {
                  for (int j=0;j< BE.Configuration.hourOfWork && flag == false; j++)
                    {
                        if(tes.ArrayOfWorkerDays[i,j]==false)
                        {
                            day = i;
                            hour= j+ 9;
                            flag = true;

                        }
                    }
                }
                
            }
            return new DateTime(2018, 12, day, hour, 0, 0);
        }
        public void UpdateTester(Tester tes)
        {
            dal.UpdateTester(tes);
        }

        public void UpdateTrainee(Trainee tr)
        {
            dal.UpdateTrainee(tr);
        }
        #region Groups
        public Dictionary<List<MyEnum.kindOfCars>, List<BE.Tester>> GroupByTestersSpecialization(bool orderBy)
        {
            /// <summary>
            /// This function create groups of testers by their Specialization
            /// </summary>
            /// <param name="orderBy"- define whether the group.value will be ordered></param>
            /// <returns> dictonary object from g.key and g.value</returns>

            List<BE.Tester> tempList = new List<BE.Tester>();
            if (orderBy == false)
            {
                var SpecializationGroups =
                from tes in GetTesters()
                group tes by tes.KindOfCar into g
                select new { Specialization = g.Key, testers = g };

                Dictionary<List<MyEnum.kindOfCars>, List<BE.Tester>> d =
                    new Dictionary<List<MyEnum.kindOfCars>, List<BE.Tester>>();
                foreach (var item in SpecializationGroups)
                {
                    foreach (var t in item.testers)
                        tempList.Add(t);
                    d.Add(item.Specialization, tempList);
                }
                return d;
            }
            else
            {
                var SpecializationGroups =
                from tes in GetTesters()
                orderby tes.Id
                group tes by tes.KindOfCar into g
                select new { Specialization = g.Key, testers = g };

                Dictionary<List<MyEnum.kindOfCars>, List<BE.Tester>> d =
                   new Dictionary<List<MyEnum.kindOfCars>, List<BE.Tester>>();
                foreach (var item in SpecializationGroups)
                {
                    foreach (var t in item.testers)
                        tempList.Add(t);
                    d.Add(item.Specialization, tempList);
                }
                return d;
            }


        }
        public Dictionary<string, List<BE.Trainee>> GroupByTraineesSchoolDriving(bool orderBy)
        {
            /// <summary>
            /// This function create groups of trainees by their School Driving name
            /// </summary>
            /// <param name="orderBy"- define whether the group.value will be ordered></param>
            /// <returns> dictonary object from g.key and g.value</returns>

            Dictionary<string, List<BE.Trainee>> d;
            List<BE.Trainee> tempList = new List<BE.Trainee>();
            if (orderBy == false)
            {
                var SchoolDriving =
                    from tr in GetTrainees()
                    group tr by tr.NameOfTheSchool into g
                    select new { SchoolName = g.Key, trainees = g };

                d = new Dictionary<string, List<BE.Trainee>>();
                foreach (var item in SchoolDriving)
                {
                    foreach (var tr in item.trainees)
                        tempList.Add(tr);
                    d.Add(item.SchoolName, tempList);
                }
                return d;
            }

            else
            {
                var SchoolDriving =
                   from tr in GetTrainees()
                   orderby tr.Id
                   group tr by tr.NameOfTheSchool into g
                   select new { SchoolName = g.Key, trainees = g };

                d = new Dictionary<string, List<BE.Trainee>>();
                foreach (var item in SchoolDriving)
                {
                    foreach (var tr in item.trainees)
                        tempList.Add(tr);
                    d.Add(item.SchoolName, tempList);
                }
                return d;
            }

        }
        public Dictionary<string, List<BE.Trainee>> GroupByTeachingTester(bool orderBy)
        {
            /// <summary>
            /// This function create groups of trainees by their School Teaching Tester
            /// </summary>
            /// <param name="orderBy"- define whether the group.value will be ordered></param>
            /// <returns> dictonary object from g.key and g.value</returns>

            Dictionary<string, List<BE.Trainee>> d = new Dictionary<string, List<BE.Trainee>>();
            List<BE.Trainee> tempList = new List<BE.Trainee>();
            if (orderBy == false)
            {
                var TeachingTester =
                    from tr in GetTrainees()
                    group tr by tr.NameOfTeacher into g
                    select new { name = g.Key, trainees = g };

                foreach (var item in TeachingTester)
                {
                    foreach (var tr in item.trainees)
                        tempList.Add(tr);
                    d.Add(item.name, tempList);
                }
            }
            else
            {
                var TeachingTester =
                    from tr in GetTrainees()
                    orderby tr.Id
                    group tr by tr.NameOfTeacher into g
                    select new { name = g.Key, trainees = g };

                foreach (var item in TeachingTester)
                {
                    foreach (var tr in item.trainees)
                        tempList.Add(tr);
                    d.Add(item.name, tempList);
                }
            }
            return d;
        }
        public Dictionary<int, List<BE.Trainee>> GroupByTestingPerformanceNum(bool orderBy)
        {
            /// <summary>
            /// This function create groups of trainees by their numbers of tests they did.
            /// </summary>
            /// <param name="orderBy"- define whether the group.value will be ordered></param>
            /// <returns> dictonary object from g.key and g.value</returns>

            List<BE.Trainee> tempList = new List<BE.Trainee>();
            Dictionary<int, List<BE.Trainee>> d = new Dictionary<int, List<BE.Trainee>>();


            if (orderBy == false)
            {
                var numOfTesting =
                    from tr in GetTrainees()
                    group tr by NumberOftests(tr).Count into g
                    select new { numOftests = g.Key, trainees = g };

                foreach (var item in numOfTesting)
                {
                    foreach (var tr in item.trainees)
                        tempList.Add(tr);
                    d.Add(item.numOftests, tempList);
                }
            }
            else
            {
                var numOfTesting =
                    from tr in GetTrainees()
                    orderby tr.Id
                    group tr by NumberOftests(tr).Count into g
                    select new { numOftests = g.Key, trainees = g };

                foreach (var item in numOfTesting)
                {
                    foreach (var tr in item.trainees)
                        tempList.Add(tr);
                    d.Add(item.numOftests, tempList);
                }
            }
            return d;
        }

       

        #endregion

        #endregion
    }//
}
