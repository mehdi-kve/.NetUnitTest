using FluentAssertions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace NetworkUtility.Tests.PingTest
{
    public class NetworkServiceTests
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString() 
        {
            // Arrange - variables, classes , mocks
            var pingService = new NetworkService();

            // Act 
            var result = pingService.SendPing();

            // Assert As Execution part --using fluent assertion
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory] // allow to seed the function parameter
        [InlineData(2, 1, 3)]
        [InlineData(2, 2, 4)]

        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected) 
        {
            // Arrange
            var pingService = new NetworkService();

            // Act
            var result = pingService.PingTimeout(a,b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().NotBeInRange(-1000, 0);
        }

    }
}
