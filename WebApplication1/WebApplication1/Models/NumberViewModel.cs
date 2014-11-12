using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NumberViewModel
    {

        private SecretNumber _secretNumber;
        private  int _guess;

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
        public int ? Number
        {
            get { return _secretNumber.Number; }
            
        }
        public int Guess
        {
            get { return _guess; }
            set { _guess = value; }
        }
        public int ? LastGuessedNumber()
        {
            return  _secretNumber.LastGuessedNumber.Number;
        }

    }
}