using System;
using System.Threading;

namespace Bb
{



    public static class LockExtensions
    {

        /// <summary>
        /// Locks the ReaderWriterLockSlim object for read access.
        /// </summary>
        /// <param name="locker">The ReaderWriterLockSlim object to lock.</param>
        /// <param name="finallyBlock">An optional action to be executed after the lock is released.</param>
        /// <returns>An IDisposable object that represents the read lock.</returns>
        /// <remarks>
        /// This method acquires a read lock on the ReaderWriterLockSlim object, allowing multiple threads to read the protected resource simultaneously.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the locker parameter is null.</exception>
        public static IDisposable LockForRead(this ReaderWriterLockSlim locker, Action finallyBlock = null)
        {
            var result = new UpgradeableReadLockDisposable(UpgradeableReadLockDisposable.Mode.Read, locker, finallyBlock);
            locker.EnterReadLock();
            return result;
        }

        /// <summary>
        /// Locks the ReaderWriterLockSlim object for write access.
        /// </summary>
        /// <param name="locker">The ReaderWriterLockSlim object to lock.</param>
        /// <param name="finallyBlock">An optional action to be executed after the lock is released.</param>
        /// <returns>An IDisposable object that represents the write lock.</returns>
        /// <remarks>
        /// This method acquires a write lock on the ReaderWriterLockSlim object, allowing exclusive write access to the protected resource.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the locker parameter is null.</exception>
        public static IDisposable LockForWrite(this ReaderWriterLockSlim locker, Action finallyBlock = null)
        {
            var result = new UpgradeableReadLockDisposable(UpgradeableReadLockDisposable.Mode.Write, locker, finallyBlock);
            locker.EnterWriteLock();
            return result;
        }

        /// <summary>
        /// Locks the ReaderWriterLockSlim object for upgradeable read access.
        /// </summary>
        /// <param name="locker">The ReaderWriterLockSlim object to lock.</param>
        /// <param name="finallyBlock">An optional action to be executed after the lock is released.</param>
        /// <returns>An IDisposable object that represents the upgradeable read lock.</returns>
        /// <remarks>
        /// This method acquires an upgradeable read lock on the ReaderWriterLockSlim object, allowing multiple threads to read the protected resource simultaneously or a single thread to upgrade to a write lock.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the locker parameter is null.</exception>
        public static IDisposable LockForUpgradeableRead(this ReaderWriterLockSlim locker, Action finallyBlock = null)
        {
            var result = new UpgradeableReadLockDisposable(UpgradeableReadLockDisposable.Mode.UpgradeableRead, locker, finallyBlock);
            locker.EnterUpgradeableReadLock();
            return result;
        }


        private struct UpgradeableReadLockDisposable : IDisposable
        {

            public UpgradeableReadLockDisposable(Mode mode, ReaderWriterLockSlim locker, Action finallyBlock)
            {
                this._mode = mode;
                this._locker = locker;
                this._finally = finallyBlock;
            }

            public void Dispose()
            {

                switch (this._mode)
                {

                    case Mode.Read:
                        _locker.ExitReadLock();
                        break;

                    case Mode.Write:
                        _locker.ExitWriteLock();
                        break;

                    case Mode.UpgradeableRead:
                        _locker.ExitUpgradeableReadLock();
                        break;

                    default:
                        break;

                }

                _finally?.Invoke();

            }

            private readonly Mode _mode;
            private ReaderWriterLockSlim _locker;
            private Action _finally;


            public enum Mode
            {
                Read,
                Write,
                UpgradeableRead,
            }

        }

    }

}
