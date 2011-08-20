using System;
using Gtk;
using omarkhd.DataStructures;

namespace omarkhd.Gymk
{
	[TreeNode(ListOnly = true)]
	public class Pack : TreeNode
	{
		public long Id;
		public IList<long> Areas; //areas ids
		
		[TreeNodeValue(Column = 0)]
		public string Name;
		
		public float Price;
		public float Membership;
		
		[TreeNodeValue(Column = 1)]
		public string PriceString { get { return string.Format("{0:C}", this.Price); }}
		[TreeNodeValue(Column = 2)]
		public string MembershipString { get { return string.Format("{0:C}", this.Membership); }}
		
		public Pack()
		{
		}
	}
}

