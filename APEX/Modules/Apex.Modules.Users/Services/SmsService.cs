﻿using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Apex.Modules.Users.Services
{
	public class SmsService : IIdentityMessageService
	{
		public Task SendAsync(IdentityMessage message)
		{
			// Plug in your sms service here to send a text message.
			return Task.FromResult(0);
		}
	}
}
