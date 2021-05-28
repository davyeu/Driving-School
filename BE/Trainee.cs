using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //this class represent student at driving school
    public class Trainee : ICloneable
    {
        #region fields
        private string id;
        private string lastName;
        private String firstName;
        private DateTime dateOfBirth;
        private MyEnum.gender gender;
        private string pelephoneNumber;
        private Address address;
        private MyEnum.kindOfCars kindOfCars;
        private MyEnum.gearBox gearBox;
        private string nameOfTheSchool;
        private string nameOfTeacher;
        private int numOfLessones;
       private DateTime lastTest;
        #endregion
        #region properties
        public string Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public MyEnum.gender Gender { get => gender; set => gender = value; }
        public string PelephoneNumber { get => pelephoneNumber; set => pelephoneNumber = value; }
        public Address Address { get => address; set => address = value; }
        public MyEnum.kindOfCars KindOfCars { get => kindOfCars; set => kindOfCars = value; }
        public MyEnum.gearBox GearBox { get => gearBox; set => gearBox = value; }
        public string NameOfTheSchool { get => nameOfTheSchool; set => nameOfTheSchool = value; }
        public string NameOfTeacher { get => nameOfTeacher; set => nameOfTeacher = value; }
        public int NumOfLessons { get => numOfLessones; set => numOfLessones = value; }
        public DateTime LastTest { get => lastTest; set => lastTest = value; }
        #endregion
        #region ctor
        public Trainee(string _id = "", string lastName = "", string firstName = "", DateTime dateOfBirth = default(DateTime),
           MyEnum.gender gender = MyEnum.gender.male, string pelephoneNumber = " ", Address _address = null,
           MyEnum.kindOfCars kindOfCars = MyEnum.kindOfCars.PrivateCar, MyEnum.gearBox _gearBox = MyEnum.gearBox.automatic,
           string nameOfTheSchool = "", string nameOfTeacher = "", int numOfLessons = 0,DateTime lastTest= default(DateTime))
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
            KindOfCars = kindOfCars;
            gearBox = _gearBox;
            NameOfTheSchool = nameOfTheSchool;
            NameOfTeacher = nameOfTeacher;
            NumOfLessons = numOfLessons;
            LastTest = lastTest;
        }

        public Trainee(string _id)
        {
            Id = _id;
        }

        #endregion
        #region ToString
        public override string ToString()
        {
            return string.Format("First name: {0}, Last name: {1}",
            FirstName, LastName);
        }

        #endregion
        #region Clone
        public object Clone()
        {
            Trainee other = new Trainee();
            other.Id = Id;
            try
            {
                other.LastName = string.Copy(LastName);
                other.FirstName = string.Copy(FirstName);
                other.DateOfBirth = new DateTime(DateOfBirth.Year, DateOfBirth.Month, DateOfBirth.Day);
                other.Gender = Gender;
                other.PelephoneNumber = PelephoneNumber;
                other.Address = address;
                other.KindOfCars = KindOfCars;
                other.GearBox = gearBox;
                other.NameOfTheSchool = string.Copy(NameOfTheSchool);
                other.NameOfTeacher = string.Copy(NameOfTeacher);
                other.NumOfLessons = NumOfLessons;
                other.lastTest = new DateTime(lastTest.Year, lastTest.Month, lastTest.Day);
            }
            catch (Exception ex)
            {

            }
            return other;
        }
        #endregion
    }
}
