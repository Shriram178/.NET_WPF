
# 📘 Dependency Properties in WPF

## 🧠 What is a Dependency Property?

A **Dependency Property** in WPF is a special kind of property that extends standard .NET properties. It supports powerful WPF features like:

- Data Binding
- Animation
- Styles and Templates
- Property Inheritance
- Change Notification

---

## ⚙️ Why Not Just Use Normal Properties?

Normal CLR properties can't interact with the WPF property system, so they can't:

- Automatically update in data bindings
- Be styled or animated via XAML
- Use WPF's memory-efficient property storage

Dependency properties solve these problems.

---

## 🧱 How to Create a Dependency Property

### ✅ Step 1: Register the Property

```csharp
public static readonly DependencyProperty RatingProperty =
    DependencyProperty.Register(nameof(Rating), typeof(int), typeof(StarRatingControl),
        new PropertyMetadata(0, OnRatingChanged));
```

### ✅ Step 2: Expose It with a Wrapper

```csharp
public int Rating
{
    get => (int)GetValue(RatingProperty);
    set => SetValue(RatingProperty, value);
}
```

### ✅ Step 3: Handle Changes (Optional)

```csharp
private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
    var control = (StarRatingControl)d;
    // Update visuals or notify bindings
}
```

---

## 🔁 Example: Star Rating Control

```xml
<local:StarRatingControl Rating="{Binding MyRating, Mode=TwoWay}" />
```

```csharp
public class StarRatingControl : UserControl
{
    public static readonly DependencyProperty RatingProperty =
        DependencyProperty.Register(nameof(Rating), typeof(int), typeof(StarRatingControl),
            new PropertyMetadata(0, OnRatingChanged));

    public int Rating
    {
        get => (int)GetValue(RatingProperty);
        set => SetValue(RatingProperty, value);
    }
}
```

---

## ✅ Key Benefits of Dependency Properties

| Feature               | Supported |
|------------------------|-----------|
| Data Binding           | ✅        |
| Animation              | ✅        |
| Style and Theme Support| ✅        |
| Property Inheritance   | ✅        |
| Reduced Memory Overhead| ✅        |

---

## 🧪 When Should You Use a Dependency Property?

Use a dependency property **when**:

- You are writing a `UserControl` or `CustomControl`
- You want to enable styling or animation
- You need support for data binding or change notifications

---

## 📦 Output Placeholder

Add a screenshot or GIF of the star rating control here.
