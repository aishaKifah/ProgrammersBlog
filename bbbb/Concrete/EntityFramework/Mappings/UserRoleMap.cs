﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using programmersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {

        public void Configure(EntityTypeBuilder<UserRole> b)
        {
            // Primary key
            b.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            b.ToTable("AspNetUserRoles");

            b.HasData(

                new UserRole
                {
                    UserId=1,
                    RoleId=1


                },

                new UserRole
                {
                    UserId = 2,
                    RoleId = 2

                }


                );
        }
    }
}
