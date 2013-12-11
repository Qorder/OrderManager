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
    using Events;
    using Updater;

    public class OrderVisualTemplate
    {

        #region Assets Declaretions

        TreeView treeView;
        WrapPanel wrapPanel;
        LinearGradientBrush linearGradientBrush;
        Viewbox productViewbox;
        Label productNameLabel;
        Button removeButton;
        Viewbox priceViewbox;
        Label priceLabel;
        Viewbox notesViewbox;
        Label notesLabel;
		Border border;
		
        #endregion

		//Remove order event
		public event EventHandler removeEvent;

        #region Constructor

        public OrderVisualTemplate()
        {
            this.product = new Product("Product",10.10,"your notes here...");
            Initialize();
        }

        public OrderVisualTemplate(Product product)
        {
            this.product = product;
            Initialize();
        }

        #endregion

        #region Properties

        Product product
        {
            get;
            set;
        }

        #endregion
        #region Initialize Assets

        void InitializeTreeView()
        {
			//Use border instead
            /*treeView = new TreeView();
            treeView.HorizontalAlignment = HorizontalAlignment.Left;
            treeView.Height = 191;
            treeView.Margin = new Thickness(10, 10, 0, 0);
            treeView.VerticalAlignment = VerticalAlignment.Top;
            treeView.Width = 462;
            treeView.BorderThickness = new Thickness(2);
            //treeView.IsEnabled = false;*/
			
			border = new Border();
			border.BorderBrush = Brushes.Black;
			border.BorderThickness=new Thickness(1);
			border.Height=185;
			border.VerticalAlignment = VerticalAlignment.Top;
			border.Margin = new Thickness(5,5,5,5);
        }

        void InitializeWrapPanel()
        {
            wrapPanel = new WrapPanel();

			wrapPanel.HorizontalAlignment = HorizontalAlignment.Left;
			wrapPanel.VerticalAlignment = VerticalAlignment.Top;
			wrapPanel.Height=185;
			wrapPanel.Width=436;
			wrapPanel.Background=Brushes.White;
			
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.EndPoint = new Point(0.5, 1);
            linearGradientBrush.StartPoint = new Point(0.5, 0);

            GradientStop gradientStopBlack = new GradientStop();
            gradientStopBlack.Color = Colors.Black;
            gradientStopBlack.Offset = 0;

            GradientStop gradientStopWhite = new GradientStop();
            gradientStopWhite.Color = Colors.White;
            gradientStopWhite.Offset = 1;

            linearGradientBrush.GradientStops.Add(gradientStopBlack);
            linearGradientBrush.GradientStops.Add(gradientStopWhite);

            wrapPanel.OpacityMask = linearGradientBrush;
        }

        void InitializeViewboxesAndLabels()
        {
            //Product Name
            productViewbox = new Viewbox();
            productViewbox.Height = 67;
            productViewbox.Width = 366;

            productNameLabel = new Label();
            productNameLabel.Width = 104.7;
            
            //Add product name
            productNameLabel.Content = product.Name;
            productViewbox.Child = productNameLabel;
            this.wrapPanel.Children.Add(productViewbox);

            InitializeRemoveButton();
            this.wrapPanel.Children.Add(removeButton);
            //Price 
            priceViewbox = new Viewbox();
            priceViewbox.Height = 45;
            priceViewbox.Width = 449;

            priceLabel = new Label();
			Random rand = new Random();
			float price = rand.Next(1,1000);
			
            priceLabel.Content = Math.Round(product.Price,2) + " €";
            priceLabel.Width = 147.153;

            priceViewbox.Child = priceLabel;
			this.wrapPanel.Children.Add(priceViewbox);
			
            notesViewbox = new Viewbox();
            notesViewbox.Height = 65;
            notesViewbox.Width = 449;

            notesLabel = new Label();
            notesLabel.Content = product.Notes;
            notesLabel.Width = 283.576;
            notesLabel.Height = 49.172;

            notesViewbox.Child = notesLabel;
			this.wrapPanel.Children.Add(notesViewbox);

        }

        void InitializeRemoveButton()
        {
            removeButton = new Button();
            removeButton.Content = "X";
            removeButton.Width = 69;
            removeButton.RenderTransformOrigin = new Point(0.613, -0.2);
            removeButton.HorizontalAlignment = HorizontalAlignment.Right;
            removeButton.VerticalAlignment = VerticalAlignment.Top;
            removeButton.Height = 59.96;
            removeButton.BorderBrush = Brushes.White;
            removeButton.Foreground = Brushes.White;
            removeButton.Background = Brushes.Black;
            removeButton.FontSize = 26.667;
			
  			removeButton.Click += (sender, args) =>
                       {
						  if (removeEvent != null)
							{
     						 	removeEvent(this, new OrderEventArgs(this));
							}
                       };
        }

        #endregion

        public void Initialize()
        {
            InitializeTreeView();
            InitializeWrapPanel();
            
            InitializeViewboxesAndLabels();
			this.border.Child=wrapPanel;
        }

		
		#region Get Template Property
		
		public Border OrderTemplate
		{
			get
			{
				return border;
			}
			set
			{
				border = value;
			}
		}
		
		
		#endregion
    }
}