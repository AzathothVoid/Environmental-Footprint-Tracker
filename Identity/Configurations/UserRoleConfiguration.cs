using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId= "a40a293f-9d70-4efe-a2f5-8ae6d5a6f5ea",
                    UserId= "16212ab6-1ef1-435c-916d-f2b75c79ae3b"
                },
                new IdentityUserRole<string>
                {
                    RoleId= "6dc8bc87-a2e1-465d-80d8-3aa3f093267f",
                    UserId= "080b76ff-eef2-4960-877e-72bd520523ad"
                }
            );
        }
    }
}
