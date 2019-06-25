namespace BusinessLogic.CoreEntity.TypedCoreEntity
{

    public class BoolType : TypedEntity<bool>
    {
        
        //**************************************************
        //* Constructors
        //**************************************************

        //--------------------------------------------------
        /// <inheritdoc />
        private BoolType(bool value, EntityState state)
            : base(value, state)
        {
        }

        //--------------------------------------------------
        /// <inheritdoc />
        private BoolType(bool value)
            : base(value)
        {
        }



        //**************************************************
        //* Static initializers
        //**************************************************

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="BoolType"/> in the Set state with a value of true.
        /// </summary>
        public static BoolType True => new BoolType(true);

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="BoolType"/> in the Set state with a value of false.
        /// </summary>
        public static BoolType False => new BoolType(false);

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="BoolType"/> in the Unknown state.
        /// </summary>
        public new static BoolType Unknown => new BoolType(default, EntityState.Unknown);

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="BoolType" /> in the NotSet state.
        /// </summary>
        public new static BoolType NotSet => new BoolType(default, EntityState.NotSet);

        //--------------------------------------------------
        /// <summary>
        ///     Creates a new <see cref="BoolType" /> in the Null state.
        /// </summary>
        public new static BoolType Null => new BoolType(default, EntityState.Null);



        //**************************************************
        //* TypedEntity<T> overrides
        //**************************************************

        //--------------------------------------------------
        /// <inheritdoc />
        /// <returns>
        ///     <para>1 if true, and other false.</para>
        ///     <para>0 if equal.</para>
        ///     <para>-1 if false, and other true.</para>
        /// </returns>
        public override int CompareTo(TypedEntity<bool> other)
        {
            if (!IsSet || !other.IsSet)
            {
                return base.CompareTo(other);
            }

            if (Value == other.Value)
            {
                return 0;
            }

            if (Value)
            {
                return 1;
            }

            return -1;
        }

    }

}
