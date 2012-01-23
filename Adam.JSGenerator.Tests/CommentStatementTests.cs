using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Adam.JSGenerator.Tests
{
	[TestClass]
	public class CommentStatementTests
	{
		[TestMethod]
		public void CommentStatementProducesComment()
		{
			CommentStatement comment = new CommentStatement("Comment");

			Assert.AreEqual("/* Comment */", comment.ToString());
		}

		[TestMethod]
		public void CommentStatementProducesCommentWithPrefixes()
		{
			CommentStatement comment = new CommentStatement("Comment\r\nAndThenSome");

			Assert.AreEqual("// Comment\r\n// AndThenSome\r\n", comment.ToString());
		}

		[TestMethod]
		public void CommentStatementProducesCommentExplicitlyWithPrefixes()
		{
			CommentStatement comment = new CommentStatement("Comment")
			{
				AddExtraLineBreaks = true, 
				Style = CommentStyle.OneLineComments
			};

			Assert.AreEqual("\r\n// Comment\r\n", comment.ToString());
		}
	}
}