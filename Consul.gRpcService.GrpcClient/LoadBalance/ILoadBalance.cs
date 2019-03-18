using System;
using System.Collections.Generic;
using System.Text;

namespace Consul.gRpcService.GrpcClient.LoadBalance
{
    /*
     * 负载均衡接口
     */
    public interface ILoadBalance
    {
        string GetGrpcService(string ServiceName);
    }
}
