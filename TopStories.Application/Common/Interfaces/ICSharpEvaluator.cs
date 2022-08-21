using Microsoft.CodeAnalysis.Scripting;

namespace TopStories.Application.Common.Interfaces
{
    public interface ICSharpEvaluator
    {
        //Script<object> GetExecutionContext();
        Script<object> CSExecutionContext { get; set; }
    }
}
