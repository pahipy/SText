using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using SText.Dialogs;

namespace SText.Editor
{
    public class MainViewModel
    {

        public ReactiveCommand<Unit, Unit> About { get; }
        public ReactiveCommand<Unit,Unit> OpenFile { get; }

        public MainViewModel()
        {
            About = ReactiveCommand.Create(
            () => {
                new AboutDialog("1.3.90").Show();
            });
        }

        
        

    }
}
