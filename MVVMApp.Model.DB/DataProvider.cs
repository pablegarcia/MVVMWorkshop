using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

using NHibernate;
using NHibernate.Cfg;

namespace MVVMApp.Model.DB
{
    internal class DataProvider
    {
        #region Fields

        private SessionHelper _sessionHelper;

        #endregion Fields

        #region Constructors

        public DataProvider()
        {
            _sessionHelper = new SessionHelper();
        }

        #endregion Constructors

        #region Query Methods

        public IList<T> GetAll<T>()
        {
            using (ISession session = _sessionHelper.GetNewSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(T));

                return criteria != null ? criteria.List<T>() : null;
            }
        }

        #endregion Query Methods

        internal sealed class SessionHelper : IDisposable
        {
            #region Constants

            private const string SQLITE_FILENAME = "data.sqlite";

            #endregion Constants

            #region Fields

            private ISessionFactory _sessionFactory;

            #endregion Fields

            #region Methods

            public ISession GetNewSession()
            {
                if (_sessionFactory == null)
                    _sessionFactory = CreateSessionFactory();

                return _sessionFactory.OpenSession();
            }

            #endregion Methods

            #region Private Methods

            private ISessionFactory CreateSessionFactory()
            {
                string nameResource = $"{Assembly.GetExecutingAssembly().GetName().Name}.nhibernate.cfg.xml";
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(nameResource);

                using (XmlReader reader = XmlReader.Create(stream))
                {
                    Configuration configuration = new Configuration();
                    configuration.SetProperty(
                       NHibernate.Cfg.Environment.ConnectionString,
                       $@"Data Source={SQLITE_FILENAME}");
                    configuration.Configure(reader);

                    return configuration.BuildSessionFactory();
                }
            }

            #endregion Private Methods

            #region IDisposable Members

            private bool _disposed;

            public void Dispose()
            {
                // Check to see if Dispose has already been called.
                if (!_disposed)
                {
                    // Dispose the disposable objects.
                    _sessionFactory.Dispose();

                    // Disposing has been done.
                    _disposed = true;
                }

                GC.SuppressFinalize(this);
            }

            #endregion IDisposable Members
        }
    }
}