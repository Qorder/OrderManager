using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderManagerPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		public delegate void RemoveOrderEventHandler(object sender, OrderEventArgs e);
		
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			OrderVisualTemplate mock1 =new OrderVisualTemplate();
			mock1.removeEvent+=removeOrderEvent;
			this.InboxTreeView.Items.Add(mock1.OrderTemplate);
			this.InboxCounter.Content=this.InboxTreeView.Items.Count;
		}
				
	    private void InboxTreeView_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
	    {
			if(InboxTreeView.SelectedItem!=null)
			{
				OrderVisualTemplate mock1 =new OrderVisualTemplate();
				mock1.OrderTemplate = (Border)InboxTreeView.SelectedItem;
				InboxTreeView.Items.Remove(InboxTreeView.SelectedItem);
				this.ServicedTreeView.Items.Add(mock1.OrderTemplate);
			
				//TODO:Override treeview to create custom event for items.add / remove
				this.ServicedCounter.Content=this.ServicedTreeView.Items.Count;
				this.InboxCounter.Content=this.InboxTreeView.Items.Count;
			}
	    }

		#region Handle Events
		
		//TODO: review remove algorithm
	    void removeOrderEvent(object sender, EventArgs e)
        {
			OrderEventArgs eventArgs = (OrderEventArgs)e;
			
			for(int i=0;i<ServicedTreeView.Items.Count;i++)
			{
				if(ServicedTreeView.Items[i]==eventArgs.VTemplate.OrderTemplate)
				{
					ServicedTreeView.Items.RemoveAt(i);
					this.ServicedCounter.Content=this.ServicedTreeView.Items.Count;

					return;
				}
			}
			
			for(int i=0;i<InboxTreeView.Items.Count;i++)
			{
				if(InboxTreeView.Items[i]==eventArgs.VTemplate.OrderTemplate)
				{
					InboxTreeView.Items.RemoveAt(i);
					this.InboxCounter.Content=this.InboxTreeView.Items.Count;
					
					return;
				}
			}
		}
		
		#endregion
    }
}
