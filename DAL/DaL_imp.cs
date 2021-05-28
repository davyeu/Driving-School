using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{

    /** brief info.
     * This class implement the interface "Idal" at "DAL" project
       the class  is "sealed" namely she cannot be inherited
       This class implemented by by singleton safty threads ctor.
     */
    public sealed class DaL_imp : Idal
    {
       
        #region  singelton ctor
        private static  DaL_imp instance = null;
        private static readonly object padlock = new object();
        private DaL_imp() { initialize(); } 
        // The public Instance property to use
        public static DaL_imp GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DaL_imp();
                    }
                    return instance;
                }
            }
        }

        #endregion

        /** initialize()
         * initilazie the driving school with some trainees and tester form prepared lists of names.
         * first initilaize 12 trainees, then initilaize 4 tester and at the end we set for each tester 4 trainees 
         * by entering their objects in Test cotr.
         * 
         * All the objects in this program stored in 3  static lists: trainess,tester,test.
         * there is no link to outer memory location (like sql-server web)
         */
        public void initialize()
        {
            int tmp;
            string[] firstNames = { "tal", "eden", "amir", "gad", "tom", "liat", "bar", "shmuel", "naor", "jhon" };
            string[] LastNames = { "Cohen", "Levi", "Khan", "Perez", "Selah", "Na`im", "Adelshtein", "Bozaglo", "Hason", "Shabt" };
            string tempid = "200000000";
            BE.Configuration.CounterTestId++;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 12; i++)
            {
                DS.dataSource.trainees.Add(new BE.Trainee(tempid));
                DS.dataSource.trainees[i].FirstName = firstNames[r.Next(0,9)];
                DS.dataSource.trainees[i].LastName = LastNames[r.Next(0, 9)];
                DS.dataSource.trainees[i].NumOfLessons = 21;
                DS.dataSource.trainees[i].KindOfCars= BE.MyEnum.kindOfCars.PrivateCar;
                tmp = int.Parse(tempid);
                tmp++;
                tempid=Convert.ToString(tmp);
            }
            for (int i = 0; i < 4; i++)
            {
              
                // at the lines below I added some initial detials to the testers.
                
                int tempRandom = r.Next(140,150);
                DS.dataSource.testers.Add(new BE.Tester(tempid));
                DS.dataSource.testers[i].FirstName=firstNames[r.Next(0, 9)];
                DS.dataSource.testers[i].LastName= LastNames[r.Next(0, 9)];
                DS.dataSource.testers[i].MaximumDistanceFromAddress = Convert.ToDouble(tempRandom);
                DS.dataSource.testers[i].KindOfCar.Add(MyEnum.kindOfCars.PrivateCar);
                DS.dataSource.testers[i].KindOfCar.Add(MyEnum.kindOfCars.Semitrailer);
                DS.dataSource.testers[i].KindOfCar.Add(MyEnum.kindOfCars.Truck);
                DS.dataSource.testers[i].KindOfCar.Add(MyEnum.kindOfCars.TwoWheeledVehicles);

                tmp = int.Parse(tempid);
                tmp++;
                tempid=Convert.ToString(tmp);
            }
            for (int i = 0, j = 0; i < 12; i++,j++)
            {
                if (j == 4)
                    j = 0;
                DS.dataSource.tests.Add(new BE.Test(
                    DS.dataSource.testers[j],
                    DS.dataSource.trainees[i]));
                
            }
        }
       
        public void AddTest(Test test)
        {
            DS.dataSource.tests.Add(test);
        }

        public void AddTester(Tester tes)
        {
             DS.dataSource.testers.Add(tes);
        }

        public void AddTrainee(Trainee tr)
        {
            DS.dataSource.trainees.Add(tr);
        }

        public void DeleteTester(Tester tester)
        {
            for (int i = 0; i < DS.dataSource.testers.Count; i++)
            {
                if (DS.dataSource.testers[i].Id == tester.Id)
                {
                    DS.dataSource.testers.RemoveAt(i); 
                    return;
                }
            }
        }

        public void DeleteTrainee(Trainee trainee)
        {
            for (int i = 0; i < DS.dataSource.trainees.Count; i++)
            {
                if (DS.dataSource.trainees[i].Id == trainee.Id)
                {
                    DS.dataSource.trainees.RemoveAt(i);
                    return;
                }
            }
        }

        public void DeleteTest(Test test)
        {
            for (int i = 0; i < DS.dataSource.tests.Count; i++)
            {
                if (DS.dataSource.tests[i].IdOfTest == test.IdOfTest)
                {
                    DS.dataSource.tests.RemoveAt(i);
                    return;
                }
            }
        }

        public List<Tester> GetTesters()
        {
            //return a clone of the list at the database
            List<Tester> temp= new List<BE.Tester>();
            foreach (Tester t in DS.dataSource.testers)
                temp.Add((Tester)t.Clone());
            return temp;
        }

        public List<Test> GetTests()
        {
            List<Test> temp = new List<BE.Test>();
            foreach (Test t in DS.dataSource.tests)
                temp.Add((Test)t.Clone());
            return temp;
        }

        public List<Trainee> GetTrainees()
        {
            List<Trainee> temp = new List<BE.Trainee>();
            foreach (Trainee tr in DS.dataSource.trainees)
                temp.Add((Trainee)tr.Clone());
            return temp;
        }

        public void UpdateTest(Test test)
        {
            for (int i=0;i< DS.dataSource.tests.Count;i++)
            {
                if (DS.dataSource.tests[i].IdOfTest == test.IdOfTest)
                {
                    DS.dataSource.tests[i] = test;
                    return;
                }
            }
        }

        public void UpdateTester(Tester tester)
        {
            for (int i=0; i< DS.dataSource.testers.Count;i++)
            {
                if(DS.dataSource.testers[i].Id==tester.Id)
                {
                    DS.dataSource.testers[i] = tester;
                    return;
                }
            }
        }

        public void UpdateTrainee(Trainee trainee)
        {
            for (int i = 0; i < DS.dataSource.trainees.Count; i++)
            {
                if (DS.dataSource.trainees[i].Id == trainee.Id)
                {
                    DS.dataSource.trainees[i] = trainee;
                    return;
                }
            }
        }

        public Tester GetTester(string id)
        {
            var x = from item in DS.dataSource.testers
                    where item.Id == id     //what i search
                    select item;
            var y = x.ToList();
            return y[0];

        }

        public Trainee GetTrainee(string id)
        {
            return DS.dataSource.trainees.Find(item => item.Id == id);
        }

        public List<Test> GetTests(Func<Test, bool> p)
        {
            var x = from item in DS.dataSource.tests
            where p(item)    
            select item;
            var y = x.ToList();
            return y;
           
        }

       
    }
}
