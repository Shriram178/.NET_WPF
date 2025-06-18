# WPF Async Programming, Event Handling & Cancellation – Deep Dive

This document covers core concepts you need to understand to build responsive and well-structured WPF applications, especially when dealing with asynchronous work and event handling.

---

## 📌 `async`, `await`, and `Task` in WPF

### ✅ What is `async` and `await`?
- Used to perform long-running tasks (like I/O or background processing) **without freezing** the UI.
- `await` lets the UI thread remain **free to respond** while the background work completes.

### ✅ Why use them?
- Prevents **UI freezing** (especially important in desktop apps like WPF).
- Makes code easier to read and write compared to threading callbacks.

### 🧪 Example

```csharp
private async void StartWork_Click(object sender, RoutedEventArgs e)
{
    await Task.Delay(3000); // Simulates background work
    MessageBox.Show("Work completed!");
}
```

---

## 🧵 UI Thread, `Dispatcher`, and Thread Safety

WPF has a **single UI thread**. Background threads **cannot** update UI elements directly. You need to use the **Dispatcher**.

### 🧪 Dispatcher Example

```csharp
Application.Current.Dispatcher.Invoke(() =>
{
    MyLabel.Content = "Updated from background thread";
});
```

---

## 🛑 Cancellation with `CancellationToken`

### ✅ What is `CancellationToken`?
- It allows cooperative cancellation between threads.
- Commonly used with async methods to stop long-running operations when needed.

### 🧪 Example

```csharp
CancellationTokenSource cts = new CancellationTokenSource();

private async void StartWork_Click(object sender, RoutedEventArgs e)
{
    try
    {
        await Task.Run(() => DoWork(cts.Token));
    }
    catch (OperationCanceledException)
    {
        MessageBox.Show("Operation was cancelled.");
    }
}

private void DoWork(CancellationToken token)
{
    for (int i = 0; i < 10; i++)
    {
        token.ThrowIfCancellationRequested();
        Thread.Sleep(500);
    }
}
```

---

## 🧠 `object sender` and `RoutedEventArgs e`

### ✅ What is `object sender`?
- The **object that raised the event**.
- Helps identify which control triggered the event.

### ✅ What is `RoutedEventArgs`?
- Contains context like the original source of the event.
- Carries data across the **event route** in WPF (tunneling or bubbling).

### 🧪 Example

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    Button btn = sender as Button;
    MessageBox.Show($"Clicked: {btn.Content}");
}
```

---

## 🔁 Routed Events in WPF

### ✅ What are Routed Events?
- Events that **travel through the visual/logical tree**.
- **Tunneling**: from root to source (`PreviewEvent`)
- **Bubbling**: from source to root (`Event`)

### 🧪 Hands-On Example

**XAML**:
```xml
<Window ... PreviewMouseDown="Window_PreviewMouseDown" MouseDown="Window_MouseDown">
    <StackPanel PreviewMouseDown="StackPanel_PreviewMouseDown" MouseDown="StackPanel_MouseDown">
        <Border PreviewMouseDown="Border_PreviewMouseDown" MouseDown="Border_MouseDown">
            <TextBlock Text="Click me!" />
        </Border>
    </StackPanel>
</Window>
```

**Code-Behind**:
```csharp
private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e) => Debug.WriteLine("Window → Tunneling");
private void Window_MouseDown(object sender, MouseButtonEventArgs e) => Debug.WriteLine("Window ← Bubbling");

private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e) => Debug.WriteLine("StackPanel → Tunneling");
private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e) => Debug.WriteLine("StackPanel ← Bubbling");

private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e) => Debug.WriteLine("Border → Tunneling");
private void Border_MouseDown(object sender, MouseButtonEventArgs e) => Debug.WriteLine("Border ← Bubbling");
```

### 🧾 Sample Output

```
Window → Tunneling
StackPanel → Tunneling
Border → Tunneling
Border ← Bubbling
StackPanel ← Bubbling
Window ← Bubbling
```

### 🧠 What can we learn from this?
- **Tunneling** goes top-down (parent to child).
- **Bubbling** goes bottom-up (child to parent).
- Helps when handling complex UIs with nested elements (e.g., prevent event propagation).

---

## ✅ Summary Table

| Concept                 | Purpose |
|--------------------------|---------|
| `async` / `await`        | Prevent UI freezing while doing background work |
| `Task`                  | Represents a unit of async work |
| `Dispatcher`            | Used to safely update UI from a background thread |
| `CancellationToken`     | Gracefully cancel long-running operations |
| `object sender`         | Identifies which control raised the event |
| `RoutedEventArgs`       | Provides event context (source, route, etc.) |
| Routed Events           | Event routing mechanism (tunneling, bubbling) in WPF |

---

## ✅ When to Use These in Real Projects?

- **Responsive UI** → Use async and Dispatcher to keep things smooth.
- **User Cancellation** → Always provide cancel buttons for long tasks.
- **Multiple Controls One Handler** → Use `sender` to distinguish.
- **Advanced UI Event Handling** → Routed events make it flexible to intercept or modify behavior in parent containers.

---

This document serves as your WPF reference when building interactive and efficient applications.