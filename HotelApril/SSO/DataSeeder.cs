using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO
{
    public class DataSeeder
    {
        public static void Seed(IServiceProvider applicationServices)
        {
            using (IServiceScope serviceScope = applicationServices.CreateScope())
            {
                DatabaseContext context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                if (context.Database.EnsureCreated())
                {
                    PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();

                    IdentityUser user = new IdentityUser()
                    {
                        Id = Guid.NewGuid().ToString("D"),
                        Email = "admin@test.test",
                        NormalizedEmail = "admin@test.test".ToUpper(),
                        EmailConfirmed = true,
                        UserName = "admin",
                        NormalizedUserName = "admin".ToUpper(),
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };

                    user.PasswordHash = hasher.HashPassword(user, "password");

                    IdentityRole identityRole = new IdentityRole()
                    {
                        Id = Guid.NewGuid().ToString("D"),
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString("D")
                    };

                    IdentityUserRole<string> identityUserRole = new IdentityUserRole<string>() { RoleId = identityRole.Id, UserId = user.Id };

                    context.Roles.Add(identityRole);
                    context.Users.Add(user);
                    context.UserRoles.Add(identityUserRole);

                    context.SaveChanges();
                }
            }
        }
        }
    }
