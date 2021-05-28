using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public delegate bool SuitableTests(BE.Test tes);
    public  interface Ibl 
    {

        void AddTester(BE.Tester tes);
        void DeleteTester(BE.Tester tes);
        void UpdateTester(BE.Tester tes);

        void AddTrainee(BE.Trainee tr);
        void DeleteTrainee(BE.Trainee tr);
        void UpdateTrainee(BE.Trainee tr);

        void AddTest(BE.Test test);
        void UpdateTest(BE.Test test);
        void DeleteTest(BE.Test test);
        DateTime ReplacementTime(BE.Trainee tr);
        List<BE.Tester> testersInTheArae(BE.Address ad);
        List<BE.Tester> openTesters(DateTime dayAndHour);
        List<BE.Test> suitableTests();
        List<BE.Test> NumberOftests(BE.Trainee tr);
        List<BE.Test> NumberOftests(DateTime date);

        Dictionary<List<BE.MyEnum.kindOfCars>, List<BE.Tester>> GroupByTestersSpecialization(bool sort=false);
        Dictionary<string, List<BE.Trainee>> GroupByTraineesSchoolDriving(bool sort = false);
        Dictionary<string, List<BE.Trainee>> GroupByTeachingTester(bool sort = false);
        Dictionary<int, List<BE.Trainee>> GroupByTestingPerformanceNum(bool sort = false);

        bool DeservingToLicence(BE.Trainee tr);

        List<BE.Tester> GetTesters();
        List<BE.Trainee> GetTrainees();
        List<BE.Test> GetTests();
    }
}
