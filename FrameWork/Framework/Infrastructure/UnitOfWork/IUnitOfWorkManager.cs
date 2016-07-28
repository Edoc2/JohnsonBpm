using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Infrastructure.UnitOfWork
{
    public interface IUnitOfWorkManager
    {
        IActiveUnitOfWork Current { get; }

        IUnitOfWorkCompleteHandle Begin();

        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
