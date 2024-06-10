using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;
using System;

namespace RazorPages.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesContext>>()))
            {
                if (context == null || context.Users == null)
                {
                    throw new ArgumentNullException("Null RazorPagesContext");
                }

                if (context.Users.Any())
                {
                    return;   
                }

                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Jan",
                        LastName = "Kowalski",
                        Role = "Informatyk"
                    },

                    new User
                    {
                        FirstName = "Bartosz",
                        LastName = "Michalski",
                        Role = "Ksiegowy"
                    },

                    new User
                    {
                        FirstName = "Piotr",
                        LastName = "Tutaj",
                        Role = "Programista"
                    },

                    new User
                    {
                        FirstName = "Dimitry",
                        LastName = "Valentinos",
                        Role = "Magazynier"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
