
# 🎯 WPF Reusable Styles & Control Templates – Task 1 Summary

This document summarizes key WPF concepts covered while building a **Contact Form** with reusable resources and styling. These concepts are essential for building scalable, maintainable WPF applications.

---

## 🧩 1. Reusable Styles

### ✅ Purpose:
Styles let you define a consistent look across controls. They’re reusable across the app via `StaticResource`.

### ✅ Example:
```xml
<Style TargetType="TextBox">
    <Setter Property="Margin" Value="5" />
    <Setter Property="Width" Value="200" />
</Style>
```

---

## 🎨 2. Control Templates

### ✅ Purpose:
`ControlTemplate` lets you **completely replace** the visual structure of a control like `Button`, `ComboBox`, etc.

### ✅ Example:
```xml
<ControlTemplate x:Key="ButtonControlTemplate" TargetType="Button">
    <Border Background="{TemplateBinding Background}" CornerRadius="5">
        <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
    </Border>
</ControlTemplate>
```

---

## 🧠 3. ControlTemplate vs DataTemplate

| Feature           | ControlTemplate                           | DataTemplate                          |
|------------------|-------------------------------------------|---------------------------------------|
| Targets          | Controls (e.g., `Button`, `ListBox`)      | Data objects (e.g., `Person`, `Product`) |
| Purpose          | Redefine visual structure of controls     | Define how data is displayed          |
| Used In          | Styles, Control Definitions               | `ItemsControl`, `ContentControl`, etc |

---

## 🔗 4. Binding Visual Properties – `TemplateBinding`

### ✅ Purpose:
Passes properties (like `Background`) from control to the template.

### ✅ Example:
```xml
<Border Background="{TemplateBinding Background}" />
```

- More efficient than `{Binding}` for template scenarios.
- Enables styles to affect templates via property propagation.

---

## 🧨 5. Resource Lookup Rules – `StaticResource` vs `DynamicResource`

### 🔄 StaticResource
- Resolved **once at load time**
- Must be **defined above** its usage

```xml
<Setter Property="Template" Value="{StaticResource ButtonControlTemplate}" />
```

> ⚠️ If the template is declared after the style, it will fail!

### 🔁 DynamicResource
- Resolved at **runtime**
- Can refer to resources defined later
- Slightly more performance overhead

---

## 🗂️ 6. Clean Resource Separation

Best practice: separate resource files per control type:

```
Resources/
├── ButtonStyle.xaml
├── ButtonTemplate.xaml
├── TextBoxStyle.xaml
├── LabelStyle.xaml
```

And merge them in `App.xaml` like this:

```xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="Resources/ButtonTemplate.xaml" />
            <ResourceDictionary Source="Resources/ButtonStyle.xaml" />
            <ResourceDictionary Source="Resources/TextBoxStyle.xaml" />
            <ResourceDictionary Source="Resources/LabelStyle.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```
