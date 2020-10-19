using Assignment.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ShellVM:ViewModelBase, IShellVM
    {
        private readonly IRegionManager _regionManager;
       
        public ShellVM(IRegionManager regionManager)
        {
            _regionManager = regionManager;
           
        }

    }
}
