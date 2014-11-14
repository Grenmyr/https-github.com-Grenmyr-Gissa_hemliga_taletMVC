using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Irules;

namespace WebApplication1.Controllers
{
    public class GuessController : Controller
    {
        private NumberViewModel _numberViewModel;
        private IRules _difficulty = new Hard();
        public GuessController()
        {
            _numberViewModel = new NumberViewModel(); 
        }
        /* TODO: Try initilise game with rule.
        public GuessController(IRules difficulty)
        {

            _difficulty = difficulty;
            _numberViewModel = new NumberViewModel(); 
        }*/
        public SecretNumber SecretNumberSession { get 
        {
          
            Session.Timeout = 1;
            return Session["secretNumber"] as SecretNumber ?? (SecretNumber)(Session["secretNumber"] = new SecretNumber(_difficulty));
        }
        }
     
    
        public ActionResult startover()
        {
            
            SecretNumberSession.Initialize();


            return RedirectToAction("Index");
        }
        //
        // GET: /Guess/
        public ActionResult Index()
        {
            _numberViewModel.SecretNumberGameSettings = SecretNumberSession;           
            return View(_numberViewModel);
        }

        [HttpPost]
        public ActionResult Index( NumberViewModel number)
        {
            if (Session.IsNewSession) 
            {
                ModelState.AddModelError("sessionerror", "SESSIONFEL Spelet startades om");
            }
            number.SecretNumberGameSettings = SecretNumberSession;
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