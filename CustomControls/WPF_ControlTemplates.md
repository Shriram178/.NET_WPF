
# WPF Control Customization: Toggle Switch and Custom ComboBox

## ✅ Toggle Switch (Custom CheckBox)

We created a `CheckBox` styled to look like a toggle switch using a `ControlTemplate`.

### 🔧 XAML Style Example

```xml
<Style x:Key="ToggleSwitchStyle" TargetType="CheckBox">
    <Setter Property="Width" Value="60" />
    <Setter Property="Height" Value="30" />
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="CheckBox">
                <Grid>
                    <Border x:Name="SwitchBorder"
                            Background="Gray"
                            BorderBrush="Black"
                            CornerRadius="15"
                            Height="30"
                            Width="60" />
                    <Ellipse x:Name="SwitchThumb"
                             Width="26"
                             Height="26"
                             Margin="2"
                             Fill="White"
                             HorizontalAlignment="Left" />
                </Grid>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsChecked" Value="True">
                        <Setter TargetName="SwitchBorder" Property="Background" Value="MediumSeaGreen" />
                        <Setter TargetName="SwitchThumb" Property="HorizontalAlignment" Value="Right" />
                    </Trigger>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter TargetName="SwitchBorder" Property="Background" Value="LightGreen" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

### 🧠 Key Concepts

- `ControlTemplate`: Replaces default appearance.
- `Trigger`: Used to move the thumb and change color on hover or check.
- `Ellipse` and `Border` create the switch UI.

### 🖼️ Output (Put GIF here)
_Add your toggle switch output GIF here._


---

## 🔽 Custom ComboBox

We replaced the default dropdown style with a custom `ControlTemplate`.

### 🔧 Simplified ComboBox ControlTemplate

```xml
<Style x:Key="MyComboBoxStyle" TargetType="ComboBox">
    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="ComboBox">
                <Grid>
                    <Border x:Name="MainBorder"
                            Background="White"
                            BorderBrush="DarkGray"
                            BorderThickness="1"
                            CornerRadius="4">
                        <Grid>
                            <ContentPresenter Margin="4"
                                              VerticalAlignment="Center"
                                              HorizontalAlignment="Left"
                                              Content="{TemplateBinding SelectionBoxItem}" />
                            <Path x:Name="Arrow"
                                  Fill="Gray"
                                  HorizontalAlignment="Right"
                                  Margin="0,0,6,0"
                                  VerticalAlignment="Center"
                                  Data="M 0 0 L 4 4 L 8 0 Z" />
                        </Grid>
                    </Border>
                    <Popup x:Name="PART_Popup"
                           Placement="Bottom"
                           IsOpen="{TemplateBinding IsDropDownOpen}"
                           AllowsTransparency="True">
                        <Border Background="White"
                                BorderBrush="DarkGray"
                                BorderThickness="1">
                            <ScrollViewer>
                                <StackPanel IsItemsHost="True" />
                            </ScrollViewer>
                        </Border>
                    </Popup>
                </Grid>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
</Style>
```

### 🧠 Key Concepts

- `PART_Popup`: Required for ComboBox dropdown to work.
- `Path` with `Data`: Used to draw a triangle arrow (like ▼).
- `ContentPresenter`: Displays selected item.
- `Border`: Controls visual styling.

### ✏️ Notes

- `TemplateBinding` lets you bind to the control's own properties.
- Always respect `PART_` names — WPF relies on them internally.
- Use `Path`'s `Data` to draw scalable vector icons.

### 🖼️ Output (Put GIF here)
_Add your ComboBox output GIF here._

---
