using Backend1.DTOs;
using System.Text.Json;

namespace Backend1.Services
{
    public class PostsService : IPostsService
    {
        private HttpClient _httpclient;

        public PostsService( HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
           
            var result = await _httpclient.GetAsync(_httpclient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);

            return post;
        }
    }
}
