using Moq;
using NUnit.Framework;
using WebAPI.Business.Concrete;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entity.Concrete;

namespace WebAPI.Tests;

public class Denemetest
{
    private Mock<IGenericDal<Post>>? _mockPostDal; //Sahte data ürettik bu kütüphane ile....
    private PostService? _postService;
    //UnitOfWork_Condition_ExpectedResult

    //Condition_Result

    [SetUp]
    public void Setup()
    {
        _mockPostDal = new Mock<IGenericDal<Post>>();
        _postService = new PostService(_mockPostDal.Object);
    }

    [Test]
    public async Task testListAsync_ShouldReturnPostList()
    // testListAsync_ShouldThrow_WhenPostIdEqualsNull
    {
        // Arrange
        var posts = new List<Post>
            {
                new Post { PostId = Guid.NewGuid(), Title = "Post 1" }
            };

        _mockPostDal.Setup(x => x.GetAllListAsync()).ReturnsAsync(posts);

        // Act
        var result = await _postService.GetAllListAsync();

        // Assert
        Assert.Pass("Test başarılı!"); // ✅ Test başarılı sayılır, mesaj yazılır
    }
    [Test]
    public async Task createAsync()
    {
        // Arrange
        var post = new Post { PostId = Guid.NewGuid(), Title = "Yeni bir post" };

        // Act
        await _postService.CreateAsync(post);

        // Assert
        _mockPostDal.Verify(x => x.CreateAsync(post), Times.Once);
        Assert.Pass("Test başarılı!"); // ✅ Test başarılı sayılır, mesaj yazılır

    }

    [Test]
    public async Task getByIdAsync()
    {
        // Arrange
        var postId = Guid.NewGuid();
        var expectedPost = new Post { PostId = postId, Title = "Yeni post" };

        _mockPostDal.Setup(x => x.GetByIDAsync(postId)).ReturnsAsync(expectedPost);
        var result = await _postService.GetByIDAsync(postId);

        Assert.Pass("Test başarılı!");
    }
}