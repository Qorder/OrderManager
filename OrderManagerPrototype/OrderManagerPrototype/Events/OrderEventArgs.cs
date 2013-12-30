using System;

namespace OrderManagerPrototype.Events
{
    using Templates;

	public class OrderEventArgs : EventArgs
	{
   		public DynamicVisualTemplate VTemplate
		{
			get;
			private set;
		}


        public OrderEventArgs(DynamicVisualTemplate vTemplate)
 	    {
			this.VTemplate=vTemplate;
 		}
	}
}