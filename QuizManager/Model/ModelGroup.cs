using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizManager.Model
{
    class ModelGroup
    {

        #region Properties
        //Oplysninger omkring holdet som er tilmeldt.
        public string TeamName { get; set; }

        public string PhoneNumber { get; set; }

        public int Participants { get; set; }

        public int TableNr { get; set; }

        public int NumberOfPayments { get; set; }

        #endregion

        #region Constructor
        // By Mosbæk
        public ModelGroup(string teamName, string phoneNumber, int participants, int tableNr, int numberOfPayments)
        {
            TeamName = teamName;
            PhoneNumber = phoneNumber;
            Participants = participants;
            TableNr = tableNr;
            NumberOfPayments = numberOfPayments;
        }

        #endregion
        













    }
}
