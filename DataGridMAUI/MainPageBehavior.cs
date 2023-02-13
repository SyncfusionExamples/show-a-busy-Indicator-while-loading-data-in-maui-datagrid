using Syncfusion.Maui.DataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridMAUI
{
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
}
