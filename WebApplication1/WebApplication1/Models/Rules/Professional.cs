using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Irules;

namespace WebApplication1.Models.Rules
{
    public class Professional : IRules
    {
        private int _maxNumberOfGuesses = 5;
        public int MaxNumberOfGuesses() { return _maxNumberOfGuesses; }
    }
}