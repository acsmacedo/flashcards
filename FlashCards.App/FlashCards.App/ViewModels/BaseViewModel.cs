using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FlashCards.App.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected INavigation Navigation => Application.Current.MainPage.Navigation;
        protected Page MainPage => Application.Current.MainPage;

        protected async void DisplayError(
            string title = "Erro", 
            string message = "Ocorreu um erro, tente novamente!", 
            string cancel = "Ok")
        {
            await MainPage.DisplayAlert(
                title: title, 
                message: message, 
                cancel: cancel);
        }

        protected async Task DisplaySuccess(
            string title = "Sucesso",
            string message = "Os dados foram salvos com sucesso!",
            string cancel = "Ok")
        {
            await MainPage.DisplayAlert(
                title: title,
                message: message,
                cancel: cancel);
        }

        protected async Task<string> DisplayActionSheet(
            string title,
            string cancel,
            string[] buttons)
        {
            return await MainPage.DisplayActionSheet(
                title: title,
                cancel: cancel,
                destruction: null,
                buttons: buttons);
        }

        protected async Task<string> DisplayPrompt(
            string title, 
            string message,
            string initialValue = null,
            string accept = "Salvar",
            string cancel = "Cancelar")
        {
            string result = await MainPage.DisplayPromptAsync(
                title: title,
                message: message,
                cancel: cancel,
                accept: accept,
                initialValue: initialValue);

            return result;
        }

        protected int UserID
        {
            get
            {
                if (Application.Current.Properties.TryGetValue("user_id", out var value))
                {
                    return (int)value;
                }

                throw new Exception("Usuário não encontrado!");
            }
        }
    }
}
