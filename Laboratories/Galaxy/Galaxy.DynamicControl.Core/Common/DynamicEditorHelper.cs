using System;
using System.Windows;

namespace Galaxy.DynamicControl.Core.Common
{
    public class DynamicEditorHelper<TEntity>
    {
        public EditorProfile<TEntity> EditorProfile
        {
            get;
            set;
        }

        public EditorControl EditorControl
        {
            get;
            set;
        }

        public void Initialize(Window windowUserInfo)
        {
            
        }
    }
}
