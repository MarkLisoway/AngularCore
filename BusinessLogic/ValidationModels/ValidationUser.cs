using BusinessLogic.CoreEntity.TypedCoreEntity;
using DataAccess.Models;

namespace BusinessLogic.ValidationModels
{
    public class ValidationUser : IValidationModel<User>
    {

        //**************************************************
        //* Property
        //**************************************************

        //--------------------------------------------
        public IntType Id { get; } = new IntType();

        //--------------------------------------------
        public StringType Name { get; } = new StringType();

        //--------------------------------------------
        public StringType OtherName { get; } = new StringType();



        //**************************************************
        //* Public
        //**************************************************

        //--------------------------------------------
        public User ToModel()
        {
            return new User
            {
                Id = Id.Value,
                Name = Name.Value,
                OtherName = OtherName.Value
            };
        }
        
    }
}