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
        private NumberViewModel _numberViewModel;
     

        public GuessController()
        {
            _numberViewModel = new NumberViewModel();
        }
        public SecretNumber SecretNumberSession { get 
        {
            return Session["secretNumber"] as SecretNumber ?? (SecretNumber)(Session["secretNumber"] = new SecretNumber());
        }
        }
        //
        // GET: /Guess/
        public ActionResult Index()
        {
            _numberViewModel.SetSecretNumber = SecretNumberSession;
            return View(_numberViewModel);
        }

        [HttpPost]
        public ActionResult Index( NumberViewModel number)
        {
            number.SetSecretNumber = SecretNumberSession;
            if (ModelState.IsValid)
            {
                try
                {
                    number.MakeGuess(number.Guess);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty,e.Message);
                }
                
            }
            return View(number);
        }
        
	}
}