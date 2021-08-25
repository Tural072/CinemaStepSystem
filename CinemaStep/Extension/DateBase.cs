using CinemaStep.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.Extension
{
    public class DateBase
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();
    }
}
