namespace AspNetMvCoreExamples.ConsoleApp.EntityFramework
{
    public interface IEntityFrameworkTests
    {
        void Seed();

        void CacheFirstOrDefault();
        void CacheFind();

        void ToAsyncEnumerable();
    }
}