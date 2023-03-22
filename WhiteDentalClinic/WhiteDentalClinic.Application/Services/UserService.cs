using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using N_Tier.Application.Templates;
using WhiteDentalClinic.Application.Exceptions;
using WhiteDentalClinic.Application.Models.UserModel;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.DataAccess.Identity;

namespace WhiteDentalClinic.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITemplateService _templateService;
        public UserService(IMapper mapper,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            ITemplateService templateService) 
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _templateService = templateService;
        }

        public async Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel)
        {
            var user = _mapper.Map<ApplicationUser>(createUserModel);
            var result = await _userManager.CreateAsync(user, createUserModel.Password);
            
            if(!result.Succeeded) throw new BadRequestException(result.Errors.FirstOrDefault()?.Description); 
            
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var emailTemplate = await _templateService.GetTemplateAsync(TemplateConstants.ConfirmationEmail);

            var emailBody = _templateService.ReplaceInTemplate(emailTemplate,
                new Dictionary<string, string> { { "{UserId}", user.Id }, { "{TokenId}", token } });

            //await _emailService.SendEmailAsync(EmailMessage.Create(user.Email, emailBody, "[N-Tier]Confirm your email"));

            return new CreateUserResponseModel
            {
                Id = Guid.Parse((await _userManager.FindByIdAsync(user.UserName)).Id)
            };
        }
    }
}
