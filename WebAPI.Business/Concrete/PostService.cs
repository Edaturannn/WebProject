using WebAPI.Business.Abstract;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entity.Concrete;

namespace WebAPI.Business.Concrete;

public class PostService : IPostService
{
    private readonly IGenericDal<Post> _postService;

    public PostService(IGenericDal<Post> postService)
    {
        _postService = postService;
    }
    public async Task CreateAsync(Post t)
    {
        await _postService.CreateAsync(t);
    }

    public Task<Post> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Post>> GetAllListAsync()
    {
        var values = await _postService.GetAllListAsync();
        return values;
    }

    public async Task<Post?> GetByIDAsync(Guid id)
    {
        var values = await _postService.GetByIDAsync(id);
        return values;
    }

    public Task UpdateAsync(Post t, Guid id)
    {
        throw new NotImplementedException();
    }
}