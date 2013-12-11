using System;

namespace OrderManagerPrototype.Events
{
	public class OrderEventArgs : EventArgs
	{
   		public OrderVisualTemplate VTemplate
		{
			get;
			private set;
		}
		
		
 		public OrderEventArgs(OrderVisualTemplate vTemplate)
 	    {
			this.VTemplate=vTemplate;
 		}
	}
}