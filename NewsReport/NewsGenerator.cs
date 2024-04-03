using OODProj.Data;

namespace OODProj.NewsReport
{
    public class NewsGenerator : INewsIterator
    {
        private List<INewsProvider> _providers;
        private List<IReportable> _reportables;

        int currentReportableIndex = -1;
        int currentNewsProviderIndex = -1;

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

        public string GenerateNextNews()
        {
            currentNewsProviderIndex = 0;
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
