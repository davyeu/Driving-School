using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        public static Ibl GetBL(string typeDal)
        {
            switch (typeDal)
            {
                case "Dal_imp":
                    Ibl_imp.DefinedDalInstance("Dal_imp");
                    return Ibl_imp.GetInstance;
                case "Dal_XML_imp-Testers":
                    Ibl_imp.DefinedDalInstance("Dal_XML_imp-Testers");
                    return Ibl_imp.GetInstance;
                case "Dal_XML_imp-Trainees":
                    Ibl_imp.DefinedDalInstance("Dal_XML_imp-Trainees");
                    return Ibl_imp.GetInstance;
                case "Dal_XML_imp-Tests":
                    Ibl_imp.DefinedDalInstance("Dal_XML_imp-Tests");
                    return Ibl_imp.GetInstance;
                default: Ibl_imp.DefinedDalInstance("Dal_imp");
                    return Ibl_imp.GetInstance;
            }
            
        }
    }
}