using Sources.Tools;
using Sources.ViewModel.Properties.Interfaces;

namespace Sources.ViewModel.Properties
{
    public class IntProperty : Property<int>, IIntProperty, IStringProperty
    {
        string IStringProperty.value => value >= 10000
            ? value.ToString("N0", UITextFormatter.cultureNumber)
            : value.ToString();
    }
}