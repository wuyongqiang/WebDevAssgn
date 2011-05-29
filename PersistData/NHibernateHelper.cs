
using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
using System.Configuration;


namespace PersistData
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;

        private static ISession currentSession = null; //todo how to cache the session
        public static string connectionString = null;
        public static string GetAppConnectionString()
        {
            ConnectionStringSettings ConnectionStringSettings =
            ConfigurationManager.ConnectionStrings["restaurantConnectionString"];

            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
            {
                throw new Exception("restaurantConnectionString cannot be found.");
            }

            connectionString = ConnectionStringSettings.ConnectionString;
            connectionString.Replace("Data Source", "Server");
            return connectionString;
        }
        static NHibernateHelper()
        {
            //connectionString = "Server=pos744;Initial Catalog=n7682905;Integrated Security=SSPI;";
            GetAppConnectionString();
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration().Configure();
            cfg.Properties["connection.connection_string"] = connectionString;
            sessionFactory = cfg.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {

            if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession();
            }

            return currentSession;
        }

        public static void CloseSession()
        {

            if (currentSession == null)
            {
                return;
            }

            currentSession.Close();
            currentSession = null;

        }

        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }

}
