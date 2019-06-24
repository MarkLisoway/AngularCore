namespace BusinessLogic.CoreEntity.TypedCoreEntity
{
    public class IntType : TypedEntity<int>
    {
        
        //**************************************************
        //* Static initializer
        //**************************************************

        //--------------------------------------------
        public static IntType Max => new IntType(int.MaxValue);

        //--------------------------------------------
        public static IntType Min => new IntType(int.MinValue);


        //**************************************************
        //* Constructor
        //**************************************************

        //--------------------------------------------
        internal IntType(int value) : base(value)
        {
        }


        internal IntType() : base(EntityState.Unknown)
        {
        }



        //**************************************************
        //* Implicit operator
        //**************************************************

        //--------------------------------------------
        public static implicit operator IntType(int value)
        {
            return new IntType(value);
        }
        
    }
}