using InternetRadio.Models;

namespace InternetRadio.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        protected RestClient RestClient { get; }
        //protected IDbService DbService { get; }

        public BaseViewModel()
            : base()
        {
            RestClient = new RestClient();
            //DbService = new DbService();
        }
    }
}