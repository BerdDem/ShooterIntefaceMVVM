using System;

namespace Sources.ViewModel.Properties
{
    public interface IProperty
    {
        event Action ValueChanged;
    }
}