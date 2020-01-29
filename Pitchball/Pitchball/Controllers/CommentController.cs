using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase.Extensions.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pitchball.Infrastructure.Commands.Account;
using Pitchball.Infrastructure.Commands.Captain;
using Pitchball.Infrastructure.Services.Interfaces;
using Pitchball.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Pitchball.Infrastructure.ViewModels.Pitch;

namespace Pitchball.Controllers
{
    public class CommentController : Controller
    {
        private readonly IPitchService _pitchService;
        private readonly IHostingEnvironment _environment;
        private readonly IPitchImage _pitchImage;
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly IAccountService _accountService;
        public CommentController(IPitchService pitchService, IPitchImage pitchImage, IHostingEnvironment enviroment, 
            IUserService userService, ICommentService commentService, IAccountService accountService) 
        {
            _pitchService = pitchService;
            _environment = enviroment;
            _pitchImage = pitchImage;
            _userService = userService;
            _commentService = commentService;
            _accountService = accountService;
        }
        [HttpPost("pitches/{id}/")]
        public async Task<IActionResult> CreateComment(int id, PitchViewModel command)
        {
            if (string.IsNullOrWhiteSpace(command.NewComment.Content))
            {
                TempData["CommentFlag"] = true;
                TempData["CommentMessage"] = "Comment can't be empty!";
                return RedirectToAction("Pitch", "Pitch", id);
            }

            try
            {
                var accountId = int.Parse(HttpContext.Session.GetString("Id"));
                var account = await _accountService.GetAsync(accountId);
                var pitch = await _pitchService.GetAsync(id);

                await _commentService.CreateCommentAsync(command.NewComment, account, pitch);

                return RedirectToAction("Pitch", "Pitch", id);
            }
            catch (InternalSystemException ex)
            {
                TempData["CommentFlag"] = true;
                TempData["CommentMessage"] = ex.Message;
                return RedirectToAction("Pitch", "Pitch", id);
            }
            catch (Exception)
            {
                TempData["CommentFlag"] = true;
                TempData["CommentMessage"] = "Something went wrong!";
                return RedirectToAction("Pitch", "Pitch", id);
            }
        }
    }
}
