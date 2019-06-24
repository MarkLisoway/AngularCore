namespace BusinessLogic.CoreEntity.TypedCoreEntity
{
    public class StringType : TypedEntity<string>
    {
        
        //**************************************************
        //* Static initializer
        //**************************************************

        //--------------------------------------------
        public static StringType Empty => new StringType(string.Empty);


        //**************************************************
        //* Constructor
        //**************************************************

        //--------------------------------------------
        internal StringType(string value) : base(value)
        {
        }


        internal StringType() : base(EntityState.Unknown)
        {
        }



        //**************************************************
        //* Implicit operator
        //**************************************************

        //--------------------------------------------
        public static implicit operator StringType(string value)
        {
            return new StringType(value);
        }  
        
    }
}