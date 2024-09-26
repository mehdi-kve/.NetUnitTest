using FluentAssertions;
using FluentAssertions.Extensions;
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
        private readonly NetworkService _pingService;

        public NetworkServiceTests()
        {
            _pingService = new NetworkService();
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString() 
        {
            // Arrange - variables, classes , mocks

            // Act 
            var result = _pingService.SendPing();

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

            // Act
            var result = _pingService.PingTimeout(a,b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().NotBeInRange(-1000, 0);
        }

        [Fact]

        public void NetworkService_LastPingDate_ReturnDateTime() 
        {
            // Arrange

            // Act

            var result = _pingService.LastPingDate();

            // Assert
            result.Should().BeOnOrAfter(25.September(2024));
        }



    }
}
