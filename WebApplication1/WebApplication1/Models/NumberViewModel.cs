using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public enum GameSetting { normal, hard, professional }
    public class NumberViewModel
    {
      
        private SecretNumber _secretNumber;
        private int _maxNumberOfGuesses;

        public SecretNumber SecretNumberGameSettings { set { _secretNumber = value; MaxNumberOfGuesses = _secretNumber.MaxNumberOfGuesses; } }
        public int GuessCount() 
        {
            return _secretNumber.Count;
        }
        public int MaxNumberOfGuesses 
        { 
            get 
            {
                return _maxNumberOfGuesses;
            }
            set { _maxNumberOfGuesses = value; }
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
                    //{Outcome.OldGuess , "Gammal gissning, gissningen registrerades ej"},
                    {Outcome.Low , "Din gissning var för låg."},
                    {Outcome.High , "Din gissning var för hög."},
                    {Outcome.Right , "Grattis Rätt Talet var"}
                };
                return result;
            }
        }
        public SelectList GameDifficulty
        {
            get
            {
                var list = new Dictionary<GameSetting, string>
                {
                     {  GameSetting.normal, "Normal 7 gissningar." },
                     {  GameSetting.hard, "Svår 6 gissningar." },
                     {  GameSetting.professional, "Omöjlig 5 gissningar." },
                };

                return new SelectList(list, "key", "value");
            }
        }
        
    }
}
