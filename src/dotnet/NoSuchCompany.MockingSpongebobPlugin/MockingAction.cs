using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.TextControl;
using JetBrains.Util;
using NoSuchCompany.ReSharper.MockingSpongebobPlugin.Text;

namespace NoSuchCompany.ReSharper.MockingSpongebobPlugin
{
    #region Classes

    [ContextAction
    (
        Name = "Mocking",
        Description = "Make the specified comment a bit more sarcastic.",
        Group = "C#",
        Disabled = false,
        Priority = 1
    )]
    public class MockingContextAction : ContextActionBase
    {
        #region Constants

        private readonly IComment _selectedComment;

        #endregion

        #region Properties

        public override string Text => "Use sarcasm";

        #endregion

        #region Constructors

        public MockingContextAction(LanguageIndependentContextActionDataProvider dataProvider)
        {
            var selectedComment = dataProvider.GetSelectedElement<IComment>();

            _selectedComment = selectedComment != null && !(selectedComment.Parent is IDocCommentBlock) ? selectedComment : null;
        }

        #endregion

        #region Public Methods

        public override bool IsAvailable(IUserDataHolder cache)
        {
            return _selectedComment != null;
        }

        #endregion

        #region Protected Methods

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var commentNode = (ICommentNode)_selectedComment;

            var sarcasticSpongeBobComment = _selectedComment.CommentText.AsSpongeBob();

            var factory = CSharpElementFactory.GetInstance(_selectedComment.GetPsiModule());
            
            ICSharpCommentNode newComment = factory.CreateComment("//" + sarcasticSpongeBobComment);

            using (WriteLockCookie.Create(commentNode.Parent!.IsPhysical()))
            {
                ModificationUtil.ReplaceChild(commentNode, newComment);
            }

            return null;
        }

        #endregion
    }

    #endregion
}