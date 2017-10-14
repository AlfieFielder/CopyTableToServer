using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyTableToServer.Data
{
    public class BS4DataAccessor : IDisposable
    {
        #region Constants

        private const string DotNetProvider = "System.Data.SqlClient";
        private const string ConceptualSchemaDefinition = "Data.BS4.csdl";
        private const string StoreSchemaDefinition = "Data.BS4.ssdl";
        private const string MappingSpecification = "Data.BS4.msl";

        #endregion

        #region Local variables

        private BS4Entities _provider;
        private bool _disposed;
        private bool _readOnly;

        #endregion

        #region Properties


        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="training"></param>
        public BS4DataAccessor(bool training)
        {
            Initialise(training ? "Fiennes" : "Cook");
            _provider.CommandTimeout = 600;
            _readOnly = training;
        }

        /// <summary>
        /// Initialise the Provider
        /// </summary>
        private void Initialise(string server)
        {
            var providerStringBuilder = new SqlConnectionStringBuilder
            {
                IntegratedSecurity = true,
                MultipleActiveResultSets = true,
                InitialCatalog = "Albatross",
                DataSource = server
            };

            var entityStringBuilder = new EntityConnectionStringBuilder
            {
                Provider = DotNetProvider,
                ProviderConnectionString = providerStringBuilder.ToString(),
                Metadata = String.Format("{0}{1}|{0}{2}|{0}{3}", "res://*/", ConceptualSchemaDefinition, StoreSchemaDefinition, MappingSpecification)
            };

            var connectionString = entityStringBuilder.ToString();
            _provider = new BS4Entities(connectionString);
        }

        #endregion

        #region public methods

        public List<User> GetLiveUsers()
        {
            return (from u in _provider.Users
                    join e in _provider.Entities on u.Lnk_Entity equals e.Lnk_Entity
                    where e.Delete_Flag
                    orderby u.User_Name
                    select u).ToList();
        }

        public User GetUser(string lnkUser)
        {
            return (from u in _provider.Users
                    where u.Lnk_User == lnkUser
                    select u).FirstOrDefault();
        }

        public Entity GetEntity(string lnkEntity)
        {
            return (from e in _provider.Entities
                    where e.Lnk_Entity == lnkEntity
                    select e).FirstOrDefault();
        }

        public void SaveEntity(Entity entity)
        {
            _provider.Entities.AddObject(entity);
        }

        public void SaveUser(User user)
        {
            _provider.Users.AddObject(user);
        }

        public void SaveChanges()
        {
            if (_readOnly)
                throw new ArgumentException("Database is read-only");
            _provider.SaveChanges();
        }

        #endregion

        #region ProtectedMethods

        /// <summary>
        /// Free the resources of the class and alter which fields get disposed.
        /// </summary>
        /// <param name="disposing">Whether to dispose managed objects as well as native ones.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                if (_provider != null)
                {
                    _provider.Dispose();
                }
            }
            _disposed = true;
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
