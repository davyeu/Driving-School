using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public interface Idal 
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

        BE.Trainee GetTrainee(string id);
       BE.Tester GetTester(string id);
       

        List<BE.Tester> GetTesters();
        List<BE.Trainee> GetTrainees();
        List<BE.Test> GetTests();

       
    }

}
