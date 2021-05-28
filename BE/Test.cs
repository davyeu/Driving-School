using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BE
{
    public class Test : ICloneable
    {
        #region fields
        private int idOfTest;  // counter with 8 digits
        private string idOfTester;
        private string idOfTrainee;
        private DateTime timeOfTest;
        private Address _addressOfTest;
        private bool keepDistance;
        private bool lookingAtMirrors;
        private bool backParking;
        private bool signals; //Check whether the driver is signaling the movement
        private bool score;
        private string testerRemark;
        private MyEnum.kindOfCars kindOfCar;
        private MyEnum.gearBox gearBox;

        #endregion
        #region properties
        public int IdOfTest { get => idOfTest; set => idOfTest = value; } 
        public string IdOfTester { get => idOfTester; set => idOfTester = value; }
        public string IdOfTrainee { get => idOfTrainee; set => idOfTrainee = value; }
        public DateTime TimeOfTest { get => timeOfTest; set => timeOfTest = value; }
        public Address AddressOfTest { get => _addressOfTest; set => _addressOfTest = value; }
        public bool KeepDistance { get => keepDistance; set => keepDistance = value; }
        public bool LookingAtMirrors { get => lookingAtMirrors; set => lookingAtMirrors = value; }
        public bool BackParking { get => backParking; set => backParking = value; }
        public bool Signals { get => signals; set => signals = value; }
        public bool Score { get => score; set => score = value; }
        public string TesterRemark { get => testerRemark; set => testerRemark = value; }
        public MyEnum.kindOfCars KindOfCar { get => kindOfCar; set => kindOfCar = value; }
        public MyEnum.gearBox GearBox { get => gearBox; set => gearBox = value; }
       
        #endregion
        #region ctor
        public Test( Tester tes, Trainee tr)
        {
           
            idOfTest = Configuration.CounterTestId;
            IdOfTester = tes.Id;
            IdOfTrainee = tr.Id;
            Configuration.CounterTestId++;
        }

        public Test( string idOfTester = "", string idOfTrainee = "",
            DateTime timeOfTest = default(DateTime), Address _addressOfTest = default(Address),
            bool keepDistance = false, bool lookingAtMirrors = false,
            bool backParking = false, bool signals = false, bool score = false
            , string _TesterRemark = "",MyEnum.kindOfCars kindOfCars= MyEnum.kindOfCars.PrivateCar,MyEnum.gearBox gearBox=MyEnum.gearBox.automatic)
        {
            Configuration.CounterTestId++;
            idOfTest = Configuration.CounterTestId;
            IdOfTester = idOfTester;
            IdOfTrainee = idOfTrainee;
            TimeOfTest = timeOfTest;
            AddressOfTest = _addressOfTest;
            if (AddressOfTest == null)
                AddressOfTest = new Address();
            KeepDistance = keepDistance;
            LookingAtMirrors = lookingAtMirrors;
            BackParking = backParking;
            Signals = signals;
            Score = score;
            TesterRemark = _TesterRemark;
            kindOfCar = kindOfCars;
            GearBox = gearBox;
        }
        #endregion
        #region Tostring
        public override string ToString()
        {
            return this.IdOfTest.ToString();
        }
        #endregion
        #region Clone
        public object Clone()//deep copy
        {
            //Test tmp = (Test)this.MemberwiseClone();
            //tmp.TimeOfTest = new DateTime(timeOfTest);
            Test other = new Test();
           
            other.idOfTest = this.idOfTest;
            try
            {
                other.IdOfTester = IdOfTester;
                other.IdOfTrainee = IdOfTrainee;
                other.TimeOfTest = TimeOfTest;
                if (AddressOfTest != null)
                    other.AddressOfTest = new Address(AddressOfTest.streetName, AddressOfTest.numberOfBuilding,
                          AddressOfTest.City);
                other.KeepDistance = KeepDistance;
                other.LookingAtMirrors = LookingAtMirrors;
                other.BackParking = BackParking;
                other.Signals = Signals;
                other.kindOfCar = KindOfCar;
                other.gearBox = GearBox;
                other.Score = Score;
                if (TesterRemark != null)
                    other.TesterRemark = string.Copy(TesterRemark);
            }
            catch (Exception ex)
            {

            }
            return other;
        }

        #endregion
        
    }
    
}
