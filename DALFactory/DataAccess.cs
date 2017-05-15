using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Models;
using IDAL;
using DAL;
using System.Reflection;

namespace DALFactory
{
    public class DataAccess
    {
        private static string AssemblyName = ConfigurationManager.AppSettings["Path"];
        private static string db = ConfigurationManager.AppSettings["DB"];
        public static IUsers Createuse()
        {
            string className = AssemblyName + "." + db + "Users";
            return (IUsers)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IGoods Creategood()
        {
            string className = AssemblyName + "." + db + "Goods";
            return (IGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IClassify Createclassify()
        {
            string className = AssemblyName + "." + db + "Classify";
            return (IClassify)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICart CreateCart()
        {
            string className = AssemblyName + "." + db + "Cart";
            return (ICart)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IBrave Createbrave()
        {
            string className = AssemblyName + "." + db + "Brave";
            return (IBrave)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICommentGoods CreateCommgood()
        {
            string className = AssemblyName + "." + db + "CommentGoods";
            return (ICommentGoods)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static INews CreatNews()
        {
            string className = AssemblyName + "." + db + "News";
            return (INews)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static ICommentNews Createcommentnews()
        {
            string className = AssemblyName + "." + db + "CommentNews";
            return (ICommentNews)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
