namespace OrderManagerPrototype.Templates
{
    interface ITemplate
    {
        System.Windows.Controls.Border OrderTemplate
        {
            get;
            set;
        }

        int ID
        {
            get;
        }

        void Initialize();
    }
}
