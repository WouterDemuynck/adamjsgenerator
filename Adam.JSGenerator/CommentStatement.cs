using System;
using System.Text;

namespace Adam.JSGenerator
{
	/// <summary>
	/// A statement that includes a piece of text as comment.
	/// </summary>
	public class CommentStatement : Statement
	{
		/// <summary>
		/// Gets or sets the content of the comment.
		/// </summary>
		/// <value>
		/// The content of the comment.
		/// </value>
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the comment's rendering style.
		/// </summary>
		/// <value>
		/// The comment's rendering style.
		/// </value>
		public CommentStyle Style { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether extra line breaks are added before and after the comment, to improve readability.
		/// </summary>
		/// <value>
		///   <c>true</c> if extra line breaks are added; otherwise, <c>false</c>.
		/// </value>
		public bool AddExtraLineBreaks { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CommentStatement"/> class.
		/// </summary>
		/// <param name="content">The content of the comment.</param>
		public CommentStatement(string content)
		{
			Content = content;
		}

		/// <summary>
		/// Appends the script to represent the comment to the StringBuilder.
		/// </summary>
		/// <param name="builder">The StringBuilder to which the comment is appended.</param>
		/// <param name="options">The options to use when appending JavaScript</param>
		protected internal override void AppendScript(StringBuilder builder, ScriptOptions options)
		{
			if (AddExtraLineBreaks)
			{
				builder.AppendLine();
			}

			CommentStyle style = Style;

			if (style == CommentStyle.Auto)
			{
				style = Content.Contains("/*") || Content.Contains("*/") || Content.Contains("\r\n") 
					? CommentStyle.OneLineComments 
					: CommentStyle.MultipleLineComments;
			}

			switch (style)
			{
				case CommentStyle.OneLineComments:
					foreach (var line in Content.Split(new[] { "\r\n"}, StringSplitOptions.None))
					{
						builder.Append("// ");
						builder.AppendLine(line);
					}
					break;
				case CommentStyle.MultipleLineComments:
					builder.Append("/* ");
					builder.Append(Content);
					builder.Append(" */");
					if (AddExtraLineBreaks)
					{
						builder.AppendLine();
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

		}
	}
}