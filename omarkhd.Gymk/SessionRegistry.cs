using System;
using omarkhd.DataStructures;

namespace omarkhd.Gymk
{
	public class SessionRegistry
	{
		private static SessionRegistry Instance;
		private IList<RegistryNode> Container;
		
		static SessionRegistry()
		{
			Instance = null;
		}
		
		private SessionRegistry ()
		{
			this.Container = new ArrayList<RegistryNode>(); //
		}
		
		public static SessionRegistry GetInstance()
		{
			if(SessionRegistry.Instance == null)
				SessionRegistry.Instance = new SessionRegistry();
			return SessionRegistry.Instance;
		}
		
		private RegistryNode GetNode(string key)
		{
			for(int i = 0; i < this.Container.Length; i++)
				if(this.Container[i].Key == key)
					return this.Container[i];
			return null;
		}
		
		public void Set(string key, object val)
		{
			RegistryNode node = this.GetNode(key);
			if(node == null)
				this.Container.Add(new RegistryNode(key, val));
			else
				node.Value = val;
		}
		
		public object Get(string key)
		{
			RegistryNode node = this.GetNode(key);
			if(node == null)
				return null;
			else
				return node.Value;
		}
		
		public object this[string key]
		{
			get { return this.Get(key); }
			set { this.Set(key, value); }
		}
		
		//innerclass for nodes
		class RegistryNode
		{
			public string Key;
			public object Value;
			
			public RegistryNode(string key, object val)
			{
				this.Key = key;
				this.Value = val;
			}
		}
	}
}

