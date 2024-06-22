using Autofac;
using AutoMapper;
using MetalWorm.NoteApp.BL.Abstract;
using MetalWorm.NoteApp.BL.Concrete;
using MetalWorm.NoteApp.BL.Validations;
using MetalWorm.NoteApp.Dal;
using MetalWorm.NoteApp.Dal.Mapper;
using MetalWorm.NoteApp.Dal.Repositories.Concrete;
using MetalWorm.NoteApp.Dto;
using MetalWorm.NoteApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Globalization;

namespace MetalWorm.NoteApp.UI
{
    public class Program
    {
        
        static async Task Main(string[] args)
        {
            //var builder = new ContainerBuilder();

            //builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();

            //builder.Register(x =>
            //{
            //    var optionbuilder = new DbContextOptionsBuilder<AppDbContext>();
            //    optionbuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=NoteApp;Integrated Security=True;");
            //    return new AppDbContext(optionbuilder.Options);
            //}).InstancePerLifetimeScope();

            //var container = builder.Build();

            //va
            //r sc = container.BeginLifetimeScope();
            //var context = sc.Resolve<AppDbContext>();

            var noteManager = new NoteManager();
            var _userManager = new UserManager();
            IMapper _mapper = MapperSingleton.GetMapperInstance();
            UserValidator userValid = new UserValidator();
            NoteValidator notevalid = new NoteValidator();



            while (true)
            {
                Console.WriteLine("İşlem seçiniz\n0-)Oturum aç\n1-) Kayıt Ol \n 2-)Kaytıtları göster");
                var secim = Console.ReadLine();

                switch (Convert.ToInt32(secim))
                {
                    case 0:
                        Console.WriteLine("Kullanıcı Adı giriniz");
                        string kAdı = Console.ReadLine();
                        Console.WriteLine("Şifre giriniz");
                        string passwd = Console.ReadLine();

                        var usercheck = await _userManager.CheckUserAsync(kAdı, passwd);


                        if (usercheck is not null)
                        {
                            while (true)
                            {
                                Console.WriteLine("Ne yapmak istersiniz ?\n1-)Not Ekle\n2-)Notları Listele\n3-)Not sil\n4-)Not Güncelle\n5-)Çıkış");
                                string istek = Console.ReadLine();

                                switch (Convert.ToInt16(istek))
                                {
                                    case 1:
                                        Console.WriteLine("Not title yaz");
                                        string title = Console.ReadLine();
                                        Console.WriteLine("Content yaz");
                                        string content = Console.ReadLine();

                                        Note note = new Note()
                                        {
                                            Title = title,
                                            Content = content,
                                            UserId = usercheck.Id,
                                        };
                                        var noteValidResult =  notevalid.Validate(note);
                                        if (noteValidResult.IsValid)
                                        {
                                            noteManager.InsertAsync(note);
                                            Console.WriteLine("Not eklendi");
                                        }
                                        else
                                        {
                                            foreach (var item in noteValidResult.Errors)
                                            {
                                                Console.WriteLine($"{item}");
                                            }
                                        }
                                        
                                        break;

                                    case 2:
                                        IEnumerable<NoteViewDto> notlar = await noteManager.GetUserNotes(usercheck);
                                        foreach (var item in notlar)
                                        {
                                            Console.WriteLine($"ID:{item.Id} Title:{item.Title}\n{item.Content}\n");
                                        }
                                        break;

                                    case 3:
                                        Console.WriteLine("Silmek istediğin notun ID'sini gir.");
                                        int id = Convert.ToInt32(Console.ReadLine());
                                        await noteManager.DeleteAsync(id);
                                        Console.WriteLine("Silindi");
                                        break;

                                    case 4:
                                        Console.WriteLine("Güncellemek istediğiniz notun ID'sini giriniz...");
                                        int notId = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Güncellemek istediğiniz notun Title'ını giriniz...");
                                        string noteTitle = Console.ReadLine();
                                        Console.WriteLine("Güncellemek istediğiniz notun Content'ını giriniz...");
                                        string noteContent = Console.ReadLine();

                                        NoteUpdateDto noteUpdateDto = new NoteUpdateDto()
                                        {
                                            Id = notId,
                                            Title = noteTitle,
                                            Content = noteContent
                                        };
                                        await noteManager.UpdateAsync(_mapper.Map<Note>(noteUpdateDto));

                                        break;

                                    case 5:
                                        break;

                                    default:
                                        break;
                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Kullanıcı bulunamadı");
                        }
                        break;


                    case 1:
                        Console.WriteLine("UserName giriniz...");
                        string usrName = Console.ReadLine();
                        Console.WriteLine("FirstName giriniz...");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("LastName giriniz...");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Password giriniz");
                        string password = Console.ReadLine();

                        User user = new User()
                        {
                            UserName = usrName,
                            FirstName = firstName,
                            LastName = lastName,
                            Password = password
                        };
                        var result = userValid.Validate(user);
                        if (result.IsValid)
                        {
                            _userManager.InsertAsync(user);
                            Console.WriteLine("kullanıcı eklendi");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                Console.WriteLine($"{item}");
                            }

                        }


                        break;

                    case 2:
                        IEnumerable<User> users = await _userManager.GetAllAsync();

                        foreach (var item in users)
                        {
                            Console.WriteLine($"User Name: {item.UserName}\nFirst Name: {item.FirstName}\n" +
                                $"Last Name: {item.LastName}\n Password: {item.Password}\n\n");
                        }
                        break;


                    default:
                        break;
                } 
            }





































            //User user = new User
            //{
            //    CreatedDate = DateTime.Now,
            //    UserName = "tester",
            //    FirstName = "test",
            //    LastName = "testoğulları",
            //    Password = "123"
            //};


            //var addedUser = context.Users.Add(user);

            //if (addedUser.State==EntityState.Added)
            //{
            //    Console.WriteLine("user eklendi");
            //}
            //else
            //{
            //    Console.WriteLine("user eklenemedi");
            //}
            //context.SaveChanges();



            //Note not = new Note()
            //{
            //    CreatedDate = DateTime.Now,
            //    Title = "Test",
            //    Content = "deneme içeriği"
            //};

            //var addedentity = context.Add(not);

            //context.SaveChanges();

            //if (addedentity.State==EntityState.Added)
            //{
            //    Console.WriteLine("ekleme başarılı");
            //}
            //else
            //{
            //    Console.WriteLine("ekleme başarısız");
            //}


        }


    }
}
