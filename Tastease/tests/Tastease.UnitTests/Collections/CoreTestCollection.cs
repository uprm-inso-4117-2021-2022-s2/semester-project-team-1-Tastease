using Tastease.UnitTests.Fixtures;
using Xunit;

namespace Tastease.UnitTests.Collections
{
    [CollectionDefinition(nameof(CoreTestCollection))]
    public class CoreTestCollection : 
        ICollectionFixture<ServicesFixture>, 
        ICollectionFixture<InMemoryDatabaseFixture>, 
        ICollectionFixture<RequestGeneratorFixture> 
    {

    }

}
