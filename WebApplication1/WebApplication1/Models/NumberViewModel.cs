using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NumberViewModel
    {

        private SecretNumber _secretNumber;
       //private IList<GuessedNumber> _guessedNumbers;


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
        
        public void MakeGuess(int guess)
        {
            _secretNumber.MakeGuess(guess);
        }

        public int ? Number
        {
            get { return _secretNumber.Number; }
            
        }     
        public int ? LastGuessedNumber()
        {
            return  _secretNumber.LastGuessedNumber.Number;
        }

        public int Guess { get; set; }

    }
}