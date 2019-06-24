using System.Linq;
using BusinessLogic.CoreEntity.TypedCoreEntity;
using DataAccess.Models;

namespace BusinessLogic.ValidationModels
{
    public class ValidationBlog : IValidationModel<Blog>
    {

        //**************************************************
        //* Property
        //**************************************************
        
        //--------------------------------------------
        public IntType Id { get; }

        //--------------------------------------------
        public StringType Name { get; }

        //--------------------------------------------
        public TypedEntity<ValidationBlogPost> BlogPost { get; }

        //--------------------------------------------
        public ListType<ValidationBlogPost> BlogPosts { get; }

        
        
        //**************************************************
        //* Public
        //**************************************************

        //--------------------------------------------
        public Blog ToModel()
        {
            return new Blog
            {
                Id = Id.Value,
                Name = Name.Value,
                Post = BlogPost.HasValue 
                    ? BlogPost.Value.ToModel()
                    : default,
                Posts = BlogPost.HasValue
                    ? BlogPosts.Value
                        .Select(p => p.ToModel())
                        .ToList()
                    : default
            };
        }
        
    }
}