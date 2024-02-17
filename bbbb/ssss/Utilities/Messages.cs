using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Sorry no category is found.";
                return "Sorry this category doesn't exist! ";
            }
            public static string Add(string categoryName)
            {
                return $"{categoryName} Added sucessfully ";
            }
            public static string Update(string categoryName)
            {
                return $"{categoryName} Updated sucessfully ";
            }
            public static string Delete(string categoryName)
            {
                return $"{categoryName} deleted sucessfully ";
            }
            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} deleted sucessfully from database ";
            }
        }

        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Sorry no article is found.";
                return "Sorry this article doesn't exist! ";
            }
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} Added sucessfully ";
            }
            public static string Update(string articleTitle)
            {
                return $"{articleTitle} Updated sucessfully ";
            }
            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} deleted sucessfully ";
            }
            public static string HardDelete(string articleTitle)
            {
                return $"{articleTitle} deleted sucessfully from database ";
            }
            public static string AlreadyExsit(string articleTitle)
            {
                return  $"Sorry the content is already exsit. {articleTitle} has been added! ";
            }
        }
    }
}
