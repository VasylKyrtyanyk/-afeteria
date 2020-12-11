using System;

namespace Сafeteria.Services.Common.Exeptions
{
    public class AuthorizationFailedExeption : Exception
    {
        public AuthorizationFailedExeption(string userEmail)
            : base($"Failed to authorize the user with email: {userEmail}")
        {

        }
    }
}