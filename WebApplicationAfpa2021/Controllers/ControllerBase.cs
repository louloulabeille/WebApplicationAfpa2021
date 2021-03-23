using DataContext;
using Microsoft.AspNetCore.Mvc;


namespace WebApplicationAfpa2021.Controllers
{
    //classe de base pour le controleur
    public abstract class ControllerBase : Controller
    {
        protected readonly DefaultContext _context = null;

        public ControllerBase( DefaultContext context )
        {
            _context = context;
        }
    }
}
