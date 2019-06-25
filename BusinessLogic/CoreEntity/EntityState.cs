namespace BusinessLogic.CoreEntity
{

    /// <summary>
    ///     Represents the state of an entity.
    /// </summary>
    public enum EntityState
    {

        /// <summary>
        ///     Means the entity could, or could not have a set state.
        ///     This state can occur if the entity was attempted to be loaded with an
        ///     object or value that was in an unexpected state.
        ///     This state could also occur if an exception occurs during value load,
        ///     and it is uncertain whether or not a valid value was set.
        ///     Essentially this state will occur when something unexpected happens that
        ///     results in the value of the entity being unknown.
        ///     This is the default state of any entity.
        /// </summary>
        Unknown,

        /// <summary>
        ///     Means the entity has been deliberately set into a null state.
        ///     Any attempt to get the value in this state will return null,
        ///     or default for value types.
        /// </summary>
        Null,

        /// <summary>
        ///     Means there has been no attempt to set the entity's value. Any attempt to use the value
        ///     while the entity is in this state will result in a null, or default value.
        /// </summary>
        NotSet,

        /// <summary>
        ///     Means the entity has a value, and any implementations can assume
        ///     the value will not be null.
        /// </summary>
        Set

    }

}
