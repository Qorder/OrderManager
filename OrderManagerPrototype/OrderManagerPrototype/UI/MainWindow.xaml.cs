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
           //requester = new Requester("http://snf-185147.vm.okeanos.grnet.gr:8080/qorderws/businesses/menus/business?id=0");
            requester = new Requester("http://83.212.118.113/mockJsons/mockCategoryJson.json");

            requesterThread = new Thread(
                o =>
                {
                    while(true)
                    { 
                    while (!requester.Flag)
                    {
                         requester.Update();
                    }
                    requester.Flag = false;
                    this.Dispatcher.BeginInvoke((Action)(() => {      
                        foreach (Product product in requester.products)
                        {
                            OrderVisualTemplate mock1 = new OrderVisualTemplate(product);
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
			OrderVisualTemplate mock1 =new OrderVisualTemplate();
			mock1.removeEvent+=removeOrderEvent;
			this.InboxView.Items.Add(mock1.OrderTemplate);
			this.InboxCounter.Content=this.InboxView.Items.Count;
		}
				
	    private void InboxView_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
	    {
            SwitchOrderTree();
	    }

		#region Handle Events
		
        void addNewProductEvent(object sender, EventArgs e)
        {
            OrderVisualTemplate mock1 = new OrderVisualTemplate();
            mock1.removeEvent += removeOrderEvent;
            this.InboxView.Dispatcher.BeginInvoke(
           (Action)(() =>
           {
               this.InboxView.Items.Add(mock1.OrderTemplate);
               this.InboxCounter.Content = this.InboxView.Items.Count;
           }));

        }

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
                OrderVisualTemplate mock1 = new OrderVisualTemplate();
                mock1.OrderTemplate = (Border)InboxView.SelectedItem;
                InboxView.Items.Remove(InboxView.SelectedItem);
                this.ServicedView.Items.Add(mock1.OrderTemplate);
                //TODO:Override the view control to create custom event for items.add / remove
                this.ServicedCounter.Content = this.ServicedView.Items.Count;
                this.InboxCounter.Content = this.InboxView.Items.Count;
                this.InboxView.SelectedIndex = -1;
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

        private void InboxView_TouchMove(object sender, TouchEventArgs e)
        {
            SwitchOrderTree();
        }

    }
}
