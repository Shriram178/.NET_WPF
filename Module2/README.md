# Instantiating Objects in XAML

## 1. Work with Elements and Attributes

 ![image](https://github.com/user-attachments/assets/2bfba391-8cc0-4529-928e-0945026da824)


![image](https://github.com/user-attachments/assets/bc09722a-a37f-4f3d-9737-0a3619fa733c)

### How Elemtnts and Attributes are mapped

![image](https://github.com/user-attachments/assets/a9fdfe41-a927-4686-8f5a-27e52497666d)

This XAML code is equvialent to the below C# code :

![image](https://github.com/user-attachments/assets/6e4b037a-8261-495b-82f1-7835a14a086d)

## 2. Set Properties with the Content Syntax

## Attribute Syntax 
```xaml

    <Grid>
        <Button Content="Add Customer"
                HorizontalAlignment="Left"
                Margin="10"
                VerticalAlignment="Top"
                Click="ButtonAddCustomer_Click"/>
    </Grid>
```
- This is called `attribute syntax` because the Content attribute is used to set the content's property. 
- This allows us to set only a `simple value` to the property.

- If we want to set a more `complex value` to a property we use `Property Element Syntax` 

## Property Element Syntax
```xaml
    <Grid>
        <Button HorizontalAlignment="Left"
                Margin="10"
                VerticalAlignment="Top"
                Click="ButtonAddCustomer_Click">
           <Button.Content>
                  Add customer
           </Button.Content>
         </Button>
    </Grid>
```
Here
- The `Button` is the `Object element` as it creates an object of the button class.
- The `Button.Content` is called the `Property element`.
- Elements (`Object element`) are mapped to classes.
- Attributes are mapped to properties or events.

Now, this has the same output as the previous code, so let's make it a bit more complex by adding an image to the button. 

- Add the image to the project and set the `Build Action: Resources` by right click the image -> Properties.
```xaml
    <Grid>
    <Button HorizontalAlignment="Left"
            Margin="10"
            VerticalAlignment="Top"
            Click="ButtonAddCustomer_Click">
        <Button.Content>
            <StackPanel Orientation="Horizontal">
                <Image Source="/Images/add.jpg" Height="18" Margin="0 0 5 0"/>
                <TextBlock Text="Add Customer"/>
            </StackPanel>
        </Button.Content>
    </Button>
</Grid>
```
### output :

![image](https://github.com/user-attachments/assets/d6c03fa9-2b3d-4669-9ee5-7578238b733a)

We can see how property element syntax creates complex values for the UI objects.

## Content Syntax :
Content Syntax is when we omit the property syntax and make the XML parser assign the values to the property.

Example :
### Attribute syntax 
```xaml
<Button Content="Add Customer"/>
```
### Property Element Syntax 
```xaml
<Button>
    <Button.Content>
           Add customer
     </Button.Content>
</Button>
```
### Content syntax 
```xaml
<Button>
    Add customer    
</Button>
```
### How content syntax works :
![image](https://github.com/user-attachments/assets/d6172fe5-fe94-4031-a2be-acbc1c5808a5)

`Content Syntax `is always used when you put content in an object element without
property element.

### For example :
```xaml
<Window x:Class="WPF_PluralSight.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WPF_PluralSight"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="145*"/>
            <RowDefinition Height="289*"/>
        </Grid.RowDefinitions>
        <Button HorizontalAlignment="Left"
                Margin="10,10,0,0"
                VerticalAlignment="Top"
                Click="ButtonAddCustomer_Click">
            <Button.Content>
                <StackPanel Orientation="Horizontal">
                    <Image Source="/Images/add.jpg" Height="18" Margin="0 0 5 0"/>
                    <TextBlock Text="Add Customer"/>
                </StackPanel>
            </Button.Content>
        </Button>
    </Grid>
</Window>
```

- Here we don't specify what property in the `Window` we assign the `Grid` to, this also goes for the `StackPanel`, `Image`, and `TextBlock`.
- The XAML parser automatically checks the content and assigns it to the properties by going to their base classes.
- We can also explicitly mention the properties each time like `Grid` must be set to property `Window.Content`.
```xaml
<Window.Content>
  <Grid>
    <!-- # content -->
  </Grid>
</Window.Content>
```
But doing this will decrease readability, hence we go for Content syntax.

## Collection Syntax
```xaml
<StackPanel>
     <StackPane1. Children>
          <TextBlock />
      </StackPanel. Children>
</ StackPane1>
```
Here, let's see what the XML parser does step by step

Step 1: creates a `StackPanel` object.
```xaml
var stackPanel = new StackPanel() ;
```
Step 2: XAML checks the type of the property, the `TextBloack` cannot be assigned to a type of UIElementCollection which is `stackPanel.Children`.
```xaml
<!-- This cannot be done -->
stackPanel.Childern = new TextBloack() ;
```

Step 3: So the XAML parser detects that the  `stackPanel.Children` is a collection type and so it calls the add method. If we have another element, say `Button`, it also gets added to the collection.

```xaml
<StackPanel>
   <StackPanel.Children>
     <TextBlock/>
     <Button />
   </StackPanel.Children>
</StackPanel>
```
This is what the xaml parse does :
```csharp
var stackPanel = new StackPanel();
stackPanel.Chi1dren.Add(new TextBlock()) ;
stackPanel.Chi1dren.Add(new Button()) ;
```

We can further improve this by combining `Content syntax` and `Collection Syntax`.
```xaml
<StackPanel>
     <TextBlock/>
     <Button />
</StackPanel>
```
