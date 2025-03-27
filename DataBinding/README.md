# Data Binding

# Element Name

Use the `Name` of the elemnt to bind data

Example :
```xaml
<TextBlock Text=" {Binding ElementName=..}"/>
```

Customer coffee app :

```xaml
 <Grid>
     <Grid.ColumnDefinitions>
         <ColumnDefinition Width="Auto"/>
         <ColumnDefinition/>
         <ColumnDefinition Width="Auto"/>
     </Grid.ColumnDefinitions>
     <!-- Customer list -->
     <Grid x:Name="customerListGrid"
   Background="#777">
         <Grid.RowDefinitions>
             <RowDefinition Height="Auto"/>
             <RowDefinition/>
         </Grid.RowDefinitions>
         <StackPanel Orientation="Horizontal" Margin="10">
             <Button Margin="10" Width="50">
                 <StackPanel Orientation="Horizontal">
                     <Image Source="/Images/add.png" Height="12" Margin="0 0 5 0"/>
                     <TextBlock Text="Add" FontSize="12"/>
                 </StackPanel>
             </Button>
             <Button Content="Delete" FontSize="12" Width="50" Margin="0 10 10 10" />
             <Button Margin="0 10 10 10" Click="ButtonMoveNavigation_Click">
                 <Image Source="/Images/move.png" Height="12"/>
             </Button>
         </StackPanel>
         <ListView x:Name="customerListView" Grid.Row="1" Margin="10 0 10 10">
             <ListViewItem>Julia</ListViewItem>
             <ListViewItem>Alex</ListViewItem>
             <ListViewItem>Thomas</ListViewItem>
         </ListView>
     </Grid>

     <!-- Customer detail -->
     <StackPanel Grid.Column="1" Margin="10">
         <Label>Firstname:</Label>
         <TextBox Text="{Binding ElementName=customerListView,Path=SelectedItem.Content,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}"/>
         <Label>Lastname:</Label>
         <TextBox/>
         <CheckBox Margin="0 10 0 0">
             Is developer
         </CheckBox>
     </StackPanel>
 </Grid>
```

# Source Property
We can use the source property with the static resource markup extension.
By doing this we can use a resource as adata source.
Example

```xaml
<TextBlock
Text=" {Binding Source={StaticResource myRes}}" / >
```

# RelativeSource Property

```xaml
<Rectang1e Fill=" Red" Width=" 300"
    Height=" {Binding RelativeSource=
          {RelativeSource Self} ,Path=Width / >
```
This will set the hieght to the relative patho of width so the rectangle will always be a square.

# DataContext

If we neither specify the `ElementName`,`Source`,`RelativeSource`
like on the below binding

```xaml
<TextBlock Text=" {Binding}" / >
```
Then the binding markup extension uses the `DataContext`.

Let me show you now what that means. Let's say that this text block is in a StackPanel, and the StackPanel is in a Grid. Every element in WPF has a DataContext property that is of type object. This property is defined in the framework element class,
 which is a base class for all controls and panels.
```xaml
<Grid>
  <StackPanel>
    <TextBlock Text=" {Binding}"/>
  </StackPanel>
<Grid>
```
Let's set here the DataContext property on the Grid to the string Pluralsight. The Binding markup extension will look in this case into the DataContext property of the text block. As it is not set, it goes one level up in the elementary, and it looks into the DataContext property of the StackPanel. That property is also not set, so it goes again one level up and looks into the DataContext property of the Grid element. There it finds the string Pluralsight, and it uses that string as a data source. As a result,
the text property of the text block is set to the string Pluralsight.
```xaml
<Grid DataContext="Pluralsight">
  <StackPanel>
    <TextBlock Text=" {Binding}"/>
  </StackPanel>
<Grid>
```
When you set the DataContext property on the StackPanel to the string Thomas, the Binding markup extension will use the string Thomas for the text property of the text block. This is because the DataContext property of the StackPanel is the first DataContext that is set. 
```xaml
<Grid DataContext="Pluralsight">
  <StackPanel DataContext="Thomas">
    <TextBlock Text=" {Binding}"/>
  </StackPanel>
<Grid>
```
Now instead of using a simple string as a DataContext, like in this code snippet, you can also put a more complex object into the DataContext. Then you can bind to the properties of that object. Exactly this is what the Model‑View‑ViewModel pattern does. So let's take a look at that pattern.
