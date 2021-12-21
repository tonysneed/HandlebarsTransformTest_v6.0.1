using System;
namespace EntityFrameworkCore.Scaffolding.Handlebars
{
    /// <summary>
    /// Default service for transforming entity type definitions.
    /// </summary>
    public class HbsEntityTypeTransformationService : HbsEntityTypeTransformationServiceBase
    {
        /// <summary>
        /// Entity name transformer.
        /// </summary>
        public new Func<string, string> EntityTypeNameTransformer { get => base.EntityTypeNameTransformer; }

        /// <summary>
        /// Entity file name transformer.
        /// </summary>
        public new Func<string, string> EntityFileNameTransformer { get => base.EntityFileNameTransformer; }

        /// <summary>
        /// Constructor transformer.
        /// </summary>
        public new Func<EntityPropertyInfo, EntityPropertyInfo> ConstructorTransformer { get => base.ConstructorTransformer; }

        /// <summary>
        /// Property name transformer.
        /// </summary>
        public new Func<EntityPropertyInfo, EntityPropertyInfo> PropertyTransformer { get => base.PropertyTransformer;  }

        /// <summary>
        /// Navigation property name transformer.
        /// </summary>
        public new Func<EntityPropertyInfo, EntityPropertyInfo> NavPropertyTransformer { get => base.NavPropertyTransformer;  }

        /// <summary>
        /// HbsEntityTypeTransformationService constructor.
        /// </summary>
        /// <param name="entityTypeNameTransformer">Entity type name transformer.</param>
        /// <param name="entityFileNameTransformer">Entity file name transformer.</param>
        /// <param name="constructorTransformer">Constructor transformer.</param>
        /// <param name="propertyTransformer">Property name transformer.</param>
        /// <param name="navPropertyTransformer">Navigation property name transformer.</param>
        public HbsEntityTypeTransformationService(
            Func<string, string> entityTypeNameTransformer = null,
            Func<string, string> entityFileNameTransformer = null,
            Func<EntityPropertyInfo, EntityPropertyInfo> constructorTransformer = null,
            Func<EntityPropertyInfo, EntityPropertyInfo> propertyTransformer = null,
            Func<EntityPropertyInfo, EntityPropertyInfo> navPropertyTransformer = null)
                : base(entityTypeNameTransformer, entityFileNameTransformer)
        {
            base.ConstructorTransformer = constructorTransformer;
            base.PropertyTransformer = propertyTransformer;
            base.NavPropertyTransformer = navPropertyTransformer;
        }
    }
}