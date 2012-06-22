using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShivasTower.Model.Objects
{
    class Fight
    {
        public string Outcome
        {
            get;
            private set;
        }

        public string OutcomeSuccess
        {
            get;
            private set;
        }

        public string OutcomeFail
        {
            get; 
            private set;
        }

        public Fight(string strOutcome, string strOutcomeSuccess, string strOutcomeFail)
        {
            Outcome = strOutcome;
            OutcomeSuccess = strOutcomeSuccess;
            OutcomeFail = strOutcomeFail;
        }
    }
}