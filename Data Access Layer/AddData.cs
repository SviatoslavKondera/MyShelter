using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class AddData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            //using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            //{
            //    //Look for 
            //    if (context.Shelter.Any()) { return; }

            //    List<Category> categories = new List<Category>()
            //    {
            //        new Category{Name="Categ1",Description="Category description"}
            //    };

            //    List<Shelter> shelters = new List<Shelter>()
            //    {
            //        new Shelter(){ShelterName = "Jam Hotel Hnatyuka", ShelterShortDescription="" +
            //        "Готель Jam Гнатюка з баром, спільним лаунжем і видом на місто розташований у Львові," +
            //        " за 300 метрів від церкви Петра та Павла ордену єзуїтів. До послуг гостей ресторан і цілодобова стійка реєстрації.."
            //        ,City = "Львів", Street="Проспект Свободи 7"  , Category = categories.FirstOrDefault() ,
            //        Image = "~MyShelter/MyShelter/ShelterImgs/image-1.jpg", PeopleCount=7
            //       },
            //        new Shelter(){ShelterName = "Jam Hotel Hnatyuka222", ShelterShortDescription="" +
            //        "Готель Jam Гнатюка з баром, спільним лаунжем і видом на місто розташований у Львові," +
            //        " за 300 метрів від церкви Петра та Павла ордену єзуїтів. До послуг гостей ресторан і цілодобова стійка реєстрації.."
            //        ,City = "Київ", Street="Проспект Свободи 72",Category = categories.FirstOrDefault() ,PeopleCount=5,
            //        Image ="~MyShelter/MyShelter/ShelterImgs/image-1.jpg"}
            //    };

            //    context.Category.AddRange(categories);
            //    context.SaveChanges();

            //    context.Shelter.AddRange(shelters);
            //    context.SaveChanges();
            //}

        }
    }
}
