namespace TestRating.Interfaces
{
    public interface IRatingEngine
    {
        decimal Rating { get; set; }

        void Rate();
    }
}