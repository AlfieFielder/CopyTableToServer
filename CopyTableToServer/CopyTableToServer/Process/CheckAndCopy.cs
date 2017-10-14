using System;
using CopyTableToServer.Data;

namespace CopyTableToServer.Process
    public class CheckAndCopyData : IDisposable
{
    #region local variables

    private BS4DataAccessor _liveData;
    private BS4DataAccessor _trainingData;
    private bool _disposed;

    #endregion

    #region Constructor

    public CheckAndCopyData()
    {
        _liveData = new BS4DataAccessor(true);
        _trainingData = new BS4DataAccessor(false);
    }

    #endregion

    #region public methods

    public void CopyData()
    {
        foreach (var user in _liveData.GetLiveUsers())
        {
            var testUser = _trainingData.GetUser(user.Lnk_User);
            if (testUser == null)
            {
                Console.WriteLine("Create User: {0}", user.User_FullName);
                var newUser = new User();
                newUser.UpdateFrom(user);
                _trainingData.SaveUser(newUser);
            }
            else if (!user.Equals(testUser))
            {
                Console.WriteLine("User Different: {0}", user.User_FullName);
                testUser.UpdateFrom(user);
            }

            var liveEntity = _liveData.GetEntity(user.Lnk_Entity);
            if (liveEntity == null)
                Console.WriteLine("Live Entity Not Found: {0}", user.User_FullName);
            else
            {
                var testEntity = _trainingData.GetEntity(user.Lnk_Entity);
                if (!liveEntity.Equals(testEntity))
                {
                    Console.WriteLine("Entity Different {0}", user.User_FullName);
                    if (testEntity == null)
                    {
                        var newEntity = new Entity();
                        newEntity.UpdateFrom(liveEntity);
                        _trainingData.SaveEntity(newEntity);
                    }
                    else
                        testEntity.UpdateFrom(liveEntity);
                }
            }
        }
        _trainingData.SaveChanges();
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
            if (_liveData != null)
                _liveData.Dispose();
            if (_trainingData != null)
                _trainingData.Dispose();
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