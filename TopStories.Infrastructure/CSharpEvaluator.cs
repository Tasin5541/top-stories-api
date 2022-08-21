using Microsoft.CodeAnalysis.Scripting;
using TopStories.Application.Common.Interfaces;
using System.Linq;

namespace TopStories.Infrastructure
{
    public class CSharpEvaluator: ICSharpEvaluator
    {
        public Script<object> CSExecutionContext { get; set; }
        public CSharpEvaluator() 
        {

            CSExecutionContext = GetExecutionContext();
            CSExecutionContext.RunAsync().Wait();
        }
        public Script<object> GetExecutionContext()
        {

            var scriptOptions = ScriptOptions.Default;

            var mscorlib = typeof(object).Assembly;
            var systemCore = typeof(Enumerable).Assembly;
            var newtonsoftJson = typeof(Newtonsoft.Json.JsonConvert).Assembly;

            var references = new[] { mscorlib, systemCore, newtonsoftJson };
            scriptOptions = scriptOptions.AddReferences(references);




            var interactiveLoader = new Microsoft.CodeAnalysis.Scripting.Hosting.InteractiveAssemblyLoader(null);
            foreach (var reference in references)
            {
                interactiveLoader.RegisterDependency(reference);
            }

            // Add namespaces
            scriptOptions = scriptOptions.AddImports("System");
            scriptOptions = scriptOptions.AddImports("System.Linq");
            scriptOptions = scriptOptions.AddImports("System.Collections.Generic");
            scriptOptions = scriptOptions.AddImports("System.IO");
            scriptOptions = scriptOptions.AddImports("System.Data");

            var script = Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.Create("return 0;", scriptOptions, null, interactiveLoader);

            return script;
        }

    }
}
