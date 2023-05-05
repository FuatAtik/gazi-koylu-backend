using System;
using Microsoft.AspNetCore.Identity;
using Taigate.Core;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data
{
      /// <summary>
    /// Represents extensions
    /// </summary>
    public static class EntityExtensions
    {
        /// <summary>
        /// Check whether an entity is proxy
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Result</returns>
        private static bool IsProxy(this BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var type = entity.GetType();
            return type.BaseType != null && type.BaseType.BaseType != null && type.BaseType.BaseType == typeof(BaseEntity);
        }

        /// <summary>
        /// Get unproxied entity type
        /// </summary>
        /// <remarks> If your Entity Framework context is proxy-enabled, 
        /// the runtime will create a proxy instance of your entities, 
        /// i.e. a dynamically generated class which inherits from your entity class 
        /// and overrides its virtual properties by inserting specific code useful for example 
        /// for tracking changes and lazy loading.
        /// </remarks>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static Type GetUnproxiedEntityType(this BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Type type = null;
            // //cachable entity (get the base entity type)
            // if (entity is IEntityForCaching)
            //     type = ((IEntityForCaching)entity).GetType().BaseType;
            //EF proxy
            if (entity.IsProxy())
                type = entity.GetType().BaseType;
            //not proxied entity
            else
                type = entity.GetType();

            if (type == null)
                throw new Exception("Original entity type cannot be loaded");

            return type;
        }
        public static Type GetUnproxiedEntityType(this IdentityUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Type type = null;
            // //cachable entity (get the base entity type)
            // if (entity is IEntityForCaching)
            //     type = ((IEntityForCaching)entity).GetType().BaseType;
            //EF proxy
            type = entity.GetType();

            if (type == null)
                throw new Exception("Original entity type cannot be loaded");

            return type;
        }
    }
}