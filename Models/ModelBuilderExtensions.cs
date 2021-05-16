using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalsFriends.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Email = "danitza@example.com", PasswordHash = "12345", FirstName = "Даница", LastName = "Влахова", IsAdmin = true },
                new User { Email = "jenny@example.com", PasswordHash = "123456", FirstName = "Джейлян", LastName = "Адемова", IsAdmin = false });

            modelBuilder.Entity<Animal>().HasData(
               new Animal { Id = Guid.Parse("2a6183ea-100e-4e78-ad26-14b7de22e571"), Name = "Бонд", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Бонд - покорителят на женски сърца намери своята нова стопанка!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Bond.jpg") },
               new Animal { Id = Guid.Parse("b35c7f05-4c59-49e9-9688-8ea8c44d6eed"), Name = "Буря", Gender = Helpers.Classes.Gender.Female, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Сладък котарак! Оранжева фурия!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Burq.jpg") },
               new Animal { Id = Guid.Parse("c2ef263f-efd4-46ce-b512-1152f316971d"), Name = "Елмо", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Елмо вече се радва на всекиднвени разходки с новото си семейство!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Elmo.jpg") },
               new Animal { Id = Guid.Parse("797dff10-6c5f-40ae-9a06-0845e17f8ed0"), Name = "Ласи", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Пухест и добър!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Lasi.jpg") },
               new Animal { Id = Guid.Parse("5d5102df-bee0-4588-b2ed-ae149b1211f8"), Name = "Пипин", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Госпожа Саня е на около 6 години.", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Pipin.jpg") },
               new Animal { Id = Guid.Parse("ee193bc8-b139-400d-a5bd-a414bf2255dc"), Name = "Саня", Gender = Helpers.Classes.Gender.Female, CurrentStatus = Helpers.Classes.AnimalStatus.InMedicalCare, Description = "Оранжева фурия!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Sanq.jpg") },
               new Animal { Id = Guid.Parse("a798f9ba-3cb9-4046-8e8b-71aef6ccdbf4"), Name = "Сняг", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Сняг е на около 8 месеца, кротък и поспалив. Търси своите хора!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Snqg.jpg") },
               new Animal { Id = Guid.Parse("1189ab7c-c7cc-4390-ac5a-35c1d7564ce4"), Name = "Томи", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Томи вече се привиква на новия си начин на живот - заобиколен от своите любящи нови стопани!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Tommy.jpg") },
               new Animal { Id = Guid.Parse("1a4ef056-8274-41d4-a978-f39f908ba688"), Name = "Бистра", Gender = Helpers.Classes.Gender.Female, CurrentStatus = Helpers.Classes.AnimalStatus.InMedicalCare, Description = "Малката Бистра беше намерена със счупен крак (най-вероятно блъсната от кола), но вече се възстановява!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Bistra.jpg") });

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = Guid.Parse("560d8317-2ddc-4f49-8ed5-09419957ab6f"), Title = "Баба Марта идва!", Category = Helpers.Classes.BlogCategory.Causes },
                new Post { Id = Guid.Parse("afec3793-fd53-4f39-a3b6-7d453ab39105"), Title = "Великденски яйца!", Category = Helpers.Classes.BlogCategory.News },
                new Post { Id = Guid.Parse("03e77fe4-dcdd-49ef-ae03-338c219ca12c"), Title = "Томи има нужда от лечение!", Category = Helpers.Classes.BlogCategory.News },
                new Post { Id = Guid.Parse("a7162e74-3e44-45cd-990a-aa4202026851"), Title = "Ване се въстановява!", Category = Helpers.Classes.BlogCategory.Causes },
                new Post { Id = Guid.Parse("b0ffb191-f1c1-4af5-bb37-b2a6ac49253f"), Title = "Коледна къщичка!", Category = Helpers.Classes.BlogCategory.Causes });                             
        }

        private static string ConvertImageToBase64(string imgUrl)
        {
            var test = Environment.CurrentDirectory + imgUrl;
            byte[] imageArray = System.IO.File.ReadAllBytes(test);
            return "data:image/png;base64," + Convert.ToBase64String(imageArray);
        }
    }
}
