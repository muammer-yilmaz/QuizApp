using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Abstraction.File;
using QuizApp.Application.Features.User.Commands.CreateUser;
using QuizApp.Application.Features.User.Commands.UpdatePassword;
using QuizApp.Application.Features.User.Commands.UpdateProfile;
using QuizApp.Application.Features.User.Commands.UploadImage;
using QuizApp.Application.Features.User.Queries.GetAllUsers;
using QuizApp.Application.Features.User.Queries.GetUser;
using QuizApp.Domain.Entities.Identity;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Controllers;

[Authorize]
public class UsersController : ApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IImageService _imageService;

    public UsersController(IMediator mediator, UserManager<AppUser> userManager, IImageService imageService) : base(mediator)
    {
        _userManager = userManager;
        _imageService = imageService;
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public async Task<ActionResult<CreateUserCommandResponse>> Create([FromBody] CreateUserCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [SwaggerOperation(Summary = "** this action requires Authentication **")]
    [HttpGet("[action]")]
    public async Task<ActionResult<GetUserQueryResponse>> GetUserProfile()
    {
        GetUserQuery query = new();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet("[action]")]
    public async Task<ActionResult<GetAllUsersQueryResponse>> GetAll()
    {
        var response = await _mediator.Send(new GetAllUsersQuery());
        return Ok(response);
    }

    [SwaggerOperation(Summary = "** this action requires Authentication **")]
    [HttpPut("[action]")]
    public async Task<ActionResult<UpdateProfileCommandResponse>> UpdateProfile([FromBody] UpdateProfileCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [SwaggerOperation(Summary = "** this action requires Authentication **")]
    [HttpPut("[action]")]
    public async Task<ActionResult<UpdatePasswordCommandResponse>> UpdatePassword([FromBody] UpdatePasswordCommand request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [SwaggerOperation(Summary = "** this action requires Authentication **")]
    [HttpPost("[action]")]
    public async Task<ActionResult<UploadImageCommandResponse>> UploadProfilePicture(IFormFile image)
    {
        var response = await _mediator.Send(new UploadImageCommand(image));
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("[action]")]
    [SwaggerOperation(Summary = "!!!!! Use this method to delete user from DB also deletes Image from cloudinary !!!!!")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            return BadRequest("Kullanıcı bulunamadı");
        }
        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            var isDeleted = await _imageService.DeleteImage(userId);
            return isDeleted ? NoContent() : BadRequest();
        }
        return BadRequest();
    }
}
