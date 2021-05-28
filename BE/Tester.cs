using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    
    public class Tester : ICloneable
    {
      
        #region fields
        private string id;
        private string lastName;
        private String firstName;
        private DateTime dateOfBirth;
        private MyEnum.gender gender;
        private string pelephoneNumber;
        private Address address;
        private double numOfExperience;
        private int maxOfTestInWeek;
        public List<MyEnum.kindOfCars> kindOfCar = new List<MyEnum.kindOfCars>();
        private bool[,] arrayOfWorkerDays = new bool[5, 6];
        private double maximumDistanceFromAddress;
        private int numOfTestsInWeek;
        #endregion
        #region properties
        public string Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public MyEnum.gender Gender { get => gender; set => gender = value; }
        public string PelephoneNumber { get => pelephoneNumber; set => pelephoneNumber = value; }
        public Address Address { get => address; set => address = value; }
        public double NumOfExperience { get => numOfExperience; set => numOfExperience = value; }
        public int MaxOfTestInWeek { get => maxOfTestInWeek; set => maxOfTestInWeek = value; }
        public List<MyEnum.kindOfCars> KindOfCar { get => kindOfCar; set => kindOfCar = value; }
        public bool[,] ArrayOfWorkerDays { get => arrayOfWorkerDays; set => arrayOfWorkerDays = value; }
        public double MaximumDistanceFromAddress
        { get => maximumDistanceFromAddress; set => maximumDistanceFromAddress = value; }
        public int NumOfTestsInWeek { get => numOfTestsInWeek; set => numOfTestsInWeek = value; }
        #endregion
        #region ctor 
        public Tester(string _id = "", string lastName = "", string firstName = "",
            DateTime dateOfBirth = default(DateTime), MyEnum.gender gender = MyEnum.gender.male, string pelephoneNumber = "",
            Address _address = null, double numOfExperience = 0, int maxOfTestInWeek = 0
            /*List<MyEnum.kindOfCars> _kindOfCar*//*, bool[,] arrayOfWorkerDays = null*/,
            double maximumDistanceFromAddress = 0,int _numOfTestInWeek=0)
        {
            Id = _id;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            PelephoneNumber = pelephoneNumber;
            address = _address;
            if (address == null)
                address = new Address();
            NumOfExperience = numOfExperience;
            MaxOfTestInWeek = maxOfTestInWeek;
            
           
            for (int i = 0; i < Configuration.daysOfWork; i++)
            {
                for (int j = 0; j < Configuration.hourOfWork; j++)
                {
                    ArrayOfWorkerDays[i, j] = false; 
                    
                }
            }           
            MaximumDistanceFromAddress = maximumDistanceFromAddress;
            NumOfTestsInWeek = _numOfTestInWeek;
        }

        public Tester(string _id)
        {
            Id = _id;
           
        }
        #endregion
        #region ToString
        public override string ToString()
        {
          
            return string.Format("First name: {0}, Last name: {1}",
              FirstName, LastName );

        }

        #endregion
        #region Clone
        public object Clone() // Deep copy
        {
            Tester other = new Tester();
            other.Id = Id;
            try
            {
                other.LastName = string.Copy(LastName);
                other.FirstName = string.Copy(FirstName);
                other.DateOfBirth = new DateTime(DateOfBirth.Year, DateOfBirth.Month, DateOfBirth.Day);
                other.Gender = Gender;
                other.PelephoneNumber = PelephoneNumber;
                other.NumOfExperience = NumOfExperience;
                other.NumOfTestsInWeek = numOfTestsInWeek;
                other.MaxOfTestInWeek = MaxOfTestInWeek;
                if (address != null)
                    other.address = new Address(address.streetName, address.numberOfBuilding, address.City);
                other.kindOfCar = kindOfCar;
                for (int i = 0; i < Configuration.daysOfWork; i++)
                {
                    for (int j = 0; j < Configuration.hourOfWork; j++)
                    {
                        other.ArrayOfWorkerDays[i, j] = ArrayOfWorkerDays[i, j];
                    }
                }
                other.MaximumDistanceFromAddress = MaximumDistanceFromAddress;
            }
           catch (Exception ex)
            {

            }
            
            return other;
        }
        #endregion
    }
}

