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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
             new IdentityRole
             { 
                Id= "a40a293f-9d70-4efe-a2f5-8ae6d5a6f5ea",
                Name="User",
                NormalizedName="USER"
             },
             new IdentityRole
             {
                 Id = "6dc8bc87-a2e1-465d-80d8-3aa3f093267f",
                 Name = "Administrator",
                 NormalizedName = "ADMINISTRATOR"
             }
            );
        }
    }
}
