using System.Collections.Generic;

namespace SecuritySampleApp
{
    public class LanesViewModel : BaseViewModel
    {
        #region Fields
        List<LaneModel> _lanesList;
        #endregion

        #region Constructors
        public LanesViewModel() =>
            LanesList = CreateLanes();
        #endregion

        #region Properties
        public List<LaneModel> LanesList
        {
            get => _lanesList;
            set => SetProperty(ref _lanesList, value);
        }
        #endregion
    }
}