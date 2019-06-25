namespace BusinessLogic.CoreEntity
{

    /// <summary>
    ///     Represents a generic typed entity, with the ability to perform
    ///     type safe, and conditionally safe actions based on the entity's <see cref="EntityState" />.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public interface IEntity<out T>
    {

        //**************************************************
        //* Properties
        //**************************************************

        //--------------------------------------------------
        /// <summary>
        ///     Value of the entity.
        /// </summary>
        T Value { get; }

        //--------------------------------------------------
        /// <summary>
        ///     State of the entity.
        /// </summary>
        EntityState State { get; }

        //--------------------------------------------------
        /// <summary>
        ///     Is the entity's value unknown.
        /// </summary>
        bool IsUnknown { get; }

        //--------------------------------------------------
        /// <summary>
        ///     Is the entity's value not set.
        /// </summary>
        bool IsNotSet { get; }

        //--------------------------------------------------
        /// <summary>
        ///     Is the entity's value set.
        /// </summary>
        bool IsSet { get; }

        //--------------------------------------------------
        /// <summary>
        ///     Is the entity's value null.
        /// </summary>
        bool IsNull { get; }

    }

}
