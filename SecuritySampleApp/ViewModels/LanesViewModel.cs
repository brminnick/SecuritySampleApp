using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace SecuritySampleApp
{
    public class LanesViewModel : BaseViewModel
    {
        #region Fields
        ICommand _refreshCommand;
        List<LaneModel> _lanesList;
        #endregion

        #region Properties
        public ICommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new Command(() => ExecuteRefreshCommand()));

        public List<LaneModel> LanesList
        {
            get => _lanesList;
            set => SetProperty(ref _lanesList, value);
        }
        #endregion

        #region Methods
        void ExecuteRefreshCommand() => LanesList = CreateLanes();

        List<LaneModel> CreateLanes()
        {
            var laneList = new List<LaneModel>();

            for (int i = 0; i < 5; i++)
            {
                var laneModel = new LaneModel(i);
                laneList.Add(laneModel);
            }

            return laneList;
        }
        #endregion
    }
}