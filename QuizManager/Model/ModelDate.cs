using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using QuizManager.Annotations;

namespace QuizManager.Model
{
    class ModelDate : INotifyPropertyChanged
    {

        #region Instance Fields
        
        private int _totalSeats;

        #endregion


        #region Properties

        //Undersøges for relevant datatype
        public string Date { get; set; }

        public string EventType { get; set; }

        //Collection af grupper
        public ObservableCollection<ModelGroup> Groups { get; set; }

        //Deltagere i alt
        public int TotalParticipants { get; set; }

        //antal stole i alt.
        public int TotalSeats
        {
            get => _totalSeats;
            set
            {
                _totalSeats = value; 
                OnPropertyChanged();
            }
        }

        //betaling i alt.
        public int TotalPayments { get; set; }


        #region Statistik

        //Dagens Omsætning
        public double TotalRevenue { get; set; }
        
        //Omsætningen i tidsrummet 20-24
        public double Revenue20To24 { get; set; }

        //Omsætningen i tidsrummet 24-lukketid
        public double Revenue24ToClose { get; set; }

        //Totale omsætning af deltagelsesgebyr og salg til deltagere
        public double TotalRevenueQuiz { get; set; }

        //Totale omsætning af quizdeltagelsesgebyr
        public double TotalRevenueQuizParticipants { get; set; }

        //Totale omsætning af varer solgt med rabat til quiz deltagere
        public double RevenueQuizOffers { get; set; }

        #endregion


#endregion
        

        #region Constructor

        //denne constructor initialisere properties med det input den nu får, 
        //samt opretter en observable collection af ModelGroups.

        //skal måske erstattes af nedenstående constructor

        public ModelDate(string date, string eventType, int totalParticipants, int totalSeats, int totalPayments, double totalRevenue, double revenue20To24, double revenue24ToClose, double totalRevenueQuiz, double totalRevenueQuizParticipants, double revenueQuizOffers)

        {
            Date = date;
            EventType = eventType;
            Groups = new ObservableCollection<ModelGroup>();
            TotalParticipants = totalParticipants;
            TotalSeats = totalSeats;
            TotalPayments = totalPayments;
            TotalRevenue = totalRevenue;
            Revenue20To24 = revenue20To24;
            Revenue24ToClose = revenue24ToClose;
            TotalRevenueQuiz = totalRevenueQuiz;
            TotalRevenueQuizParticipants = totalRevenueQuizParticipants;
            RevenueQuizOffers = revenueQuizOffers;
        }

        
        //Er det ikke bedre at have en lidt mere simpel constructor, som nedenstående? - Laura
        public ModelDate(string date, string eventType, int totalSeats)
        {
            Date = date;
            EventType = eventType;
            Groups = new ObservableCollection<ModelGroup>();
            TotalSeats = totalSeats;
        }

        #endregion


        #region Methods

        //metode der gennemløber Groups Collectionen for det specificerede teamName.
        public ModelGroup GetGroup(string teamName)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (teamName == Groups[i].TeamName)
                {
                    return Groups[i];
                }
            }

            return null;
        }

        //står også i ViewModelBasement. Skal den slettes?
        public void AddTest()
        {
            Groups.Add(new ModelGroup("Russerne", "10203040", 7, 1));
            Groups.Add(new ModelGroup("StupidTeamName", "20304050", 3, 1));
            Groups.Add(new ModelGroup("Gede Hviskerne", "30405060", 12, 3));
        }

        #endregion


        #region INotifyPropertyChanged
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
