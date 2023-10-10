using Sources.ViewModel.Properties.Interfaces;

namespace Sources.ViewModel.Properties
{
    public class BoolProperty : Property<bool>, IBoolProperty
    {
        bool IBoolProperty.value => value;
    }
}