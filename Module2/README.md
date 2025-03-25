# Instantiating Objects in XAML

## 1. Work with Elements and Attributes

 ![image](https://github.com/user-attachments/assets/2bfba391-8cc0-4529-928e-0945026da824)


![image](https://github.com/user-attachments/assets/bc09722a-a37f-4f3d-9737-0a3619fa733c)

### How Elemtnts and Attributes are mapped

![image](https://github.com/user-attachments/assets/a9fdfe41-a927-4686-8f5a-27e52497666d)

This XAML code is equvialent to the below C# code :

![image](https://github.com/user-attachments/assets/6e4b037a-8261-495b-82f1-7835a14a086d)

## 2. Set Properties with the Content Syntax

### Attribute Syntax 
```cahrp
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
