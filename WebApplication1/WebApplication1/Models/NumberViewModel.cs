using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NumberViewModel
    {

        private SecretNumber _secretNumber;

        public SecretNumber SetSecretNumber { set { _secretNumber = value; } }
        public int GuessCount() 
        {
            return _secretNumber.Count;
        }

        public IList<GuessedNumber> GuessedNumbers
        {
            get
            {
                return _secretNumber.GuessedNumbers;              
            }
        }
        
        public Outcome MakeGuess(int guess)
        {
            return _secretNumber.MakeGuess(guess);
        }

        public int ? Number
        {
            get { return _secretNumber.Number; }
            
        }     
        public int ? LastGuessedNumber()
        {
            return  _secretNumber.LastGuessedNumber.Number;
        }
        // ska denna snacka med en enum här i min vy och endast användas för bestämma utfall?
        public Outcome ? LastGuessedOutcome()
        {   
            var outcome = _secretNumber.LastGuessedNumber.Outcome;
            if (outcome == Outcome.OldGuess) { return outcome; }
            else if( outcome == Outcome.Right) { return outcome; }
            else { return null; }   
        }

        [Required (ErrorMessage="Fyll i värde")]
        public int Guess { get; set; }

    }
}