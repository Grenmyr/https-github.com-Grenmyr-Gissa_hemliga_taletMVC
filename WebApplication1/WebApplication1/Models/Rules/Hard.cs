using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Irules
{
    public class Hard : IRules
    {
        private int _maxNumberOfGuesses = 6;
        public int MaxNumberOfGuesses() { return _maxNumberOfGuesses; }
    }
}