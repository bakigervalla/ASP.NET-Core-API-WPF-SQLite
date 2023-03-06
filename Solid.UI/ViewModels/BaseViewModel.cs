using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.UI.ViewModels
{
    public class BaseViewModel: Conductor<object>, IScreen, INotifyPropertyChanged
    {
    }
}
