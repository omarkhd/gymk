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
		
		public bool Sync()
		{
			User user = UserModel.FromId(this.Id);
			if(user == null)
				return false;
				
			this.Alias = user.Alias;
			this.Password = user.Password;
			this.Name = user.Name;
			this.Admin = user.Admin;
			this.Active = user.Active;
			return true;
		}
	}
}

