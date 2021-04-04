using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalsFriends.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Баба Марта идва!", Category = Helpers.Classes.BlogCategory.Causes },
                new Post { Id = 2, Title = "Великденски яйца!", Category = Helpers.Classes.BlogCategory.News },
                new Post { Id = 3, Title = "Томи има нужда от лечение!", Category = Helpers.Classes.BlogCategory.News },
                new Post { Id = 4, Title = "Ване се въстановява!", Category = Helpers.Classes.BlogCategory.Causes },
                new Post { Id = 5, Title = "Коледна къщичка!", Category = Helpers.Classes.BlogCategory.Causes });

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, UserId = 1, Name = "Бонд", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Бонд - покорителят на женски сърца намери своята нова стопанка!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Bond.jpg") },
                new Animal { Id = 2, UserId = 1, Name = "Буря", Gender = Helpers.Classes.Gender.Female, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Сладък котарак! Оранжева фурия!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Burq.jpg") },
                new Animal { Id = 3, UserId = 2, Name = "Елмо", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Елмо вече се радва на всекиднвени разходки с новото си семейство!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Elmo.jpg") },
                new Animal { Id = 4, UserId = 1, Name = "Ласи", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Пухест и добър!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Lasi.jpg") },
                new Animal { Id = 5, UserId = 1, Name = "Пипин", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Госпожа Саня е на около 6 години.", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Pipin.jpg") },
                new Animal { Id = 6, UserId = 2, Name = "Саня", Gender = Helpers.Classes.Gender.Female, CurrentStatus = Helpers.Classes.AnimalStatus.InMedicalCare, Description = "Оранжева фурия!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Sanq.jpg") },
                new Animal { Id = 7, UserId = 2, Name = "Сняг", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Сняг е на около 8 месеца, кротък и поспалив. Търси своите хора!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Snqg.jpg") },
                new Animal { Id = 8, UserId = 2, Name = "Томи", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Томи вече се привиква на новия си начин на живот - заобиколен от своите любящи нови стопани!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Tommy.jpg") },
                new Animal { Id = 9, UserId = 2, Name = "Бистра", Gender = Helpers.Classes.Gender.Female, CurrentStatus = Helpers.Classes.AnimalStatus.InMedicalCare, Description = "Малката Бистра беше намерена със счупен крак (най-вероятно блъсната от кола), но вече се възстановява!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = ConvertImageToBase64("\\Resources\\images\\thumbnails\\Bistra.jpg") });


            //modelBuilder.Entity<User>().HasData(
            //    new User { Id = 1, Email = "danitza@example.com" },
            //    new User { Id = 2, Email = "niya@example.com" });
        }

        private static string ConvertImageToBase64(string imgUrl)
        {
            var test = Environment.CurrentDirectory + imgUrl;
            byte[] imageArray = System.IO.File.ReadAllBytes(test);
            return "data:image/png;base64," + Convert.ToBase64String(imageArray);
        }
    }
}
