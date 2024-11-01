# Blazor Tree Component

This package provides a customizable tree component for Blazor WebAssembly applications. It supports multiple levels, optional checkboxes, and expand/collapse functionality. The component also provides an easy way to retrieve all checked nodes, both as a flat list and a hierarchical tree structure.

## Features

- Multiple levels of nodes
- Expand and collapse functionality for each node
- Optional checkboxes for nodes
- Parent-child synchronization of checked states
- Easy retrieval of checked nodes in both flat and hierarchical forms

# Not Ready Yet
## Installation

To install the component, add the NuGet package:

```shell
dotnet add package YourPackageName
````
## Usage

### Basic Setup

1. **Define a Tree Structure**: Create a `TreeNode` model for your data.

   ```csharp
   private TreeNode<int> tree = new TreeNode<int>
   {
       Id = 1,
       Title = "Root Node",
       IsChecked = true,
       IsExpanded = true,
       Children = new List<TreeNode<int>>
       {
           new TreeNode<int> {
               Id = 11,
               Title = "Child Node 1",
               Children = new List<TreeNode<int>>
               {
                   new TreeNode<int> {
                       Id = 111,
                       Title = "Child Node 1.1",
                       Children = new List<TreeNode<int>>() // Nested children
                   }
               }
           }
       }
   };
### 2. Add the Tree Component

Use the `<TreeComponent>` in your Blazor page and bind it to the tree model.

   ```razor
   <TreeComponent Expand="true" ShowCheckbox="true" TreeModel="@tree" OnCheckedNodesChanged="HandleCheckedNodes" />
   ```

   ### 3. Handle Checked Nodes (optional)

Implement the `HandleCheckedNodes` method to get the updated list of checked nodes when any checkbox is toggled.

   ```csharp
   private void HandleCheckedNodes(List<TreeNode<int>> checkedNodes)
   {
       // Process the list of checked nodes here
       Console.WriteLine($"Checked nodes count: {checkedNodes.Count}");
   }
```
### Parameters

- `TreeModel` (`TreeNode<T>`): The root node of the tree structure, representing the data hierarchy.
- `ShowCheckbox` (`bool`): Determines if checkboxes are shown next to each node. Default is `true`.
- `Expand` (`bool`): Sets the initial expand/collapse state for all nodes. Default is `true`.
- `OnCheckedNodesChanged` (`EventCallback<List<TreeNode<T>>>`): Event callback that is triggered whenever the list of checked nodes changes, returning an updated flat list of checked nodes.

### Example

```razor
@page "/"

<PageTitle>Tree Component Example</PageTitle>

<TreeComponent Expand="true" ShowCheckbox="true" TreeModel="@tree" OnCheckedNodesChanged="HandleCheckedNodes" />

@code {
    private TreeNode<int> tree = new TreeNode<int>
    {
        Id = 1,
        Title = "Root",
        IsChecked = true,
        IsExpanded = true,
        Children = new List<TreeNode<int>>
        {
            new TreeNode<int> { Id = 11, Title = "Node 1" },
            new TreeNode<int> { Id = 12, Title = "Node 2" }
        }
    };

    private void HandleCheckedNodes(List<TreeNode<int>> checkedNodes)
    {
        Console.WriteLine($"Checked nodes count: {checkedNodes.Count}");
    }
}
```

### Tree Node Model

The `TreeNode<T>` model represents each node in the tree. It is a generic model that can be used with various data types.

```csharp
public class TreeNode<T>
{
    public T Id { get; set; }
    public string Title { get; set; }
    public bool IsChecked { get; set; } = false;
    public bool IsExpanded { get; set; } = false;
    public List<TreeNode<T>> Children { get; set; } = new();
}
```
### CSS Styles

Add the following CSS styles to customize the appearance of the tree component:

```css
.tree-root {
    padding-left: 10px;
}

.tree-node {
    margin: 5px 0;
}

.node-header {
    display: flex;
    align-items: center;
}

.node-toggle {
    cursor: pointer;
    padding: 0 5px;
    font-weight: bold;
}

.node-title {
    margin-left: 5px;
}

.node-children {
    padding-left: 20px;
}
```
### License

This project is licensed under the MIT License. You are free to use, modify, and distribute this software in personal and commercial projects. See the `LICENSE` file for full license details.



