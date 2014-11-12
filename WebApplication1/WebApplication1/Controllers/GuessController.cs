using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GuessController : Controller
    {
     

        public GuessController()
        {
        
        }
        public NumberViewModel NumberViewModel { get 
        {
           return  Session["secretNumber"] as NumberViewModel ?? (NumberViewModel)(Session["secretNumber"] = new NumberViewModel());
        }
        }
        //
        // GET: /Guess/
        public ActionResult Index()
        {

            return View(NumberViewModel);
        }
        [HttpPost]
        public ActionResult Index(NumberViewModel guess)
        {

            
            NumberViewModel.MakeGuess(guess.Guess);
            return View(NumberViewModel);
        }
        
	}
}