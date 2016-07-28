using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        void Complete();

        Task CompleteAsync();
    }
}
