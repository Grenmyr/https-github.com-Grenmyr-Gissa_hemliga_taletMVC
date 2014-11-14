using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    // Enum Used by SetGame.cshtml and GuessController to initialize different game difficulties.
    public enum GameSetting { normal, hard, professional }
    public class NumberViewModel
    {
      
        private SecretNumber _secretNumber;
        private int _maxNumberOfGuesses;

        /// <summary>
        /// After eatch post this class get new Secretnumber instance
        /// this Property is set from GuessController.
        /// </summary>
        public SecretNumber SecretNumberGameSettings 
        { 
            set 
            {
                _secretNumber = value; 
                MaxNumberOfGuesses = _secretNumber.MaxNumberOfGuesses; 
            } 
        }
        public int GuessCount() 
        {
            return _secretNumber.Count;
        }
        /// <summary>
        /// Set and Get Amount of guesses from SecretnumberSession
        /// </summary>
        public int MaxNumberOfGuesses 
        { 
            get 
            {
                return _maxNumberOfGuesses;
            }
            set 
            { 
                _maxNumberOfGuesses = value; 
            }
        }

        public IList<GuessedNumber> GuessedNumbers
        {
            get
            {     
                return  _secretNumber.GuessedNumbers;            
            }
        }
        
        /// <summary>
        /// Present Index.cshtml guess for Secretnumber.MakeGuess and get outcome back.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns>Outcome</returns>
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

        // Present outcome from last number in form of a string.
        public string LastGuessedNumber()
        {
            if(_secretNumber.LastGuessedNumber.Outcome == Outcome.Right)
            {
                return String.Format("woa DU VANN, hemliga talet var {0}, Starta om spel i header.", Number);
            }
            else if (Number != null) 
            {
                return String.Format("Spelet är över du förlorade! Hemliga talet var {0}. Försök igen genom starta om i header.", Number); 
            }
            else if (_secretNumber.LastGuessedNumber.Outcome == Outcome.OldGuess) 
            { 
                return "Gammal gissning, gissningen registrerades ej"; 
            }
            else if (_secretNumber.LastGuessedNumber.Number.HasValue  ) 
            { 
                return String.Format("Senaste Gissning var {0}", _secretNumber.LastGuessedNumber.Number); 
            }
            else { return "Skriv in giltig gissning för börja spelet"; }
        }
      

        [Required (ErrorMessage="Fyll i värde")]
        [Range(1,100,ErrorMessage="Endast heltal gissningar mellan 1-100 är giltiga.")]
        public int Guess { get; set; }

        /// <summary>
        /// Dictionary, for present list of historical guesses in index.cshtml
        /// </summary>
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

        /// <summary>
        /// SelectList for SetGame.cshtml to present difficult choises in a dropdown list.
        /// </summary>
        /// <returns>Dictionary<GameSetting, string></returns>
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
