using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        public static Idal GetDal (string typeDal)
        {
            switch (typeDal)
            {
                case "Dal_imp":
                    return DaL_imp.GetInstance;
                case "Dal_XML_imp-Testers":
                    return Dal_XML_imp.GetInstance("Dal_XML_imp-Testers");
                case "Dal_XML_imp-Trainees":
                    return Dal_XML_imp.GetInstance("Dal_XML_imp-Trainees");
                case "Dal_XML_imp-Tests":
                    return Dal_XML_imp.GetInstance("Dal_XML_imp-Tests");
                default: return DaL_imp.GetInstance;
            }
        }
    }
}
