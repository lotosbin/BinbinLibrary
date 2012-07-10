using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BinbinEntityFrameworkExtension
{
    public class UpgradeIfModelChanges<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        #region Implementation of IDatabaseInitializer<in T>

        /// <summary>
        /// Executes the strategy to initialize the database for the given context.
        /// </summary>
        /// <param name="context">The context.</param>
        public void InitializeDatabase(TContext context)
        {
            bool flag;
            using (new TransactionScope(TransactionScopeOption.Suppress))
                flag = context.Database.Exists();
            if (flag)
            {
                if (context.Database.CompatibleWithModel(true))
                    return;
                context.Database.Delete();
            }
            context.Database.Create();
            this.Seed(context);
            context.SaveChanges();
        }

        #endregion
        /// <summary>
        /// A that should be overridden to actually add data to the context for seeding.
        ///             The default implementation does nothing.
        /// 
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected virtual void Seed(TContext context)
        {
        }
    }
}
