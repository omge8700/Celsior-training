using NetworkUtility.DNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public  class NetworkService : DNSService
    {
        private readonly IDNS _dns;

        public NetworkService(IDNS dns)
        {
            this._dns = dns;
            
        }
        public  string SendPing()
        {
            //iNJECTING dns
            var dnsSuccess = _dns.SendDNS();
            if (dnsSuccess)
            {
                return "Succes : Ping Sent !";
            }
            else
            {
                return "Failed : Ping Not sent";
            }
           
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;

        }

    }
}
