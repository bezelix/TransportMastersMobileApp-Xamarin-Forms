using System.Collections.ObjectModel;
using TransportMasters.Models;

namespace TransportMasters.ViewModels
{
    internal class DeliveriesViewModel
    {
        public ObservableCollection<DeliveriesModel> DeliveriesList { get; set; }

        public DeliveriesViewModel()
        {
            DeliveriesList = new ObservableCollection<DeliveriesModel>();
            DeliveriesList.Add(new DeliveriesModel { Name = "Test1", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test12", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test13", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test14", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test15", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test16", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test17", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test18", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test19", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test100", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test154", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            DeliveriesList.Add(new DeliveriesModel { Name = "Test141", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger", Ingredients = "This is our detail page details to be listed" });
            //you can add here multiple list items 
            //FoodList.Add(new MyListModel { Name = "Test2", Image = "https://media.istockphoto.com/photos/double-cheese-and-bacon-cheeseburger-picture-id511484502?k=6&m=511484502&s=612x612&w=0&h=2d8oTGH_E7KHkd4TIdftWIxjLsBP3CfdF44zy65FD0o=", Detail = "This is our burger",Ingredients="This is our detail page details to be listed" });

        }
    }
}