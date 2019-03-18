using System;
using System.Collections.Generic;
using System.Text;
using Consul.gRpcService.GrpcClient.LoadBalance;
using Consul.GRpcService.Protocol;
using Grpc.Core;

namespace Consul.gRpcService.GrpcClient.RpcClient
{
    public class MsgClient : IMsgClient
    {
        ILoadBalance LoadBalance;
        Channel GrpcChannel;
        MsgService.MsgServiceClient GrpcClient;

        public MsgClient(ILoadBalance loadBalance)
        {
            LoadBalance = loadBalance;

            var grpcUrl = LoadBalance.GetGrpcService("GrpcService");

            if (!grpcUrl.Equals(""))
            {
                Console.WriteLine($"Grpc Service:{grpcUrl}");

                GrpcChannel = new Channel(grpcUrl, ChannelCredentials.Insecure);
                GrpcClient = new MsgService.MsgServiceClient(GrpcChannel);
            }
        }

        public void GetSum(int num1, int num2)
        {
            if (GrpcClient != null)
            {
                GetMsgSumReply msgSum = GrpcClient.GetSum(new GetMsgNumRequest
                {
                    Num1 = num1,
                    Num2 = num2
                });

                Console.WriteLine("Grpc Client Call GetSum():" + msgSum.Sum);
            }
            else
            {
                Console.WriteLine("所有负载都挂掉了！");
            }
        }
    }
}
