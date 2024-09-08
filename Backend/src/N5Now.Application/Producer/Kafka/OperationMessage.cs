using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace N5Now.Application.Producer.Kafka
{
    public class OperationMessage
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public string Operation { get; protected set; }

        public OperationMessage (Operation operation)
        {
            this.Operation = operation.ToString();
        }
    }

    public enum Operation
    {
        get,
        request,
        modify
    }
}
