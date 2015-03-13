using System.Web.Http;
using NSWTrainTracker.Models.DAL;

namespace NSWTrainTracker.Controllers
{
    public class BaseApiController : ApiController
    {
         private readonly ITrackWorkRepository _repository;
         public BaseApiController(ITrackWorkRepository repository)
        {
            _repository = repository;
            //_db = new TrainRequestClient(CityCircleFeedBase);
        }

        protected ITrackWorkRepository TheRepository
        {
            get
            {
                return _repository;
            }
        }
    }
}
