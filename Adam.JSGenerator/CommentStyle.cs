namespace Adam.JSGenerator
{
	/// <summary>
	/// Determines how comments are rendered.
	/// </summary>
	public enum CommentStyle
	{
		/// <summary>
		/// Automatically detect which ones are more appropriate.
		/// </summary>
		Auto,
		/// <summary>
		/// Prefixes every line of text in the source with '// '
		/// </summary>
		OneLineComments,
		/// <summary>
		/// Places the content of the comment between '/*' and '*/'.
		/// </summary>
		MultipleLineComments
	}
}