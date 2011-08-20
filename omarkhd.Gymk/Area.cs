using System;
using Gtk;

namespace omarkhd.Gymk
{
	[TreeNode(ListOnly = true)]
	public class Area : TreeNode
	{
		public long Id;
		
		[TreeNodeValue(Column = 0)]
		public string Name;
		
		public Area()
		{
			
		}
	}
}

