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

        private IList<GuessedNumber> GuessedNumbers
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

        public GuessedNumber LastGuessedNumber()
        {
            return _secretNumber.LastGuessedNumber;
        }

    }
}