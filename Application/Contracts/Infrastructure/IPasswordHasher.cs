using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts.Infrastructure
{
    public interface IPasswordHasher
    {
        string HashPassword( string plainPassword);
        PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
    }

    public enum PasswordVerificationResult
    {
        Failed = 0,
        Success = 1
    }
}
