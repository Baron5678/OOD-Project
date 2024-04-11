using OODProj.Data;

namespace OODProj.NewsReport
{
    public class NewsGenerator : INewsIterator
    {
        private List<INewsProvider> _providers;
        private List<IReportable> _reportables;

        private int currentReportableIndex = -1;
        private int currentNewsProviderIndex = 0;

        public NewsGenerator()
        {
            _providers = new List<INewsProvider>();
            _reportables = new List<IReportable>();
        }

        public NewsGenerator(List<INewsProvider> providers, List<IReportable> reportables)
        {
            _providers = providers;
            _reportables = reportables;
        }

        public int CountNews { get => _providers.Count * _reportables.Count; }

        public string GenerateFirstNews { get => _reportables[0].Accept(_providers[0]); }

        public bool IsAllGenerated { get => currentReportableIndex == _reportables.Count - 1 && currentNewsProviderIndex == _providers.Count - 1; }

        public string CurrentItem { get => _reportables[currentReportableIndex].Accept(_providers[currentNewsProviderIndex]); }

        public string GenerateNextNews()
        {
            currentReportableIndex++;
            if (currentReportableIndex >= _reportables.Count)
            {
                currentNewsProviderIndex++;
                currentReportableIndex = 0;
            }
            return _reportables[currentReportableIndex].Accept(_providers[currentNewsProviderIndex]);
        }
    }
}
