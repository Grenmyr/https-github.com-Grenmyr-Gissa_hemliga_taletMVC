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
        
        public GuessController()
        {
            _numberViewModel = new NumberViewModel(); 
        }
    
        public SecretNumber SecretNumberSession { get 
        {
          
            Session.Timeout = 1;
            return Session["secretNumber"] as SecretNumber ?? (SecretNumber)(Session["secretNumber"] = new SecretNumber(new Hard()));
        }
            set
            {
                Session["secretNumber"] = value;
            }
        }

        public ActionResult SetGame()
        {
            
            return View();
        }
        public ActionResult HardGame()
        {
            SecretNumberSession = new SecretNumber(new Hard());
            return RedirectToAction("Index");
        }
        public ActionResult NormalGame()
        {
            SecretNumberSession = new SecretNumber(new Normal());
            return RedirectToAction("Index");
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