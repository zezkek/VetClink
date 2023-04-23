using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VetClink.Models;

namespace VetClink.Data
{
    /// <summary>
    /// Базовое заполнение базы данных
    /// </summary>
    public class BasicSeed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (IServiceScope ServiceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                AppDbContext appDbContext = ServiceScope.ServiceProvider.GetService<AppDbContext>();

                appDbContext.Database.EnsureCreated();
                //Питомцы и владельцы
                if (!appDbContext.Animals.Any())
                {
                    appDbContext.Animals.AddRange(new List<Animal>()
                    {
                        new Animal()
                        {
                            Gender = Enum.AnimalGender.Male,
                            AnimalType = Enum.AnimalType.Cat,
                            Age = 8,
                            Owner = new Owner()
                            {
                                Name = "Олег",
                                Adress = "some street",
                                Phone = "88005553535",
                                Email = "example@test.com"
                            },
                            AnimalSubType = "Сиамская"
                        },
                        new Animal()
                        {
                            Gender = Enum.AnimalGender.Female,
                            AnimalType = Enum.AnimalType.Dog,
                            Age = 8,
                            Owner = new Owner()
                            {
                                Name = "Вова",
                                Adress = "some street 2",
                                Phone = "88005553535",
                                Email = "example2@test.com"
                            },
                            AnimalSubType = "Ретривер"
                        },
                        new Animal()
                        {
                            Gender = Enum.AnimalGender.Female,
                            AnimalType = Enum.AnimalType.Fish,
                            Age = 8,
                            Owner = new Owner()
                            {
                                Name = "Саша",
                                Adress = "some street 3",
                                Phone = "88005553535",
                                Email = "example3@test.com"
                            },
                            AnimalSubType = "Золотая"
                        }
                    });
                    appDbContext.SaveChanges();
                }

                //Работники
                if (!appDbContext.Worker.Any())
                {
                    appDbContext.Worker.AddRange(new List<Worker>(){
                        new Worker()
                        {
                            Name = "Алекс",
                            Phone = "88005553535",
                            Email = "worker1@test.com",
                            WorkerType = Enum.WorkerType.Nurse,
                            WorkerChief = new Worker()
                            {
                                Name = "Михаил",
                                Phone = "88005553535",
                                Email = "worker2@test.com",
                                WorkerType = Enum.WorkerType.Doctor
                            }
                        },
                        new Worker()
                        {
                            Name = "Артем",
                            Phone = "88005553535",
                            Email = "worker3@test.com",
                            WorkerType = Enum.WorkerType.Staff
                        },
                    });
                    appDbContext.SaveChanges();
                }

                //Прививки
                if (!appDbContext.Vaccinations.Any())
                {
                    appDbContext.Vaccinations.Add(new Vaccination()
                    {
                        AnimalType = Enum.AnimalType.Cat,
                        Title = "От бешенства",
                        Description = "Бешенство - заболевание, поражающее центральную нервную систему животного. Переносчиками являются грызуны и другие зараженные животные. Бешенство не поддается лечению. Опасность заключается в том, что заболевание может передаваться от животного к человеку.",
                        Price = 4000
                    });
                    appDbContext.SaveChanges();
                }

                //Услуги
                if (!appDbContext.Services.Any())
                {
                    appDbContext.Services.Add(new Service()
                    {
                        Title = "Узи",
                        Price = 1000,
                        Description = "Узи для вашего питомца",
                    });
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var appDbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

            AppUser adminUser = await userManager.FindByNameAsync("Admin");
            if(adminUser == null)
            {
                adminUser = new AppUser()
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    EmailConfirmed = true
                };
            };

            await userManager.CreateAsync(adminUser, "12345");
            await appDbContext.SaveChangesAsync();

            AppUser appUser = await userManager.FindByNameAsync("User");
            if (appUser == null)
            {
                appUser = new AppUser()
                {
                    UserName = "User",
                    Email = "User@gmail.com",
                    EmailConfirmed = true
                };
            };

            //Не сохраняет объект в бд и из-за этого выкидывает ошибку
            userManager.CreateAsync(appUser, "12345").Wait();
            appDbContext.SaveChanges();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            await userManager.AddToRoleAsync(adminUser, "Admin");
            await userManager.AddToRoleAsync(appUser, "User");
        }
    }
}
