using System.Collections.Generic;

namespace Galaxy.DynamicControl.Core.Common
{
    public class EditorProfile<TEntity>
    {
        public EditorProfile()
        {
        }

        public EditorProfile(EditorFieldsModel<TEntity> editorFieldsModel, EditorLayout<TEntity> editorLayout, EditorActionsModel<TEntity> editorActionsModel)
        {
            EditorLayout = editorLayout;
            EditorActionsModel = editorActionsModel;
            EditorFieldsModel = editorFieldsModel;
        }

        public EditorLayout<TEntity> EditorLayout
        {
            get;
            set;
        }

        public EditorActionsModel<TEntity> EditorActionsModel
        {
            get;
            set;
        }

        public EditorFieldsModel<TEntity> EditorFieldsModel
        {
            get;
            set;
        }
    }
}
