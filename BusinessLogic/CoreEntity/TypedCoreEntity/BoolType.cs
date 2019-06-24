namespace BusinessLogic.CoreEntity.TypedCoreEntity
{
    public class BoolType : TypedEntity<bool>
    {
        
        //**************************************************
        //* Static initializer
        //**************************************************

        //--------------------------------------------
        public static BoolType True => new BoolType(true);

        //--------------------------------------------
        public static BoolType False => new BoolType(false);


        //**************************************************
        //* Constructor
        //**************************************************

        //--------------------------------------------
        internal BoolType(bool value) : base(value)
        {
        }


        internal BoolType() : base(EntityState.Unknown)
        {
        }



        //**************************************************
        //* Implicit operator
        //**************************************************

        //--------------------------------------------
        public static implicit operator BoolType(bool value)
        {
            return new BoolType(value);
        }
        
    }
}