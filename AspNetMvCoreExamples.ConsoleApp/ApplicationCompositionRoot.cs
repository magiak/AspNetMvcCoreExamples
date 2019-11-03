using AspNetMvCoreExamples.ConsoleApp.EntityFramework;

namespace AspNetMvCoreExamples.ConsoleApp
{
    public class ApplicationCompositionRoot : IApplicationCompositionRoot
    {
        private readonly IEntityFrameworkTests entityFrameworkTests;

        public ApplicationCompositionRoot(IEntityFrameworkTests entityFrameworkTests)
        {
            this.entityFrameworkTests = entityFrameworkTests;
        }

        public void Start()
        {
            this.entityFrameworkTests.Seed();
            //this.entityFrameworkTests.CacheFirstOrDefault();
            //this.entityFrameworkTests.CacheFind();
            this.entityFrameworkTests.ToAsyncEnumerable();
        }
    }
}
