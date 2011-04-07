
using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;



namespace PersistData
{
    public sealed class NHibernateHelper
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;

        private static ISession currentSession = null; //todo how to cache the session

        static NHibernateHelper()
        {
            sessionFactory = new Configuration().Configure().BuildSessionFactory();
            
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
