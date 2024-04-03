namespace OODProj.NewsReport
{
    public interface INewsIterator
    {
        int CountNews { get; }
        string GenerateFirstNews { get; }
        bool IsAllGenerated { get; }
        string GenerateNextNews();
    }
}