using Onlive_VRP_Portal.Models.EntityManager;

namespace Onlive_VRP_Portal.Models.ViewModel
{
    public class AvailableServiceDataView
    {
        public AvailableServiceDataView(int _ID, string _Title, string _Description, string _Type)
        {
            ID = _ID;
            Title = _Title;
            Description = _Description;
            Type = _Type;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}