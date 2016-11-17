using Blog_Task.BlogDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            AddPost(1, 2, "C# Forever!!!");
            AddPost(1, 2, "New task complete");
            AddPost(2, 4, "MS SQL");
            AddPost(2, 4, "New task complete");
        }

        static void AddCategory(int blogId, string name)
        {
            try
            {
                using (var db = new BlogContext())
                {
                    var category = new Category
                    {
                        Name = name,
                        BlogId = blogId
                    };

                    db.Categories.Add(category);
                    db.SaveChanges();
                }

                SendMail($"New category {name} added");
                
            }
            catch (Exception ex)
            {
                // Inner exeption (Unique field....)
                Console.WriteLine("This category exist! " + ex.InnerException.Message);
            }
        }

        static void AddPost(int userId, int categoryId, string text)
        {
            try
            {
                using (var db = new BlogContext())
                {
                    var post = new Post
                    {
                        Text = text,
                        UserId = userId
                    };

                    var postCategory = new PostCategory
                    {
                        PostId = post.Id,
                        CategoryId = categoryId
                    };

                    db.Posts.Add(post);
                    db.Entry(post).State = EntityState.Added;
                    db.PostCategories.Add(postCategory);
                    db.Entry(postCategory).State = EntityState.Added;
                    db.SaveChanges();
                }

                SendMail($"New category added");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void SendMail(string message)
        {
            //Method for sending email to moderator
        }
    }
}
