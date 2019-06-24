using System;
using System.Collections.Generic;



namespace BusinessLogic.CoreEntity.TypedCoreEntity
{

    public class TypedEntity<T> : IEntity<T>, IComparable<TypedEntity<T>>, IComparable<T>, IComparable,
        IEquatable<TypedEntity<T>>, IEquatable<T>
        where T : class
    {

        //**************************************************
        //* Constructors
        //**************************************************

        //--------------------------------------------------
        public TypedEntity(T value)
        {
            _value = value ?? throw new ArgumentException(nameof(value));
            State = EntityState.Set;
        }



        //**************************************************
        //* IEntity<T> overrides
        //**************************************************

        //--------------------------------------------------
        /// <inheritdoc />
        public T Value { get; }

        //--------------------------------------------------
        /// <inheritdoc />
        public EntityState State { get; }

        //--------------------------------------------------
        /// <inheritdoc />
        public bool IsUnknown => State == EntityState.Unknown;

        //--------------------------------------------------
        /// <inheritdoc />
        public bool IsNotSet => State == EntityState.NotSet;

        //--------------------------------------------------
        /// <inheritdoc />
        public bool IsSet => State == EntityState.Set;

        //--------------------------------------------------
        /// <inheritdoc />
        public bool IsNull => State == EntityState.Null;



        //**************************************************
        //* IComparable<T> overrides
        //**************************************************

        //--------------------------------------------------
        public virtual int CompareTo(T other)
        {
            return CompareTo(new TypedEntity<T>(other));
        }


        //--------------------------------------------------
        public int CompareTo(TypedEntity<T> other)
        {
            if (!IsSet)
            {
                if (!other.IsSet)
                {
                    return State - other.State;
                }

                return -1;
            }

            if (!other.IsSet)
            {
                return 1;
            }
        }



        //**************************************************
        //* IComparable overrides
        //**************************************************

        //--------------------------------------------------
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case T objT:
                    return CompareTo(objT);
                case TypedEntity<T> objTe:
                    return CompareTo(objTe);
                default:
                    throw new ArgumentException($"{nameof(obj)} not of type {nameof(T)}, or {nameof(TypedEntity<T>)}");
            }
        }



        //**************************************************
        //* IEquatable<T> overrides
        //**************************************************

        //--------------------------------------------------
        public bool Equals(T other)
        {
            return Equals(new TypedEntity<T>(other));
        }

        //--------------------------------------------------
        public bool Equals(TypedEntity<T> other)
        {
            return CompareTo(other) == 0;
        }



        //**************************************************
        //* Object overrides
        //**************************************************

        //--------------------------------------------------
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case T objT:
                    return Equals(objT);
                case TypedEntity<T> objTe:
                    return Equals(objTe);
                default:
                    throw new ArgumentException($"{nameof(obj)} not of type {nameof(T)}, or {nameof(TypedEntity<T>)}");
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EqualityComparer<T>.Default.GetHashCode(_value);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Value);
                hashCode = (hashCode * 397) ^ (int) State;
                return hashCode;
            }
        }



        //**************************************************
        //* Private
        //**************************************************

        //--------------------------------------------------
        private readonly T _value;

    }

}