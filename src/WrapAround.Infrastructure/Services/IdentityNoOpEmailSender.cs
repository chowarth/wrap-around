﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using WrapAround.Infrastructure.Common.Persistence;

namespace WrapAround.Infrastructure.Services
{
    public sealed class IdentityNoOpEmailSender : IEmailSender<User>
    {
        private readonly IEmailSender _emailSender = new NoOpEmailSender();

        public Task SendConfirmationLinkAsync(User user, string email, string confirmationLink)
        {
            return _emailSender.SendEmailAsync(email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
        }

        public Task SendPasswordResetLinkAsync(User user, string email, string resetLink)
        {
            return _emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password by <a href='{resetLink}'>clicking here</a>.");
        }

        public Task SendPasswordResetCodeAsync(User user, string email, string resetCode)
        {
            return _emailSender.SendEmailAsync(email, "Reset your password", $"Please reset your password using the following code: {resetCode}");
        }
    }
}
