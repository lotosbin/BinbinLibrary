using System.Linq.Expressions;

namespace Binbin.Linq.Dynamic
{
    internal class DynamicOrdering
    {
        public Expression Selector;
        public bool Ascending;
    }
}