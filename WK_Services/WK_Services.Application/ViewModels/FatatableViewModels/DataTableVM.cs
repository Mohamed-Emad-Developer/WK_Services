namespace WK_Services.Application.ViewModels.FatatableViewModels
{
    public class DataTableVM<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        
    }
}
