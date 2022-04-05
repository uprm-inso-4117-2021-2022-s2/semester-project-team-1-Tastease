using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tastease.UnitTests.Fixtures;
using Xunit;

namespace Tastease.UnitTests.Collections
{
    [CollectionDefinition(nameof(WebTestCollection))]
    public class WebTestCollection :
        ICollectionFixture<ServicesFixture>,
        ICollectionFixture<InMemoryDatabaseFixture>,
        ICollectionFixture<WebAppFixture>,
        ICollectionFixture<RequestGeneratorFixture>
    {

    }
}
