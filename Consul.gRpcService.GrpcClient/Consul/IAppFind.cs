using System;
using System.Collections.Generic;
using System.Text;

namespace Consul.gRpcService.GrpcClient.Consul
{
    public interface IAppFind
    {
        IEnumerable<string> FindConsul(string ServiceName);
    }
}
