using Microsoft.JSInterop;

namespace BlazorWasm.TreeComponent
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class TreeNode<T> : IAsyncDisposable
    {
        public T Id { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; } = false;
        public bool IsExpanded { get; set; } = false;
        public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public TreeNode()
        {
            
        }
        public TreeNode(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorWasm.TreeComponent/exampleJsInterop.js").AsTask());
        }

        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", message);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
