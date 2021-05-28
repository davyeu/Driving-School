using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using System.IO;

namespace DAL
{
    class Dal_XML_imp : Idal
    {
        static XElement EntityRoot;
        static string EntityPath;
        static XElement configRoot;
        static string configPath;

        private static readonly Dal_XML_imp instance = new Dal_XML_imp();
        #region  singelton ctor
        public Dal_XML_imp() { }
        public static Dal_XML_imp GetInstance(string entity="")
        {
           switch (entity)
            {
                case "Dal_XML_imp-Testers":
                    EntityPath = @"TestersXML.xml";
                    break;
                case "Dal_XML_imp-Trainees":
                    EntityPath = @"TrainnesXML.xml";
                    break;
                case "Dal_XML_imp-Tests":
                    EntityPath= @"TestsXML.xml";
                    break;
                default: EntityPath = @"TestersXML.xml";
                    break;

            }
            IsTheFileIsOpen();
            openConfigFile();
            return instance;
        }
        #endregion
        public static void openConfigFile()
        {
           configPath = @"config.xml";
            if (!File.Exists(configPath))
                CreateFiles(configPath);
            else
                LoadData(configPath);
            
        }
        public static void IsTheFileIsOpen()
        {
            if (!File.Exists(EntityPath))
                CreateFiles(EntityPath);
            else
                LoadData(EntityPath);

        }
        public static void CreateFiles(string path)
        {
            if (path == EntityPath)
            {
                EntityRoot = new XElement("Entites");
                EntityRoot.Save(path);
            }
            if (path== configPath)
            {
                configRoot = new XElement("config");
                configRoot.Save(path);
                configRoot.Add(new XElement("TestId", BE.Configuration.CounterTestId));
                configRoot.Save(path);
            }
        }

        private static void LoadData(string path)
        {
            try
            {
                EntityRoot = XElement.Load(path);
            }
            catch
            {
                CreateFiles(path);
            }
        }

        public void AddTest(Test test)
        {
            XElement TestId = new XElement("TestId", configRoot.Element("TestId").Value+1);
            XElement idOfTester = new XElement("TesterId", test.IdOfTester);
            XElement idOfTrainee = new XElement("TrainneId", test.IdOfTrainee);

            EntityRoot.Add(new XElement("test", TestId, idOfTester, idOfTrainee));
            EntityRoot.Save(EntityPath);
        }

        public void AddTester(Tester tes)
        {
            XElement id = new XElement("id", tes.Id);
            XElement firstName = new XElement("firstName", tes.FirstName);
            XElement lastName = new XElement("lastName", tes.LastName);
            XElement name = new XElement("name", firstName, lastName);

            EntityRoot.Add(new XElement("tester", id, name));
            EntityRoot.Save(EntityPath);
        }

        public void AddTrainee(Trainee tr)
        {
            XElement id = new XElement("id", tr.Id);
            XElement firstName = new XElement("firstName", tr.FirstName);
            XElement lastName = new XElement("lastName", tr.LastName);
            XElement name = new XElement("name", firstName, lastName);

            EntityRoot.Add(new XElement("tester", id, name));
            EntityRoot.Save(EntityPath);
        }

        public void DeleteTester(Tester tes)
        {
            XElement testerElement;
            try
            {
                testerElement = (from p in EntityRoot.Elements()
                                  where p.Element("id").Value == tes.Id
                                  select p).FirstOrDefault();
                testerElement.Remove();
                EntityRoot.Save(EntityPath);
            }
            catch(Exception) { }

        }

        public void DeleteTrainee(Trainee tr)
        {
            XElement trainneElement;
            try
            {
                trainneElement = (from p in EntityRoot.Elements()
                                 where p.Element("id").Value == tr.Id
                                 select p).FirstOrDefault();
                trainneElement.Remove();
                EntityRoot.Save(EntityPath);
            }
            catch (Exception) { }
        }

        public Tester GetTester(string id)
        {
            throw new NotImplementedException();
        }

        public List<Tester> GetTesters()
        {
            List<Tester> testers;
            try
            {
                testers = (from p in EntityRoot.Elements()
                            select new BE.Tester()
                            {
                                Id = (p.Element("id").Value),
                                FirstName = p.Element("name").Element("firstName").Value,
                                LastName = p.Element("name").Element("lastName").Value
                            }).ToList();
            }
            catch
            {
                testers = null;
            }
            return testers;
        }

        public List<Test> GetTests()
        {
            List<Test> tests;
            try
            {
                tests = (from p in EntityRoot.Elements()
                           select new BE.Test()
                           {IdOfTest = Convert.ToInt32(p.Element("NumberOfTest").Value),
                               IdOfTester = p.Element("TesterId").Value,
                               IdOfTrainee = p.Element("TrainneId").Value
                           }).ToList();
            }
            catch
            {
                tests = null;
            }
            return tests;
        }

        public Trainee GetTrainee(string id)
        {
            throw new NotImplementedException();
        
       
        }

        public List<Trainee> GetTrainees()
        {
            List<Trainee> trainees;
            try
            {
                trainees = (from p in EntityRoot.Elements()
                            select new BE.Trainee()
                            {
                                Id = (p.Element("id").Value),
                                FirstName = p.Element("name").Element("firstName").Value,
                                LastName = p.Element("name").Element("lastName").Value
                            }).ToList();
            }
            catch
            {
                trainees = null;
            }
            return trainees;
        }

        public void UpdateTest(Test test)
        {
            throw new NotImplementedException();
        }

        public void UpdateTester(Tester tes)
        {

            XElement TesterElement = (from p in EntityRoot.Elements()
                                       where p.Element("id").Value == tes.Id
                                       select p).FirstOrDefault();

            TesterElement.Element("name").Element("firstName").Value = tes.FirstName;
           TesterElement.Element("name").Element("lastName").Value = tes.LastName;

            EntityRoot.Save(EntityPath);

        }

        public void UpdateTrainee(Trainee tr)
        {

            XElement TrainneElement = (from p in EntityRoot.Elements()
                                      where p.Element("id").Value == tr.Id
                                      select p).FirstOrDefault();

            TrainneElement.Element("name").Element("firstName").Value = tr.FirstName;
            TrainneElement.Element("name").Element("lastName").Value = tr.LastName;

            EntityRoot.Save(EntityPath);
        }

        public void DeleteTest(Test test)
        {
            XElement testElement;
            try
            {
                testElement = (from p in EntityRoot.Elements()
                                  where p.Element("TestId").Value == test.IdOfTest.ToString()
                                  select p).FirstOrDefault();
                testElement.Remove();
                EntityRoot.Save(EntityPath);
            }
            catch (Exception) { }
        }
    }
}
