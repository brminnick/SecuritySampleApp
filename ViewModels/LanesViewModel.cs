using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SecuritySampleApp
{
    public class LanesViewModel : BaseViewModel
    {
		List<LaneModel> _lanesList;

        public List<LaneModel> LanesList
        {
            get { return _lanesList; }
            set
            {
				SetProperty<List<LaneModel>>(ref _lanesList, value);
            }
        }

        public LanesViewModel()
        {
            LanesList = CreateLanes();
        }
    }
}