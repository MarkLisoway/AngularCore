using BusinessLogic.CoreEntity.TypedCoreEntity;
using DataAccess.Models;

namespace BusinessLogic.ValidationModels
{
    public class ValidationBlogPost : IValidationModel<BlogPost>
    {

        //**************************************************
        //* Property
        //**************************************************

        //--------------------------------------------
        public IntType Id { get; }

        //--------------------------------------------
        public StringType Name { get; }

        //--------------------------------------------
        public StringType Content { get; }



        //**************************************************
        //* Public
        //**************************************************

        //--------------------------------------------
        public BlogPost ToModel()
        {
            return new BlogPost
            {
                Id = Id.Value,
                Name = Name.Value,
                Content = Content.Value
            };
        }
        
    }
}