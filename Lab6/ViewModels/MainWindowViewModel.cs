using Lab6.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Lab 6";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
