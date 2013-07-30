using System;
using System.ServiceModel;
using Service.MessageContracts;
using Service.ServiceContracts;

namespace Service.ServiceImplementations
{
    public class QueueLoggingService : IQueueLoggingService
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void AddDeploymentLog(AddDeploymentLogRequest addDeploymentLogRequest)
        {
            //throw new NotImplementedException();
        }
    }
}
