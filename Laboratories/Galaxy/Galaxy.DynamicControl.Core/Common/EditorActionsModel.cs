using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Galaxy.DynamicControl.Core.Common;

namespace Galaxy.DynamicControl.Core
{
    public class EditorActionsModel<TEntity>
    {
        public EditorActionsModel()
        {
            this.EditorAction = new List<EditorAction>();
        }
        public List<EditorAction> EditorAction
        {
            get; set;
        }
    }
}
