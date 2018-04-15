using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nozama2.Data;
using Nozama2.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Specialized;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Nozama2.Controllers
{
    public class ClientsController : Controller
    {
        private readonly Context _context;
        /*    private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> _userManager;
            private readonly SignInManager<IdentityUser> _signInManager; */
        public bool jason;
        public string mdp;
        public string username;
        public ClientsController(Context context)
        {
          /*  _userManager = userManager;
            _signInManager = signInManager; */
            _context = context;
        }

        // GET: Clients
       // [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }
        
        [HttpPost("sign-in")]
        public async Task<IActionResult> Connexion(object sender, EventArgs e, string pseud, string pswd, [Bind("Pseudo,Password")] Client client)
        {
            
           // return Content(); 
           var iencli = await _context.Clients
                                .SingleOrDefaultAsync(m => m.Pseudo == pseud);
            var motdepasse = await _context.Clients
                                .SingleOrDefaultAsync(m => m.Password == pswd);
            if(iencli != null)
            {
                if (iencli.Password == pswd)
                {
                    jason = true;
                    username = iencli.Pseudo;
                    mdp = iencli.Password;
                    return RedirectToAction("Register", "AccountController", new { variable1 = username, variable2 = mdp/*...etc*/});
                    // A TESTER URGENT var result = await _signInManager.PasswordSignInAsync(iencli.Pseudo, iencli.Password, false, false);
                    //    FormsAuthentication.SetAuthCookie(pseud.ToString(), false);
                    ViewBag.Message = "Connecté !"; 
                        return View(client);
                    
                }
                return View(await _context.Clients.ToListAsync());

            }
            else
            {
                return View(await _context.Clients.ToListAsync());
            }
            /*
            foreach (Client c in _context.Clients)
            {
                if (pseud == c.Pseudo )
                {
                    if (pswd == c.Password)
                    {
                     
            ViewBag.Message = "Connecté !";
                        return View(client);
                    }
                    ViewBag.Message = "Mot de passe wtf";

                    return View(await _context.Clients.ToListAsync());

                }

                else
                {
                    ViewBag.Message = "Non Connecté.";

                    return View(await _context.Clients.ToListAsync());
                } */
        }

        
        


        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pseudo,Password,Mail,Phone,Adress,Businessman,Id")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pseudo,Password,Mail,Phone,Adress,Businessman,Id")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .SingleOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(m => m.Id == id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
