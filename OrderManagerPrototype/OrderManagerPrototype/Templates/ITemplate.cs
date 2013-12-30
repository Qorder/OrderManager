namespace OrderManagerPrototype.Templates
{
    interface ITemplate
    {
        System.Windows.Controls.Border OrderTemplate
        {
            get;
            set;
        }

        void Initialize();
    }
}
