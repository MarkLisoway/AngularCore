using System;
using System.Collections.Generic;

namespace BusinessLogic.CoreEntity.TypedCoreEntity
{

    /// <summary>
    ///     A wrapper around a given type to hold, and manage state,
    ///     as well as provide equality, and comparison interface implementations.
    /// </summary>
    /// <typeparam name="T">Value type this wrapper wraps.</typeparam>
    public class TypedEntity<T> : IEntity<T>, IComparable<TypedEntity<T>>, IComparable<T>, IComparable,
        IEquatable<TypedEntity<T>>, IEquatable<T>
        where T : class
    {

        //**************************************************
        //* Constructors
        //**************************************************

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="TypedEntity{T}" /> with the given value, and state.
        /// </summary>
        /// <param name="value">Value of the entity.</param>
        /// <param name="state">State of the entity.</param>
        protected TypedEntity(T value, EntityState state)
        {
            Value = value;
            State = state;
        }

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="TypedEntity{T}" /> with the given value.
        /// </summary>
        /// <remarks>
        ///     Given value cannot be null.
        /// </remarks>
        /// <param name="value">Value of the entity.</param>
        /// <exception cref="ArgumentException">Thrown when given value is null.</exception>
        public TypedEntity(T value)
        {
            Value = value ?? throw new ArgumentException(nameof(value));
            State = EntityState.Set;
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
        //* IComparable<T> overrides
        //**************************************************

        //--------------------------------------------------
        public int CompareTo(T other)
        {
            return CompareTo(new TypedEntity<T>(other));
        }


        //--------------------------------------------------
        /// <inheritdoc />
        /// <remarks>
        ///     Should be overridden in extending classes to ensure correct comparisons.
        /// </remarks>
        public virtual int CompareTo(TypedEntity<T> other)
        {
            if (IsSet)
            {
                return !other.IsSet
                    ? 1
                    : 0;
            }

            if (!other.IsSet)
            {
                return State == other.State
                    ? 0
                    : State > other.State
                        ? 1
                        : -1;
            }

            return -1;
        }



        //**************************************************
        //* IEntity<T> overrides
        //**************************************************

        //--------------------------------------------------
        public T Value { get; }

        //--------------------------------------------------
        public EntityState State { get; }

        //--------------------------------------------------
        public bool IsUnknown => State == EntityState.Unknown;

        //--------------------------------------------------
        public bool IsNotSet => State == EntityState.NotSet;

        //--------------------------------------------------
        public bool IsSet => State == EntityState.Set;

        //--------------------------------------------------
        public bool IsNull => State == EntityState.Null;



        //**************************************************
        //* IEquatable<T> overrides
        //**************************************************

        //--------------------------------------------------
        public bool Equals(T other)
        {
            return Equals(new TypedEntity<T>(other));
        }

        //--------------------------------------------------
        public virtual bool Equals(TypedEntity<T> other)
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

        //--------------------------------------------------
        public override int GetHashCode()
        {
            if (IsUnknown)
            {
                return -3;
            }

            if (IsNotSet)
            {
                return -2;
            }

            if (IsNull)
            {
                return -1;
            }

            unchecked
            {
                var hashCode = EqualityComparer<T>.Default.GetHashCode(Value);
                hashCode = (hashCode * 397) ^ EqualityComparer<T>.Default.GetHashCode(Value);
                hashCode = (hashCode * 397) ^ (int) State;

                return hashCode;
            }
        }

    }

}
