using System.Collections.Generic;

namespace BusinessLogic.CoreEntity.TypedCoreEntity
{
    public class ListType<T> : TypedEntity<List<T>>
    {
        
        //**************************************************
        //* Static initializer
        //**************************************************

        //--------------------------------------------
        public static ListType<T> Empty => new ListType<T>(new List<T>());

        

        //**************************************************
        //* Constructor
        //**************************************************

        //--------------------------------------------
        internal ListType(List<T> value) : base(value)
        {
        }


        internal ListType() : base(EntityState.Unknown)
        {
        }



        //**************************************************
        //* Implicit operator
        //**************************************************

        //--------------------------------------------

        public static implicit operator ListType<T>(List<T> value)
        {
            return new ListType<T>(value);
        }
    }
}