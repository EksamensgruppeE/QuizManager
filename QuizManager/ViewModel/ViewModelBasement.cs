using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Annotations;
using QuizManager.Model;

namespace QuizManager.ViewModel
{
    class ViewModelBasement : INotifyPropertyChanged
    {
        public ModelDateCollection DateCollection;

        #region INotifyPropertyChanged
        // By Mosbæk
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region ModelGroupProps
        //By Mosbæk

        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants { get; set; }

        public int TableNr { get; set; }

        public int NumberOfPayments { get; set; }

        #endregion

        #region ModelDateProps




        #endregion

        #region Empty Constructor
        public ViewModelBasement()
        {
            DateCollection.ModelDates.TotalSeats = 50;

        }
        #endregion

        #region Methods
        //add and remove by Rasmus

        public void AddSeat()
        {
            DateCollection.ModelDates.TotalSeats++;
            
        }

        public void RemoveSeat()
        {
            DateCollection.ModelDates.TotalSeats--;
        }

        
#endregion

    }
}
