using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CS.PMA.DAL.Database
{
    public class PMDbContextSeeder : DropCreateDatabaseIfModelChanges<PMDbContext>
    {
        protected override void Seed(PMDbContext context)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Name="Saurabh",
                    Password="123456",
                    Email="saurabh@gmail.com",
                    CreatedAt=DateTime.Now,
                    Products=new List<Product>()
                    {
                        new Product()
                        {
                            Name="Realme x",
                            Category="Electronics",
                            Price=18000,
                            Quantity=30,
                            ShortDescription="Realme x",
                            LongDescription="Realme x Realme x",
                            SmallImageUrl="small06012021 090531 PM.jpg",
                            LargeImageUrl="large06012021 090531 PM.jpg",
                            CreatedAt=DateTime.Now
                        },
                        new Product()
                        {
                            Name="Bat",
                            Category="Sports",
                            Price=1500,
                            Quantity=30,
                            ShortDescription="Bat",
                            LongDescription="Bat Bat Bat",
                            SmallImageUrl="small06012021 090927 PM.jpg",
                            LargeImageUrl="large06012021 090927 PM.jpg",
                            CreatedAt=DateTime.Now
                        },
                        new Product()
                        {
                            Name="Headphone",
                            Category="Electronics",
                            Price=4000,
                            Quantity=50,
                            ShortDescription="Headphone",
                            LongDescription="Headphone Headphone Headphone",
                            SmallImageUrl="small06012021 091003 PM.jpg",
                            LargeImageUrl="large06012021 091003 PM.jpg",
                            CreatedAt=DateTime.Now
                        },
                        new Product()
                        {
                            Name="Chair",
                            Category="Furniture",
                            Price=2000,
                            Quantity=30,
                            ShortDescription="Chair",
                            LongDescription="Chair Chair Chair",
                            SmallImageUrl="small06012021 091304 PM.jpg",
                            LargeImageUrl="large06012021 091304 PM.jpg",
                            CreatedAt=DateTime.Now
                        }
                    }
                },
                new User()
                {
                    Name="Ramesh",
                    Password="123456",
                    Email="ramesh@gmail.com",
                    CreatedAt=DateTime.Now,
                    Products=new List<Product>()
                    {
                        new Product()
                        {
                            Name="Red Sweater hoodie",
                            Category="Clothes",
                            Price=1500,
                            Quantity=10,
                            ShortDescription="Red Sweater hoodie",
                            LongDescription="Red Sweater hoodie",
                            SmallImageUrl="small06012021 094016 PM.jpg",
                            LargeImageUrl="large06012021 094016 PM.jpg",
                            CreatedAt=DateTime.Now
                        },
                        new Product()
                        {
                            Name="TV",
                            Category="Electronics",
                            Price=18000,
                            Quantity=10,
                            ShortDescription="TV",
                            LongDescription="TV TV TV TV",
                            SmallImageUrl="small07012021 100844 AM.jpg",
                            LargeImageUrl="large07012021 100844 AM.jpg",
                            CreatedAt=DateTime.Now
                        }
                    }
                }
            };
            foreach (var data in users)
            {
                context.Users.Add(data);
            }
            base.Seed(context);
        }
    }
}
