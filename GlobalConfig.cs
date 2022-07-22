using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager
{
    public static class GlobalConfig
    {
        public static ISession mySession = SetupHibernate();
        public static ISession SetupHibernate()
        {
            Configuration myConfiguration = new Configuration().Configure();
            ISessionFactory mySessionFactory = myConfiguration.BuildSessionFactory();
            ISession mySession = mySessionFactory.OpenSession();

            return mySession;
        }
        public static IDataConnection Connection { get; set; }


        //public static void InitializeConnections(string dataBase)
        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Hibernate)
            {
                HibernateConnector hibernateConnector = new HibernateConnector();
                Connection = hibernateConnector;
            }
        }
    }
}
