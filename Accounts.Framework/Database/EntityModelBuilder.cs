using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Accounts.Framework.Database
{
    public abstract class  EntityModelBuilder<T>
        where T : class
    {
        public EntityModelBuilder(ModelBuilder builder)
        {
            Build(builder.Entity<T>());
        }

        protected abstract void Build(EntityTypeBuilder<T> entity);
    }
}
