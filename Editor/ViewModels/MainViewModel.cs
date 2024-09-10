using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using SText.Dialogs;

namespace SText.Editor
{
    public class MainViewModel : ReactiveObject
    {

        public ReactiveCommand<Unit, Unit> About { get; }
        public ReactiveCommand<Unit,Unit> OpenFile { get; }


        private string content = "";
        public string Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MainViewModel()
        {
            About = ReactiveCommand.Create(
            () => {
                new AboutDialog("1.3.90").Show();
            });
        }



    }
}
