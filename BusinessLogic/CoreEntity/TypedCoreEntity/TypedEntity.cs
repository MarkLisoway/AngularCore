using System;
using System.Collections.Generic;

namespace BusinessLogic.CoreEntity.TypedCoreEntity
{

    /// <summary>
    ///     A wrapper around a given type to hold, manage state,
    ///     as well as provide equality, and comparison interface & operator implementations.
    /// </summary>
    /// <typeparam name="T">Value type this wrapper wraps.</typeparam>
    public class TypedEntity<T> : IEntity<T>, IComparable<TypedEntity<T>>, IComparable<T>, IComparable,
        IEquatable<TypedEntity<T>>, IEquatable<T>
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
            if (value == null)
            {
                throw new ArgumentException(nameof(value));
            }

            Value = value;
            State = EntityState.Set;
        }

        //**************************************************
        //* Static initializers
        //**************************************************

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="TypedEntity{T}" /> in the Unknown state.
        /// </summary>
        public static TypedEntity<T> Unknown => new TypedEntity<T>(default, EntityState.Unknown);

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="TypedEntity{T}" /> in the NotSet state.
        /// </summary>
        public static TypedEntity<T> NotSet => new TypedEntity<T>(default, EntityState.NotSet);

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="TypedEntity{T}" /> in the Null state.
        /// </summary>
        public static TypedEntity<T> Null => new TypedEntity<T>(default, EntityState.Null);



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



        //**************************************************
        //* Comparison operators
        //**************************************************

        //--------------------------------------------------
        public static bool operator ==(TypedEntity<T> left, TypedEntity<T> right)
        {
            if (left is null)
            {
                throw new ArgumentException(nameof(left));
            }

            if (right is null)
            {
                throw new ArgumentException(nameof(right));
            }

            return left.Equals(right);
        }

        //--------------------------------------------------
        public static bool operator !=(TypedEntity<T> left, TypedEntity<T> right)
        {
            return !(left == right);
        }

        //--------------------------------------------------
        public static bool operator >(TypedEntity<T> left, TypedEntity<T> right)
        {
            if (left == null)
            {
                throw new ArgumentException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentException(nameof(right));
            }

            var comparison = left.CompareTo(right);

            switch (comparison)
            {
                case 1:
                    return true;
                case 0:
                case -1:
                    return false;
                default:
                    throw new InvalidOperationException("Comparison returned value other than 1, 0, or -1.");
            }
        }

        //--------------------------------------------------
        public static bool operator <(TypedEntity<T> left, TypedEntity<T> right)
        {
            return !(left > right);
        }

        //--------------------------------------------------
        public static bool operator >=(TypedEntity<T> left, TypedEntity<T> right)
        {
            if (left == null)
            {
                throw new ArgumentException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentException(nameof(right));
            }

            var comparison = left.CompareTo(right);

            switch (comparison)
            {
                case 1:
                case 0:
                    return true;
                case -1:
                    return false;
                default:
                    throw new InvalidOperationException("Comparison returned value other than 1, 0, or -1.");
            }
        }

        //--------------------------------------------------
        public static bool operator <=(TypedEntity<T> left, TypedEntity<T> right)
        {
            return !(left >= right);
        }

    }

}
