# WPF Layout Panels

# 1. StackPanel

![image](https://github.com/user-attachments/assets/76c0d194-3bde-4e03-ac00-c08496a51c66)

## Horizontal orientation :
![image](https://github.com/user-attachments/assets/1976f84f-81ff-4b4b-b272-d15a2a4ffe08)

## Use case
- great for simple things, but Grid is mainly used for root layout, which will be complex.
- Can be used for stacking an  image with text in a button.

# 2. Grid
![image](https://github.com/user-attachments/assets/7a65b9fc-f2ec-4c80-a72e-8930ef4c7289)

![image](https://github.com/user-attachments/assets/882d8b25-6826-411d-ac30-8fdbd1277493)

## Use case
- Used as the root layout panel.
- We can add a stack panel to a grid to make the xaml more simple.
- Using `Grid`, we nest different layout panels.

# 2. Canvas
  - cannot grow or shrink (absolute).
![image](https://github.com/user-attachments/assets/460d53be-aea6-4caf-a5ba-d35211597778)

## Panel.ZIndex
![image](https://github.com/user-attachments/assets/25ef09f7-cb9c-4a44-8bb3-6b50d115adb0)


## Use case
- Used to position elements absolutely
- used to make drawings and diagrams.
