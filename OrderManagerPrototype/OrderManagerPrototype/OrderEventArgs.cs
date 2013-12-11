using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderManagerPrototype
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