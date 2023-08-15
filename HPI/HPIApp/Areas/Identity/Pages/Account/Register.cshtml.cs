// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;
using System.Text.Encodings.Web;
using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;

namespace HPIApp.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            //[Required]
            //[EmailAddress]
            //[Display(Name = "Email")]
            //public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [MaxLength(12, ErrorMessage = "UserName cannot be greater than 12.")]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "Firstname")]
            [MaxLength(50, ErrorMessage = "First Name cannot be greater than 50.")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Lastname")]
            [MaxLength(50, ErrorMessage = "Last Name cannot be greater than 50.")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Birthday")]
            public DateTime Birthdate { get; set; }

            [Required]
            [Display(Name = "Mobile No.")]
            public string MobileNo { get; set; }

            [Required]
            [Display(Name = "Present Address")]
            [MaxLength(50, ErrorMessage = "Present Address cannot be greater than 50.")]
            public string PresentAddress { get; set; }

            [Required]
            [MaxLength(12, ErrorMessage = "City cannot be greater than 12.")]
            public string City { get; set; }

            [Required]
            [MaxLength(12, ErrorMessage = "Country cannot be greater than 12.")]
            public string Country { get; set; }

            [Display(Name = "Payment Reference No.")]
            [MaxLength(50)]
            public string PaymentRefNo { get; set; }

            [ValidateNever]
            [Display(Name = "Member Photo")]
            public string MemberPhotoUrl { get; set; }

            [Required]
            [Display(Name = "Registration Date")]
            public DateTime RegistrationDate { get; set; }

            [MaxLength(50, ErrorMessage = "Others cannot be greater than 50.")]
            public string? Others { get; set; }

            [Display(Name = "Gender")]
            public int GenderId { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> gender { get; set; }

            [Display(Name = "Religion")]
            public int ReligionId { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> religion { get; set; }

            [Display(Name = "Branch")]
            public int BranchId { get; set; }

            [ValidateNever]
            public IEnumerable<SelectListItem> branch { get; set; }

            [Display(Name = "Class")]
            public int ClassId { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> branchClass { get; set; }

            public string Role { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> roleList { get; set; }

            [Display(Name = "Payment Method")]
            public int PaymentMethodId { get; set; }
            [ValidateNever]
            public IEnumerable<SelectListItem> paymentMethod { get; set; }
            public string Status { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            await LoadSelectListItem("OnGetAsync");
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var memberImgFile = HttpContext.Request.Form.Files["memberImgFile"];
            var proofOfPaymentImgFile = HttpContext.Request.Form.Files["proofOfPaymentImgFile"];
            CustomImageValidation(memberImgFile, "Member Photo");
            CustomImageValidation(proofOfPaymentImgFile, "Proof of Payment");

            await LoadSelectListItem("OnPostAsync");

            if (ModelState.IsValid)
            {
                var user = CreateUser();

                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.GenderId = Input.GenderId;
                user.Birthdate = Input.Birthdate;
                user.MobileNo = Input.MobileNo;
                user.PresentAddress = Input.PresentAddress;
                user.City = Input.City;
                user.Country = Input.Country;
                user.RegistrationDate = DateTime.Now;
                user.ReligionId = Input.ReligionId;

                if (Input.Role is null || Input.Role.Equals(StaticDetails.ROLE_CUSTOMER))
                {
                    user.ClassId = Input.ClassId;
                    user.MemberPhotoUrl = UploadCustomerImage(user, memberImgFile);
                }
                else 
                    user.ClassId = Input.ClassId;

                await _userStore.SetUserNameAsync(user, Input.UserName, CancellationToken.None);
                //await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (Input.Role is null)
                    {
                        var branchClassFromDb = await _unitOfWork.Class.GetFirstOrDefaultAsync(x => x.Id == Input.ClassId && x.BranchId == Input.BranchId);

                        if (branchClassFromDb is null)
                            return NotFound();

                        await _unitOfWork.Class.DecrementCount(branchClassFromDb, 1);
                        await _unitOfWork.SaveAsync();

                        await UserTransaction(user, proofOfPaymentImgFile);
                        await _userManager.AddToRoleAsync(user, StaticDetails.ROLE_CUSTOMER);
                    }
                    else
                        await _userManager.AddToRoleAsync(user, Input.Role);

                    //var userId = await _userManager.GetUserIdAsync(user);
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                        if (User.IsInRole(StaticDetails.ROLE_ADMIN))
                            TempData["success"] = "New admin created successfully.";
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);

                            var currentUser = await _userManager.FindByNameAsync(Input.UserName);
                            var roles = await _userManager.GetRolesAsync(currentUser);

                            if (roles.FirstOrDefault().Equals(StaticDetails.ROLE_CUSTOMER))
                                returnUrl = $"{returnUrl}Customer/Dashboard";
                            else
                                returnUrl = $"{returnUrl}Admin/Dashboard";
                        }
                            
                        return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

        private async Task UserTransaction(ApplicationUser user, IFormFile proofOfPaymentImgFile)
        {
            Transaction transaction = new();
            transaction.PaymentRefNo = Input.PaymentRefNo;
            transaction.PaymentProofUrl = UploadCustomerImage(user, proofOfPaymentImgFile);
            transaction.TransactionType = StaticDetails.PAYMENTTYPE_REGISTRATION;
            transaction.PaymentMethodId = Input.PaymentMethodId;
            transaction.ApplicationUserId = user.Id;
            transaction.TransactionDate = DateTime.Now;
            transaction.Status = StaticDetails.USERSTATUS_PENDING;
            await _unitOfWork.Transaction.AddAsync(transaction);
            await _unitOfWork.SaveAsync();
        }

        private string UploadCustomerImage(ApplicationUser user, IFormFile PhotoUrl)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (PhotoUrl is not null)
            {
                string imgPath = string.Empty;
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(PhotoUrl.FileName);

                if(User.IsInRole(StaticDetails.ROLE_CUSTOMER))
                    imgPath = @"img\customer\user-" + user.Id;
                else if (User.IsInRole(StaticDetails.ROLE_CUSTOMER))
                    imgPath = @"img\admin\user-" + user.Id;

                var finalPath = Path.Combine(wwwRootPath, imgPath);

                if (!Directory.Exists(finalPath))
                    Directory.CreateDirectory(finalPath);

                using (var fileStreams = new FileStream(Path.Combine(finalPath, filename), FileMode.Create))
                {
                    PhotoUrl.CopyTo(fileStreams);
                }
                return $"\\{imgPath}\\{filename}";
            }
            else 
                return string.Empty;
        }

        private void CustomImageValidation(IFormFile PhotoUrl, string propertyName)
        {
            var supportedTypes = new[] { "jpg", "jpeg", "png" };
            var fileExt = Path.GetExtension(PhotoUrl.FileName).Substring(1);

            if (!supportedTypes.Contains(fileExt))
                ModelState.AddModelError(string.Empty, $"File extension of {propertyName} is invalid - Only Upload jpg/jpeg/png image file.");
            //else if (PhotoUrl.Length > 1024)
            //    ModelState.AddModelError(string.Empty, $"File size of {propertyName} should be up to 1024KB");
        }

        private async Task LoadSelectListItem(string actionMethod)
        {
            IEnumerable<SelectListItem> classList = null;
            if (actionMethod == "OnPostAsync")
            {
                Input.roleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                });

                Input.gender = (await _unitOfWork.Gender.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });

                Input.religion = (await _unitOfWork.Religion.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });

                Input.branch = (await _unitOfWork.Branch.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                Input.branchClass = (await _unitOfWork.Class.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                Input.paymentMethod = (await _unitOfWork.PaymentMethod.GetAllAsync()).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            else if (actionMethod == "OnGetAsync")
            {
                Input = new InputModel()
                {
                    roleList = _roleManager.Roles.Select(x => x.Name).Select(i => new SelectListItem
                    {
                        Text = i,
                        Value = i
                    }),
                    gender = (await _unitOfWork.Gender.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    religion = (await _unitOfWork.Religion.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    branch = (await _unitOfWork.Branch.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }),
                    paymentMethod = (await _unitOfWork.PaymentMethod.GetAllAsync()).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    })
                };
            }
        }
    }
}
