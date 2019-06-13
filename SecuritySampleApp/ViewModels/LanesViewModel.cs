using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;

namespace SecuritySampleApp
{
    class LanesViewModel : BaseViewModel
    {
        #region Fields
        bool _isRefreshing;
        ICommand _refreshCommand;
        List<LaneModel> _lanesList;
        #endregion

        #region Properties
        public ICommand RefreshCommand => _refreshCommand ??
            (_refreshCommand = new AsyncCommand(ExecuteRefreshCommand, continueOnCapturedContext: false));

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public List<LaneModel> LanesList
        {
            get => _lanesList;
            set => SetProperty(ref _lanesList, value);
        }
        #endregion

        #region Methods
        async Task ExecuteRefreshCommand()
        {
            var minimumRefreshTimeTask = Task.Delay(500);

            try
            {
                LanesList = CreateLanes().ToList();
            }
            finally
            {
                await minimumRefreshTimeTask.ConfigureAwait(false);
                IsRefreshing = false;
            }
        }

        IEnumerable<LaneModel> CreateLanes()
        {
            for (int i = 0; i < 5; i++)
                yield return new LaneModel(i);
        }
        #endregion
    }
}