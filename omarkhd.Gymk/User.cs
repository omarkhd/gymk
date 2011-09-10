using System;
using Gtk;

namespace omarkhd.Gymk
{
	[TreeNode(ListOnly = true)]
	public class User : Gtk.TreeNode
	{
		public long Id;
		[TreeNodeValue(Column = 0)]
		public string Alias;
		public string Password;
		public string Name;
		public bool Admin;
		public bool Active;
		
		public User()
		{
			
		}
	}
}

