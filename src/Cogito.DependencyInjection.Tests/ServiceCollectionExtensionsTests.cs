using FluentAssertions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.DependencyInjection.Tests
{

    [TestClass]
    public class ServiceCollectionExtensionsTests
    {

        [AddScopedService]
        public class Test
        {

        }

        [AddKeyedScopedService("HI")]
        public class KeyedTest
        {

        }

        [TestMethod]
        public void CanAddScopedService()
        {
            var s = new ServiceCollection();
            s.AddFromAttributes(typeof(Test));
            s[0].ImplementationType.Should().BeSameAs(typeof(Test));
            s[0].ServiceType.Should().BeSameAs(typeof(Test));
        }

        [TestMethod]
        public void CanAddKeyedScopedService()
        {
            var s = new ServiceCollection();
            s.AddFromAttributes(typeof(KeyedTest));
            s[0].KeyedImplementationType.Should().BeSameAs(typeof(KeyedTest));
            s[0].ServiceType.Should().BeSameAs(typeof(KeyedTest));
            s[0].ServiceKey.Should().Be("HI");
        }

    }

}
