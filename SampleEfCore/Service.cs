using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SampleEfCore
{
    public static class Service
    {
        /// <summary>
        /// Метод для получения всех блогов
        /// </summary>
        /// <returns></returns>
        public static List<Blog> GetBlogs()
        {
            using var db = new BloggingContext();
            //Берем из базы сущность Блог с использованием жадной загрузки
            var blogWithEagerLoading = db.Blogs.Include(x => x.Posts).ToList();
            return blogWithEagerLoading;
        }

        /// <summary>
        /// Метод для получения блога по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Blog GetBlog(int id)
        {
            using var db = new BloggingContext();
            //Берем из базы сущность Блог без подгрузки связанных данных
            var blogWithoutLoad = db.Blogs.Find(id);
            //Для сущности Блог выполняем явную подгрузку связанных сущностей Пост
            db.Entry(blogWithoutLoad).Collection(x => x.Posts).Load();
            return blogWithoutLoad;
        }

        /// <summary>
        /// Метод для получения всех постов
        /// </summary>
        /// <returns></returns>
        public static List<Post> GetPosts()
        {
            using var db = new BloggingContext();
            return db.Posts.ToList();
        }

        /// <summary>
        /// Метод для добавления Блога
        /// </summary>
        /// <param name="newBlog">Новый блог</param>
        public static void AddBlog(Blog newBlog)
        {
            using var db = new BloggingContext();
            db.Add(newBlog);
            db.SaveChanges();
        }

        /// <summary>
        /// Метод для обновления Блога
        /// </summary>
        /// <param name="id">Айди блога</param>
        /// <param name="newUrl">Новый урл</param>
        public static void UpdateBlog(int id, string newUrl)
        {
            using var db = new BloggingContext();
            var blog = db.Blogs.Find(id);
            blog.Url = newUrl;
            db.Update(blog);
            db.SaveChanges();
        }
    }
}