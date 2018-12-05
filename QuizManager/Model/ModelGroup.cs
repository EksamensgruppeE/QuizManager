using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuizManager.Annotations;

namespace QuizManager.Model
{
    class ModelGroup : INotifyPropertyChanged
    {
        private bool _allPaid;
        private int _participants;
        private int _numberOfPayments;
        private int _numberOfAttendingParticipants;
        private bool _allAttending;


        #region Properties
        //Oplysninger omkring holdet som er tilmeldt.
        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants
        {
            get
            { return _participants; }
            set
            {
                _participants = value;
                OnPropertyChanged();
            }
        }

        public int TableNr { get; set; }

        public int NumberOfPayments
        {
            get { return _numberOfPayments; }
            set
            {
                _numberOfPayments = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfAttendingParticipants
        {
            get { return _numberOfAttendingParticipants; }
            set
            {
                _numberOfAttendingParticipants = value;
                OnPropertyChanged();
            }
        }

        public bool AllPaid
        {
            get
            {
                if (Participants == NumberOfPayments) _allPaid = true;
                else _allPaid = false;
                return _allPaid;
            }
            set { _allPaid = value; }
        }

        public bool AllAttending
        {
            get
            {
                if (NumberOfAttendingParticipants == Participants) _allAttending = true;
                else _allAttending = false;
                return _allAttending;
            }
        }

        #endregion

        #region Constructor
        // By Mosbæk
        public ModelGroup(string teamName, string phoneNumber, int participants, int tableNr)
        {
            TeamName = teamName;
            PhoneNumber = phoneNumber;
            _participants = participants;
            TableNr = tableNr;
            _numberOfPayments = 0;
        }

        #endregion

        #region Methods

        public void AddOneParticipant()
        {
            Participants++;
        }

        public void RemoveOneParticipant()
        {
            if (Participants > 0) Participants--;
        }

        public void AddOnePayment()
        {
            NumberOfPayments++;
        }

        public void RemoveOnePayment()
        {
            if (NumberOfPayments > 0) NumberOfPayments--;
        }

        public void AddOneAttending()
        {
            NumberOfAttendingParticipants++;
        }

        public void RemoveOneAttending()
        {
            if (NumberOfAttendingParticipants > 0) NumberOfAttendingParticipants--;
        }

        #endregion


        #region InotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
