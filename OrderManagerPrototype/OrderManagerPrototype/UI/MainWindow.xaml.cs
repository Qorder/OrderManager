using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    using Events;
    using Updater;
    using Model;
    using Templates;

    public partial class MainWindow : Window
    {
        Requester requester;
        Thread requesterThread;

        public MainWindow()
        {
            InitializeComponent();
            AdjustTreeWidth();
            this.MinWidth = this.Width;
            this.MinHeight = 500;
            requester = new Requester("http://snf-185147.vm.okeanos.grnet.gr:8080/qorderws/orders/business/1/order?status=PENDING");
            //requester = new Requester("http://83.212.118.113/mockJsons/mockCategoryJson.json");

            requesterThread = new Thread(
                o =>
                {
                    while (true)
                    {
                        while (!requester.Flag)
                        {
                            requester.Update();
                        }
                        requester.Flag = false;
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            foreach (Order order in requester.orders)
                            {
                                DynamicVisualTemplate mock1 = new DynamicVisualTemplate(order);
                                mock1.removeEvent += removeOrderEvent;
                                this.InboxView.Items.Add(mock1.OrderTemplate);
                            }
                            this.InboxCounter.Content = this.InboxView.Items.Count;
                        }));
                    }
                });
            requesterThread.Start();

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            List<Product> products =  new List<Product>();
            products.Add(new Product("name",1.1,"notes",2));
            products.Add(new Product("name2", 1.12, "this is a really really long message",1));
            DynamicVisualTemplate mock1 = new DynamicVisualTemplate(new Order(1,"1","16.00 - 1/1/2006",products));
			mock1.removeEvent+=removeOrderEvent;
			this.InboxView.Items.Add(mock1.OrderTemplate);
			this.InboxCounter.Content=this.InboxView.Items.Count;
		}
				
	    private void InboxView_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
	    {
            SwitchOrderTree();
	    }

		#region Handle Events
		
     		//TODO: review remove algorithm
	    void removeOrderEvent(object sender, EventArgs e)
        {
			OrderEventArgs eventArgs = (OrderEventArgs)e;

			for(int i=0;i<ServicedView.Items.Count;i++)
			{
				if(ServicedView.Items[i]==eventArgs.VTemplate.OrderTemplate)
				{
					ServicedView.Items.RemoveAt(i);
					this.ServicedCounter.Content=this.ServicedView.Items.Count;

					return;
				}
			}
			
			for(int i=0;i<InboxView.Items.Count;i++)
			{
				if(InboxView.Items[i]==eventArgs.VTemplate.OrderTemplate)
				{
					InboxView.Items.RemoveAt(i);
                    OrderHolder.RemoveOrderWithID(eventArgs.VTemplate.ID);
					this.InboxCounter.Content=this.InboxView.Items.Count;
					
					return;
				}
			}
		}

        //TODO: include system.windows.forms 
        /*Maximize event
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                if (m.WParam == new IntPtr(0xF030))
                {
                     AdjustTreeWidth();
                }
            }
            base.WndProc(ref m);
        }*/

        #endregion

        #region Helper Methods

        private void AdjustTreeWidth()
        {
            InboxView.Width = this.Width / 2 - 20;
            ServicedView.Width = this.Width / 2 - 20;
        }

        private void SwitchOrderTree()
        {
            if (InboxView.SelectedItem != null)
            {
                
                ITemplate mock1 = new DynamicVisualTemplate();
                mock1.OrderTemplate = (Border)InboxView.SelectedItem;
                NetworkUtil.NotifyWebService((int)mock1.ID);
                OrderHolder.RemoveOrderWithID(mock1.ID);
                InboxView.Items.Remove(InboxView.SelectedItem);
                this.ServicedView.Items.Add(mock1.OrderTemplate);
                //TODO:Override the view control to create custom event for items.add / remove
                this.ServicedCounter.Content = this.ServicedView.Items.Count;
                this.InboxCounter.Content = this.InboxView.Items.Count;
               // this.InboxView.SelectedIndex = -1;
            }

        }
        #endregion

        private void OrderManager_Closed(object sender, EventArgs e)
        {
            requesterThread.Abort();
        }

        private void OrderManager_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustTreeWidth();
        }

        private void InboxView_TouchUp(object sender, TouchEventArgs e)
        {
            SwitchOrderTree();
        }

    }
}
