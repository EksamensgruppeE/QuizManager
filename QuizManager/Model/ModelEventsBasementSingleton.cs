﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.Model
{
    class ModelEventsBasementSingleton
    {
        #region Instancefields

        private static ModelEventsBasementSingleton _instance = null;
        private ObservableCollection<ModelDate> _dates;

        #endregion

        #region Properties

        //Collection af ModelDates

      
        //vores liste af datoer for Basement.
        public ObservableCollection<ModelDate> BasementDates
        {
            get { return _dates; }
            set { _dates = value; }
        }

        
        //property, hvis get metode kalder vores private constructor, gennem et if statement der sikrer at der kun skabes
        //1 instance af classen. 
        public static ModelEventsBasementSingleton Instance
        {
            get
            {
                if (_instance == null) _instance = new ModelEventsBasementSingleton();
                return _instance;

            }
        }

   

        #endregion

        #region Private Constructor

        //her skaber vi en observable Collection af ModelDate og tilføjer test objekter. 
        //da dette er en singleton kan dette kun ske 1 gang! #Genius 
        private ModelEventsBasementSingleton()
        {
            _dates = new ObservableCollection<ModelDate>();
            AddTest();
        }

        #endregion

        //metode der tilføjer datoer til Observable Collection
        public void AddDate(ModelDate date)
        {
            _dates.Add(date);
        }

        //metode der gennemgår observable Collectionen for et match med dens givne streng. 
        //findes den fjernes den fra listen. 
        public void RemoveDate(string date)
        {
            for (int i = 0; i < _dates.Count; i++)
            {
                if (date == _dates[i].Date) _dates.RemoveAt(i);
            }
        }


        public void AddTest()
        {
            _dates.Add(new ModelDate("21/11/18", "MusikQuiz", 52));
            _dates.Add(new ModelDate("23/11/18", "DisneyQuiz", 38));
            _dates.Add(new ModelDate("01/11/18", "Bingo", 55));
            BasementDates[0].AddGroup(new ModelGroup("Russerne", "10203040", 7, 1));
            BasementDates[0].AddGroup(new ModelGroup("StupidTeamName", "20304050", 3, 1));
            BasementDates[0].AddGroup(new ModelGroup("Gede Hviskerne", "30405060", 12, 3));
            BasementDates[1].AddGroup(new ModelGroup("TeamOne", "50607080", 5, 2));
            BasementDates[1].AddGroup(new ModelGroup("Fuck This", "60607080", 6, 4));
            BasementDates[1].AddGroup(new ModelGroup("Team Twio", "50607080", 8, 5));

            BasementDates[0].Revenue20To24 = 9500;
            BasementDates[0].Revenue24ToClose = 9800;
            BasementDates[0].RevenueQuizOffers = 5000;
            BasementDates[0].TotalRevenue = 5600;
            BasementDates[0].TotalRevenueQuizParticipants = 4500;
            BasementDates[0].TotalRevenueQuiz = 3500;

        }
    }
}
