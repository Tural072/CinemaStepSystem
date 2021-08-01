using CinemaStep.Extension;
using CinemaStep.View_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaStep.View
{
    /// <summary>
    /// Interaction logic for Bookings.xaml
    /// </summary>
    public partial class Bookings : Window
    {
        public Bookings()
        {
            InitializeComponent();
            DataContext = new BookingsViewModel(this);
            Helper.Bookings = this;
        }

       
        public class Ticker : INotifyPropertyChanged
        {
            public Ticker()
            {
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.Interval = 1000; // 1 second updates
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }
            public DateTime Now
            {
                get { return DateTime.Now; }
            }

            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Now"));
            }

            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
