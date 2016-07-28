using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Framework.Infrastructure.UnitOfWork
{
    public class UnitOfWorkOptions
    {
        public bool? IsTransactional { get; set; }

        public TimeSpan? Timeout { get; set; }
    }
}
