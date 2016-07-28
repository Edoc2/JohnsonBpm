using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Infrastructure.UnitOfWork
{
    public interface IActiveUnitOfWork
    {
        event EventHandler Completed;

        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        event EventHandler Disposed;

        UnitOfWorkOptions Options { get; }

        bool IsDisposed { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
