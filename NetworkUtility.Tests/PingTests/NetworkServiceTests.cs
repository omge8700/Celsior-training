using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public  class NetworkServiceTests
    

    { 

        private readonly NetworkService pingService;
        private   readonly IDNS dNS;

        public NetworkServiceTests()
        {//dependencies
            dNS = A.Fake<IDNS>() ;

            //SUT
            pingService = new NetworkService();
        }


        [Fact]

        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables ,classes,mocks
            var pingService = new NetworkService();
            //Act


            var result = pingService.SendPing();

            //Assert

            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Sucess:Ping Sent");


        }

        [Theory]


        public void NetworkServiceLastPingDateReturnDate()
        { // Arrange
      
            //Act
            var result = pingService.LastPingDate;
            // result.Should().Be("Sucess: hogaya");
            result.Should().BeAfter(1.January(2010));




        }

    }

    internal class IDNS
    {
    }
}
