namespace SampleEfCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Service.AddBlog(new Blog { Url = "http://blogs.msdn.com/adonet" });
                //var blogs = Service.GetBlogs();
                //Service.UpdateBlog(7, "Random text");
                var blog = Service.GetBlog(7);
                var blogs2 = Service.GetBlogs();
                var posts = Service.GetPosts();
            }
        }
    }
}