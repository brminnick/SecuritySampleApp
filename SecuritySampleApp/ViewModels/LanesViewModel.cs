using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices.MVVM;

namespace SecuritySampleApp
{
    class LanesViewModel : BaseViewModel
    {
        bool _isRefreshing;
        ICommand? _refreshCommand;

        public ICommand RefreshCommand => _refreshCommand ??= new AsyncCommand(ExecuteRefreshCommand);

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public ObservableCollection<LaneModel> LanesCollection { get; } = new ObservableCollection<LaneModel>();

        async Task ExecuteRefreshCommand()
        {
            LanesCollection.Clear();

            try
            {
                await foreach (var lane in CreateLanes().ConfigureAwait(false))
                {
                    LanesCollection.Add(lane);
                }
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        async IAsyncEnumerable<LaneModel> CreateLanes()
        {
            for (int i = 0; i < 5; i++)
                yield return new LaneModel(i);

            await Task.Delay(1000).ConfigureAwait(false);
        }
    }
}