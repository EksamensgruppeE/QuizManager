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
        //slettes
        public string trni { get; set; }

        #region INotifyPropertyChanged
        // By Mosbæk
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Instancefields

        private ObservableCollection<ModelGroup> _groups;
        private ModelGroup _selectedGroup;

        #endregion

        #region ModelGroupProps
        //By Mosbæk

        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants { get; set; }

        public int TableNr { get; set; }

        public int NumberOfPayments { get; set; }

        public string AllPayed { get; set; }

        public int NumberOfAttendingParticipants { get; set; }
        #endregion

        public string Date { get; set; }


        #region Properties

        public ModelGroup SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ModelDateCollection> DateCollection { get; set; }

        public ObservableCollection<ModelGroup> BasementGroups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        #endregion

        #region ModelDateProps

        public ModelDate SelectedItem { get; set; }


        #endregion

        #region Empty Constructor

        public ViewModelBasement()
        {

           DateCollection = new ObservableCollection<ModelDateCollection>();
           DateCollection.Add(new ModelDateCollection());

            _groups = new ObservableCollection<ModelGroup>();
            AddTest();
            _groups[0].AllPaid = true;

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

        public void AddTest()
        {
            _groups.Add(new ModelGroup("Russerne", "10203040", 7, 1));
            _groups.Add(new ModelGroup("StupidTeamName", "20304050", 3, 1));
            _groups.Add(new ModelGroup("Gede Hviskerne", "30405060", 12, 3));
        }

        #region Udkommenteret Kode

        //public void MakeGroupList(string date)
        //{
        //    if (_groups.Count < ModelEventsBasementSingleton.Instance.BasementModelDateCollection.GetDate(date).Groups
        //            .Count)
        //    {
        //        for (int i = 0;
        //            i < ModelEventsBasementSingleton.Instance.BasementModelDateCollection.GetDate(date).Groups
        //                .Count;
        //            i++)
        //        {
        //            Groups.Add(
        //                ModelEventsBasementSingleton.Instance.BasementModelDateCollection.GetDate(date).Groups[i]);
        //        }
        //    }
        //}

        #endregion

    }
}
