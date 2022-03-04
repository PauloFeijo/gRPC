using Grpc.Core;
using GrpcServiceBusinessDay;

namespace GrpcService.Services
{
    public class BusinessDayService : BusinessDay.BusinessDayBase
    {
        private readonly ILogger<BusinessDayService> _logger;
        public BusinessDayService(ILogger<BusinessDayService> logger)
        {
            _logger = logger;
        }
        public override Task<TimeReply> GetNow(EmptyRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"{DateTime.Now.ToString()} [GetNow]");
            return Task.FromResult(new TimeReply()
            {
                Time = DateTime.Now.ToString()               
            });
        }
    }
}