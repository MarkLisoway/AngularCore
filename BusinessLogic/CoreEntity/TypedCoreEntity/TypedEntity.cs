using System;
using System.Collections.Generic;

namespace BusinessLogic.CoreEntity.TypedCoreEntity
{
    public class TypedEntity<T> : IEntity<T>, IEquatable<T>
    {
    
        ///**************************************************
        //* Property
        //**************************************************
        public T Value { get; }
        
        public EntityState State { get; private set; }

        public bool HasValue => State == EntityState.Set;
        
        

        //**************************************************
        //* Static initializer
        //**************************************************

        //--------------------------------------------
        public static TypedEntity<T> Unknown => new TypedEntity<T>(EntityState.Unknown);
        
        //--------------------------------------------
        public static TypedEntity<T> NotSet => new TypedEntity<T>(EntityState.NotSet);
        
        //--------------------------------------------
        public static TypedEntity<T> Null => new TypedEntity<T>(EntityState.NotSet);



        //**************************************************
        //* Constructor
        //**************************************************

        //--------------------------------------------
        internal TypedEntity(T value, EntityState state)
        {
            VerifyValueTypeIsSupported(value);
            
            Value = value;
            State = state;
        }


        //--------------------------------------------
        internal TypedEntity(T value): this(value, GetStateBasedOnValue(value))
        {
        }


        //--------------------------------------------
        internal TypedEntity(EntityState state)
        {
            State = state;
        }



        //**************************************************
        //* Private
        //**************************************************

        //--------------------------------------------
        private static EntityState GetStateBasedOnValue(T value)
        {
            if (value == null)
            {
                return EntityState.Null;
            }

            var valueType = typeof(T);
            return valueType.IsPrimitive
                ? EntityState.Set
                : EntityState.Unknown;
        }


        //--------------------------------------------
        private static void VerifyValueTypeIsSupported(T value)
        {
            var valueType = typeof(T);
            if (valueType.IsPrimitive || valueType.IsArray || valueType.IsClass)
            {
                return;
            }
            
            throw new ArgumentException($"{nameof(value)} is of unsupported type {valueType.Name}.");
        }


        //--------------------------------------------
        public virtual bool Equals(T other)
        {
            return HasValue && Value.Equals(other);
        }
        
    }
}