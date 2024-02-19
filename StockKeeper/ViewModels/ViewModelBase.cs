using ReactiveUI;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StockKeeper.ViewModels { 

public class ViewModelBase :  ReactiveObject, INotifyPropertyChanged
    {
    public event PropertyChangedEventHandler? PropertyChanged;

    public void SendPropertyChanged([CallerMemberName] string propName = null)
    {
        if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
}
}
