using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BusinessLogic
{
    internal static class ServiceEndpointExtensions
    {
        internal static void ApplyModificationFlags<TModel>(this EntityEntry<TModel> entry,
            params Expression<Func<TModel, object>>[] updatedProperties)
            where TModel : class
        {
            if (updatedProperties.Any())
            {
                foreach (var updatedProperty in updatedProperties)
                {
                    entry.Property(updatedProperty).IsModified = true;
                }
            }
            else
            {
                foreach (var property in entry.OriginalValues.Properties)
                {
                    var original = entry.OriginalValues.GetValue<object>(property.Name);
                    var current = entry.CurrentValues.GetValue<object>(property.Name);
                    if (!Equals(original, current))
                    {
                        entry.Property(property.Name).IsModified = true;
                    }
                }
            }
        }
    }
}