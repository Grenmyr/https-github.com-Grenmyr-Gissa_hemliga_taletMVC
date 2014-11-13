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
                return  _secretNumber.GuessedNumbers;            
            }
        }
        
        public Outcome MakeGuess(int guess)
        {
            return _secretNumber.MakeGuess(guess);
        }

        public int? Number
        {

            get
            {
                return _secretNumber.Number;
            }
         
        }  
        public string LastGuessedNumber()
        {
            if (Number != null) { return String.Format("Spelet är över, Hemliga talet var {0}",Number); }
            else if (_secretNumber.LastGuessedNumber.Outcome == Outcome.OldGuess) { return "Gammal gissning, gissningen registrerades ej"; }
            else if (_secretNumber.LastGuessedNumber.Number.HasValue  ) { return String.Format("Senaste Gissning var {0}", _secretNumber.LastGuessedNumber.Number); }
            else { return "Skriv in giltig gissning för börja spelet"; }
        }
      
        [Required (ErrorMessage="Fyll i värde")]
        [Range(1,100,ErrorMessage="Endast heltal gissningar mellan 1-100 är giltiga.")]
        public int Guess { get; set; }

        public IReadOnlyDictionary<Outcome,string> Result 
        {
            get
            {
                var result = new Dictionary<Outcome, string>
                {
                    {Outcome.Low , "Din gissning var för låg."},
                    {Outcome.High , "Din gissning var för hög."},
                    {Outcome.Right , "Grattis Rätt Talet var"}
                };
                return result;
            }
        }
    }
}