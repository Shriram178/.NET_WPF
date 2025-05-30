# Creating your First WPF Application

## 1. What is WPF?

- UI framework to build Windows desktop apps.
- Part of .NET since 2006.
- Open source.

## 2. WPF Features for Application Development

- **XAML**: XML-based language to create UI.
- **Core Logic**: Written in C#.
- **Data Binding**:
  - Allows us to bind visual elements in our user interface to our objects that contain data for the UI.
  - This enables MVVM (Model-View-ViewModel), leading to a clear separation between the UI and the UI logic (more maintainable and testable apps).
- **Layout**: Create complex screen layouts easily.
- **Styles and Templates**: Customize the look and feel of your application.
- **Many More Features**: Explore additional capabilities as you develop.

## 3. Course Structure
	
 ![image](https://github.com/user-attachments/assets/fc445ac9-e077-4963-ac29-e28fdff94c3c)

 ## 4. Create and Explore WPF Project

### Step-by-Step Guide to Create a WPF Application

1. **Open Visual Studio** and create a new project.
2. Select **WPF App (.NET Core)** and click **Next**.
3. Name your project and click **Create**.

### Adding a Button with a Click Event

1. Open `MainWindow.xaml` and add a Button element:
    ```xml
    <Window x:Class="WpfApp.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Button Name="myButton" Content="Click Me"
             Width="100" Height="50" Click="MyButton_Click"/>
        </Grid>
    </Window>
    ```

2. Open `MainWindow.xaml.cs` and add the click event handler:
    ```csharp
    using System.Windows;

    namespace WpfApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }

            private void MyButton_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Button Clicked!");
            }
        }
    }
    ```

### Generating a Custom Event

1. Define a custom event in `MainWindow.xaml.cs`:
    ```csharp
    public event EventHandler MyCustomEvent;

    private void OnMyCustomEvent()
    {
        MyCustomEvent?.Invoke(this, EventArgs.Empty);
    }
    ```

2. Trigger the custom event in the button click handler:
    ```csharp
    private void MyButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Button Clicked!");
        OnMyCustomEvent();
    }
    ```

3. Subscribe to the custom event in the constructor:
    ```csharp
    public MainWindow()
    {
        InitializeComponent();
        MyCustomEvent += MainWindow_MyCustomEvent;
    }

    private void MainWindow_MyCustomEvent(object sender, EventArgs e)
    {
        MessageBox.Show("Custom Event Triggered!");
    }
    ```
## 5. Understanding how files are generated :

### Use names to alter the Xaml content

```XAML
<Window x:Class="WiredBrainCoffee.CustomersApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Button Content="Add Customer"
                HorizontalAlignment="Left"
                Margin="10"
                VerticalAlignment="Top"
                Click="ButtonAddCustomer_Click"/>
    </Grid>
</Window>
```
```csharp
namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomer.Content = "Customer added!";
        }
    }
}
```

### Understanding the boilerplate
```csharp
namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomer.Content = "Customer added!";
        }
    }
}
```
The `InitializeComponent()` and `btnAddCustomer` are not defined in the `class MainWindow`
but the C# compiler needs these two to compile the `class MainWindow`,so somewhere in the project these must be defined.

`public partial class MainWindow : Window` ,we can see that the class definition has the partial keyword.

`Partial Keyword` - The class definition can be split across several files.this is the case here, another C# file is generated by the XAML document.

- Build Action of XAML file is Page .
- Build Action of C# file is C# compiler.

From the XAML document C# code is generated .
```XAML
<Window x:Class="WiredBrainCoffee.CustomersApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Button Content="Add Customer"
                HorizontalAlignment="Left"
                Margin="10"
                VerticalAlignment="Top"
                Click="ButtonAddCustomer_Click"/>
    </Grid>
</Window>
```

in the XAML document we can see the `x:Class` attribute, eg : `Window x:Class="CustomersApp.MainWindow"`.This is the class name of the generated file and this is the name of the generated code behind file. In the above code `WiredBrainCoffee.CustomersApp` will be the namesapce and `MainWindow` will be the name of the class(code behind file).

```csharp
namespace WiredBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            btnAddCustomer.Content = "Customer added!";
        }
    }
}
```
### X:Class is the connection between the XAML document and code behind file.

![image](https://github.com/user-attachments/assets/cdd3021f-988f-4953-8b3c-07f83c263f06)
