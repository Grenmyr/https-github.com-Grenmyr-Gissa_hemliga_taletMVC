using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }

    public struct GuessedNumber
    {
        public int? Number;
        //Funkar det?
        //Eller?
        public Outcome Outcome;

    }

}