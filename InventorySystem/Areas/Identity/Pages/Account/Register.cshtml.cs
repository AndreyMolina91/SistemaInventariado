using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using InventorySystem.DataAccess.Repositories.IRepositories;
using InventorySystem.Models;
using InventorySystem.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace InventorySystem.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        //Creamos un objeto de tipo rolemanager de identityrole para insertar este campo en la BD
        private readonly RoleManager<IdentityRole> _roleManager;

        //Creamos un objeto de tipo unidad de trabajo para el uso de sus funciones
        private readonly IWorkUnity _workUnity;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IWorkUnity workUnity)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            //Inicializamos nuestros objetos con el constructor
            _roleManager = roleManager;
            _workUnity = workUnity;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(15, MinimumLength = 4)]
            public string UserName { get; set; }

            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe tener minimo {2} y máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }


            //Copiamos las propiedades del modelo UsuarioApp
            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Apellidos { get; set; }

            public string Direccion { get; set; }

            public string Ciudad { get; set; }

            public string Pais { get; set; }

            public string Role { get; set; }

            //Lista para crear dropdown de roles
            public IEnumerable<SelectListItem> ListaRoles { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            //Inicializamos la lista roles creando un inputmodel
            Input = new InputModel()
            {
                //Creamos una lista de roles que contendra el text el cual será el nombre y el valor de selectlistitem excluyendo el de cliente
                ListaRoles = _roleManager.Roles.Where(x => x.Name != StaticProperties.RoleClient).Select(n => n.Name).Select(l => new SelectListItem
                {
                    Text = l,
                    Value = l
                })
            };


            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //Primeramete se recibe un usuario después de que el modelo ha sido validado
                //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email }; No usaremos identityuser para el registro de usuarios

                //Código propio para validar el registro de usuarios

                //Declaramos una variable user donde crearemos el objeto con los datos recibidos por medio del input
                var user = new UsuarioApp
                {
                    //Hacemos referencia a nuestras variables y les asignamos los valores del input 
                    UserName = Input.UserName,
                    Email = Input.Email,
                    Nombre = Input.Nombre,
                    Apellidos = Input.Apellidos,
                    PhoneNumber = Input.PhoneNumber,
                    Direccion = Input.Direccion,
                    Ciudad = Input.Ciudad,
                    Pais = Input.Pais,
                    Role = Input.Role
                    
                };             
                


                //Aqui pasamos el usuario con los datos y verifica si estan correctos
                var result = await _userManager.CreateAsync(user, Input.Password);
                
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //Despues de inicializar los objetos en el constructor creamos despues del metodo que verifica que el usuario este correcto
                    if(!await _roleManager.RoleExistsAsync(StaticProperties.RoleAdmin))//Instalamos la referencia a utilidades para usar la clase staticproperties
                    {
                        //Si es diferente a que existe el roll de administrador en la base de datos es decir sino existe, procedemos a crear el roll
                        await _roleManager.CreateAsync(new IdentityRole(StaticProperties.RoleAdmin));
                    }
                    if(!await _roleManager.RoleExistsAsync(StaticProperties.RoleWorker))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(StaticProperties.RoleWorker));
                    }
                    if(!await _roleManager.RoleExistsAsync(StaticProperties.RoleClient))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(StaticProperties.RoleClient));
                    }
                    if (!await _roleManager.RoleExistsAsync(StaticProperties.RoleSales))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(StaticProperties.RoleSales));
                    }
                    //El anterior proceso ASP lo realiza una sola vez, en caso de no estar creados el no los vuelve a crear.

                    //========================================================================================================//

                    //Ahora vamos a StartUp a cambiar el addDefaultIdentity por addIdentity para que soporte roles...==>

                    //Después de configurado el StartUp con identity + emailsender creamos un usuario por default con roll admin con el sgt codigo
                    //Una vez creados nuestros rolles y nuestra cuenta de usuario podemos eliminar este codigo
                    //await _userManager.AddToRoleAsync(user, StaticProperties.RoleAdmin);



                    //Si el roll del usuario es = a null quiere decir que se trata de un cliente que se esta registrando
                    if(user.Role == null)
                    {
                        await _userManager.AddToRoleAsync(user, StaticProperties.RoleClient);
                    }
                    //De lo contrario es admin, si es admin desde la vista enviará el roll al cual pertenecera este nuevo usuario
                    else
                    {
                        await _userManager.AddToRoleAsync(user, user.Role);
                    } //una vez se crea el usuario se hace el redirect a las vistas...





                    //Código que gestiona el envio de email

                    //variable del tipo usuario que creará el objeto Json a enviar por correo

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirma tu Email",
                        $"confirma tu cuenta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Haz click aqui</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        //si es un cliente
                        if(user.Role == null)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            //administrador esta registrando un nuevo usuario redireccion a home
                            return RedirectToAction("Index", "User", new {Area = "Admin"});
                        }
                        
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
