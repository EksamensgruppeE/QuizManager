using System;
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

        #endregion

        #region Properties

        //Collection af ModelDates
        public ModelDateCollection BasementModelDateCollection { get; set; }



        public static ModelEventsBasementSingleton Instance
        {
            get
            {
                if (_instance == null) _instance = new ModelEventsBasementSingleton();
                return _instance;

            }
        }

        #endregion

        #region Constructor

        private ModelEventsBasementSingleton()
        {
            BasementModelDateCollection = new ModelDateCollection();
        }

        #endregion
    }
}
