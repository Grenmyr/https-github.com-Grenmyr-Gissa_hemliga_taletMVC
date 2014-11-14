using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Irules;

namespace WebApplication1.Models.Rules
{
    public class Professional : IRules
    {
        public int MaxNumberOfGuesses() { return 5; }
    }
}