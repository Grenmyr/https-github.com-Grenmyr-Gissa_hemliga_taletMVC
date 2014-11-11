using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NumberViewModel
    {

        private SecretNumber _secretNumber;

        public NumberViewModel()
        {
            _secretNumber = new SecretNumber();
        }
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

        public int ? LastGuessedNumber()
        {
            return  _secretNumber.LastGuessedNumber.Number;
        }

    }
}