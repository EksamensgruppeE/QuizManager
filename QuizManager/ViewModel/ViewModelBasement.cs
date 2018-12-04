using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        public ObservableCollection<ModelDateCollection> DateCollection { get; set; }

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

        public ModelDate SelectedItem { get; set; }


        #endregion

        #region Empty Constructor

        public ViewModelBasement()
        {
           DateCollection = new ObservableCollection<ModelDateCollection>();
           DateCollection.Add(new ModelDateCollection());
        }
        #endregion

        #region Methods
        //add and remove by Rasmus

        public void AddSeat()
        {
            //skal ha fat i TotalSeats i ModelDate
            SelectedItem.TotalSeats++;
        }

        public void SubtractSeat()
        {
            //skal ha fat i TotalSeats i ModelDate
            SelectedItem.TotalSeats--;
        }

        
#endregion

    }
}
