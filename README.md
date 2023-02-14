# Show-the-busy-Indicator-while-loading-data-in-maui-datagrid

The .NET [MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid)(SfDataGrid) allows you to show a [SfBusyIndicator](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Core.SfBusyIndicator.html?tabs=tabid-1) while loading Data in DataGrid. The busy indicator can be enabled and disabled by using [IsRunning](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Core.SfBusyIndicator.html#Syncfusion_Maui_Core_SfBusyIndicator_IsRunning) property.

## C#
In behavior class set ViewModel.IsLoading property value to true and false based items generation using loaded event.

```C#
public class MainPageBehavior : Behavior<ContentPage>
{
        SfDataGrid dataGrid;
        ViewModel viewModel;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataGrid = bindable.FindByName<SfDataGrid>("dataGrid");
            viewModel = (ViewModel)bindable.BindingContext;
            dataGrid.Loaded += DataGrid_Loaded;
        }

        private async void DataGrid_Loaded(object sender, EventArgs e)
        {
            this.viewModel.IsLoading = true;
            await Task.Delay(6000);
            this.viewModel.GenerateOrders();
            this.viewModel.IsLoading = false;
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            dataGrid = null;
            viewModel = null;
            dataGrid.Loaded -= DataGrid_Loaded;
        }
}
```

## XAML
Bind the value of ViewModel.IsLoading property to SfBusyIndicator.IsRunning property to enable or disable busy indicator into the view until items loaded in the view.

```XAML
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:core="clr-namespace:Syncfusion.Maui.Core;assembly=Syncfusion.Maui.Core"
             xmlns:local="clr-namespace:DataGridMAUI"
             xmlns:sfDatagrid="clr-namespace:Syncfusion.Maui.DataGrid;assembly=Syncfusion.Maui.DataGrid"
             x:Class="DataGridMAUI.MainPage">
    <ContentPage.BindingContext>
        <local:ViewModel x:Name="ViewModel"></local:ViewModel>
    </ContentPage.BindingContext>
    <ContentPage.Behaviors>
        <local:MainPageBehavior></local:MainPageBehavior>
    </ContentPage.Behaviors>
    <Grid x:Name="grid">
        <sfDatagrid:SfDataGrid x:Name="dataGrid" ColumnWidthMode="Fill" GridLinesVisibility="Both" HeaderGridLinesVisibility="Both" ItemsSource="{Binding OrderInfoCollection}">
        </sfDatagrid:SfDataGrid>
        <core:SfBusyIndicator x:Name="busyIndicator" AnimationType="SingleCircle" IsRunning="{Binding IsLoading,Mode=TwoWay}" TextColor="Magenta"
                                       SizeFactor="0.5"/>
    </Grid>
</ContentPage>
```
![LoadingBusyIndicator](LoadingBusyIndicator.gif)
