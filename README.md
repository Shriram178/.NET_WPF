
# WPF Interview Questions and Answers

This is a complete reference document compiled from our WPF interview prep. It includes all the questions, discussions, examples, and answers we've covered, with code and explanations.

---

## 📚 Index

1. [UserControl vs CustomControl](#1-usercontrol-vs-customcontrol)
2. [Dependency Property](#2-dependency-property)
3. [Routed Events: Tunneling & Bubbling](#3-routed-events-tunneling--bubbling)
4. [Visual Tree vs Logical Tree](#4-visual-tree-vs-logical-tree)
5. [Dispatcher, Async, Task, CancellationToken](#5-dispatcher-async-task-cancellationtoken)
6. [RoutedEventArgs and object sender](#6-routedeventargs-and-object-sender)
7. [TemplateBinding vs Binding vs RelativeSource](#7-templatebinding-vs-binding-vs-relativesource)
8. [Style vs ControlTemplate vs DataTemplate](#8-style-vs-controltemplate-vs-datatemplate)
9. [DependencyObject and DispatcherObject](#9-dependencyobject-and-dispatcherobject)
10. [GC Roots (Mention)](#10-gc-roots-mention)
11. [Hands-on Code Samples](#11-hands-on-code-samples)

---

## 1. UserControl vs CustomControl

- **UserControl** is used for grouping existing UI elements.
- **CustomControl** is used when we want a reusable, stylable, skinnable control.

📝 **Analogy**: A UserControl is like combining blocks, a CustomControl is like designing a whole new block.

---

## 2. Dependency Property

```csharp
public class RatingControl : Control
{
    public static readonly DependencyProperty RatingProperty =
        DependencyProperty.Register("Rating", typeof(int), typeof(RatingControl), new PropertyMetadata(0));

    public int Rating
    {
        get { return (int)GetValue(RatingProperty); }
        set { SetValue(RatingProperty, value); }
    }
}
```

### Why use it?
- Enables binding, styling, animation, default values, change callbacks.

---

## 3. Routed Events: Tunneling & Bubbling

```xml
<Window PreviewMouseDown="Window_PreviewMouseDown" MouseDown="Window_MouseDown">
  <StackPanel PreviewMouseDown="StackPanel_PreviewMouseDown" MouseDown="StackPanel_MouseDown">
    <Button Content="Click Me" PreviewMouseDown="Button_PreviewMouseDown" MouseDown="Button_MouseDown"/>
  </StackPanel>
</Window>
```

### Output:

```
Window → Tunneling PreviewMouseDown
StackPanel → Tunneling PreviewMouseDown
Button → Tunneling PreviewMouseDown
Button ← Bubbling MouseDown
StackPanel ← Bubbling MouseDown
Window ← Bubbling MouseDown
```

**📌 Tunneling:** Top to bottom (`PreviewEvent`).  
**📌 Bubbling:** Bottom to top (`Event`).

### Use Case:
- Early interception (e.g., cancel before it hits target).
- For understanding control flow and debugging complex UIs.

---

## 4. Visual Tree vs Logical Tree

### Logical Tree:
Defined by the XAML structure.

### Visual Tree:
Includes all elements involved in rendering.

**Example**:

```xml
<Button Content="Click Me" />
```

- Logical Tree: Button
- Visual Tree: Button → Border → ContentPresenter → TextBlock

### Importance:
- Visual Tree: animations, rendering.
- Logical Tree: binding, routed events, resource lookup.

---

## 5. Dispatcher, Async, Task, CancellationToken

### Dispatcher

```csharp
Application.Current.Dispatcher.Invoke(() =>
{
    MyLabel.Text = "Updated safely";
});
```

### Async & CancellationToken

```csharp
private CancellationTokenSource _cts;

private async void StartWork_Click(object sender, RoutedEventArgs e)
{
    _cts = new CancellationTokenSource();
    var token = _cts.Token;

    await Task.Run(() =>
    {
        for (int i = 0; i < 5; i++)
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(500);
        }
    }, token);
}

private void Cancel_Click(object sender, RoutedEventArgs e)
{
    _cts.Cancel();
}
```

---

## 6. RoutedEventArgs and object sender

- **object sender**: who raised the event.
- **RoutedEventArgs**: info about the event & route it took.

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    if (sender is Button btn)
        Debug.WriteLine($"Clicked {btn.Content}");
}
```

---

## 7. TemplateBinding vs Binding vs RelativeSource

| Type | Purpose | Example |
|------|---------|---------|
| Binding | To bind to DataContext | `{Binding Property}` |
| TemplateBinding | Used inside ControlTemplate to bind to TemplatedParent | `{TemplateBinding Background}` |
| RelativeSource | Bind to ancestor or self | `{Binding Path=SomeProp, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Window}}` |

---

## 8. Style vs ControlTemplate vs DataTemplate

- **Style**: Apply visual properties (margin, font, etc).
- **ControlTemplate**: Redefines structure.
- **DataTemplate**: Redefines how data appears in UI controls.

```xml
<DataTemplate DataType="{x:Type local:Person}">
    <StackPanel Orientation="Horizontal">
        <Image Source="{Binding Photo}" />
        <TextBlock Text="{Binding Name}" />
    </StackPanel>
</DataTemplate>
```

---

## 9. DependencyObject and DispatcherObject

- **DependencyObject**: Base class for objects with dependency properties.
- **DispatcherObject**: Base for objects that must run on UI thread.

```csharp
Dispatcher.Invoke(() => { /* safely update UI */ });
```

---

## 10. GC Roots (Mention)

You asked if **GC Roots** were related to Routed Events.  
They are not directly related — GC roots are .NET memory management concepts.

---

## 11. Hands-on Code Samples

Refer to earlier sections (especially `Routed Events` and `Async`) for runnable code.

---

**End of File ✅**
