using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrameWork.Framework.Infrastructure.Domain;
using FrameWork.Framework.Infrastructure.Repository;


namespace Demo.Domain.ProcessName
{
    public class ProcessNameManager : DomainService,IProcessNameManager
    {
        private readonly IRepository<sy_menu> _sy_menuRepository;

        public ProcessNameManager(IRepository<sy_menu> sy_menuRepository)
        {
            this._sy_menuRepository = sy_menuRepository;
        }
        public List<sy_menu> GetMenuList()
        {
            return _sy_menuRepository.GetAllList();
        }
    }
}
