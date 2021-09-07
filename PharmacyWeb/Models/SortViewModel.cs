using PharmacyWeb.Enums;

namespace PharmacyWeb.Models
{
    public class SortViewModel
    {
        public SortParamaters SortState { get; private set; }

        public SortViewModel(SortParamaters sortState)
        {
            SortState = sortState;
        }
    }
}
