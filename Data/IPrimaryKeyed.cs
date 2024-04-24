namespace OODProj.Data
{
    public interface IPrimaryKeyed 
    {
         ulong ID { get; set; }
         ulong PrevID { get; set; }
    }
}