using System.Net.Http.Json;
using NUnit.Framework;
using WebAPI.Entity.Concrete;

namespace WebAPI.IntegrationTests;

[TestFixture]
public class PostApiTests
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        var factory = new CustomWebApplicationFactory();
        _client = factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client?.Dispose(); // null kontrolü
    }

    //İsimlendirme = hangiendpointisim_ne islemiyapacağım
    [Test]
    public async Task CreatePost_ShouldAddToDatabase() //Post_Olusturuldugunda_Veritabanina_Eklenmelidir
    {
        //Arrange
        var newPost = new Post
        {
            Title = "Test Başlık",
            Content = "Test içerik"
        };
        //Action
        var response = await _client.PostAsJsonAsync("/posts/createpostasync", newPost);

        //Assert
        Assert.That(response.IsSuccessStatusCode, Is.True);
    }



    //Bu hata testi hata verecek çünkü ben [Required(ErrorMessage)] yapmadım boş geçilebilir yaptım. olumlu cevap olur hata verir çalışmaz.... Hatali kod yazdım..... Ama DÜZELTTİM........
    [Test]
    public async Task CreatePost_ShouldNotAddToDatabase() //Post_Olusturuldugunda_Veritabanina_Eklenmemelidir
    {
        //Arrange
        var newPost = new Post
        {
            Title = "",
            Content = "",
        };

        //Action
        var response = await _client.PostAsJsonAsync("/posts/createpostasync", newPost); //Bu satır, test sırasında ASP.NET Core API'ye POST yöntemiyle istek gönderi


        //Assert
        //Bu hata testi hata verecek çünkü ben [Required(ErrorMessage)] yapmadım boş geçilebilir yaptım. olumlu cevap olur hata verir çalışmaz....
        Assert.That(response.IsSuccessStatusCode, Is.False);
        Assert.That((int)response.StatusCode, Is.EqualTo(400), "Beklenen durum kodu 400 BadRequest olmalı.");
    }
    [Test]

    public async Task ListPost_ShouldListToDatabase() //PostListeleme_Veritabanindaki_Verileri_Dondurmelidir
    {
        var newPost = new Post
        {
            Title = "Test Başlık",
            Content = "Test içerik"
        };

        var response = await _client.PostAsJsonAsync("/posts/createpostasync", newPost); //Post isteğinde bulunduk.

        Assert.That(response.IsSuccessStatusCode, Is.True);

        var values = await _client.GetAsync("/posts/getalllistpostasync");

        Assert.That(values.IsSuccessStatusCode, Is.True);


        var posts = await values.Content.ReadFromJsonAsync<List<Post>>(); //Eklediğimiz değerleri listeldi. 


        Assert.That(posts, Is.Not.Null); //postlar boş listelenmiyor.



        //Listeleme yaparken önce post istediğinde bulunuyoruz. Çünkü gecici memmory(RAM) test veri tabanının içini doldurmmız gerekiyor. 

    }

}
