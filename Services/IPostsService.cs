using Backend1.DTOs;
namespace Backend1.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get();

    }
}
