using LMS.Business.Interface;
using LMS.Domain.Entities;
using LMS.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Security.Principal;

namespace LMS.Web.Controllers
{
    [Route("[controller]/[action]")]
    [DisplayName("Access Management")]
    //[Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserComponent _userComponent;
        private readonly ApplicationDbContext _context;
        private readonly IPrincipal _principal;
        private IMediator _mediator;
        private readonly ILogger _logger;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMediator mediator
            , ILogger<AccountController> logger, ApplicationDbContext context, IPrincipal principal, IUserComponent userComponent)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _userComponent = userComponent;
            _principal = principal;
            _mediator = mediator;
        }



        public IActionResult Index()
        {
            return View();
        }
        

        
    }
}
