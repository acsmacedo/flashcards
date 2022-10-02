﻿using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using FlashCards.App.Models.Accounts;
using FlashCards.App.Views.Account;
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

        protected int UserID
        {
            get
            {
                if (Application.Current.Properties.TryGetValue("user_account", out var value))
                {
                    var result = value as Account;

                    return result.UserID;
                }

                throw new Exception("Usuário não encontrado!");
            }
        }
    }
}