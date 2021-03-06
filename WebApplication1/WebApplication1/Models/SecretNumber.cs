﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Irules;

namespace WebApplication1.Models
{
    public class SecretNumber
    {

        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;

        private int? _number;

        private int _maxNumberOfGuesses;

        public SecretNumber(IRules rules)
        {
            _maxNumberOfGuesses = rules.MaxNumberOfGuesses();
            _guessedNumbers = new List<GuessedNumber>(_maxNumberOfGuesses);
            Initialize();
        }

        public int MaxNumberOfGuesses { get { return _maxNumberOfGuesses; } }

        public bool CanMakeGuess
        {
            get
            {
                return Count < _maxNumberOfGuesses && (!GuessedNumbers.Any(guess => guess.Outcome == Outcome.Right));
            }
        }
        public int Count
        {
            get
            {
                return GuessedNumbers.Count();
            }
        }

        public IEnumerable<GuessedNumber> GuessedNumbers
        {
            get
            {
                return _guessedNumbers.AsReadOnly();
            }

        }

        public GuessedNumber LastGuessedNumber
        {
            get
            {
                return _lastGuessedNumber;
            }
        }
        
        public int? Number
        {
            get
            {
                if (CanMakeGuess) { return null; }
                return _number;
            }
            private set
            {
                if (value < 1 && value > 100) { throw new ArgumentOutOfRangeException(); }
                _number = value;
            }
        }

        public void Initialize()
        {
            
            _guessedNumbers.Clear();
            var random = new Random();
            Number = random.Next(1, 101);
            _lastGuessedNumber.Number = null;
            _lastGuessedNumber.Outcome = Outcome.Indefinite;

        }
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 | guess > 100) { throw new ArgumentOutOfRangeException(); }
            if (!CanMakeGuess) {
                _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
                return Outcome.NoMoreGuesses;
            }

            _lastGuessedNumber = new GuessedNumber();
            _lastGuessedNumber.Number = guess;


            if (GuessedNumbers.Any(val => val.Number == guess)) { _lastGuessedNumber.Outcome = Outcome.OldGuess; }
            else
            {
                if (guess > _number) { _lastGuessedNumber.Outcome = Outcome.High; }
                else if (guess < _number) { _lastGuessedNumber.Outcome = Outcome.Low; }
                else if (guess == _number) { _lastGuessedNumber.Outcome = Outcome.Right; }
                _guessedNumbers.Add(_lastGuessedNumber);
            }        
            return _lastGuessedNumber.Outcome;
        }
    }
}