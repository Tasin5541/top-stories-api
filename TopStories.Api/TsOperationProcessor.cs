using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace TopStories.API
{
    public class TsOperationProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            if (context.ControllerType.FullName.Contains("TopStories.Api.Controllers"))
            {
                return true;
            }
            return false; // return false to exclude the operation from the document
        }
    }
}
