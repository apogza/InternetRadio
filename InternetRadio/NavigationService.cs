﻿using InternetRadio.Events;
using InternetRadio.Models;
using InternetRadio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace InternetRadio
{
    public static class NavigationService
    {
        public static event EventHandler<ChangeRadioStationEventArgs> ChangeRadioStationHandler;

        public static Frame ContentFrame { get; set; }

        private static Dictionary<string, BaseViewModel> NavigationState { get; } = new Dictionary<string, BaseViewModel>();

        public static void NavigateTo(string pageName, object parameter = null)
        {
            Type pageType = Type.GetType($"InternetRadio.Views.{pageName}");

            if (pageType == null)
            {
                throw new ArgumentException("Unknown page requested");
            }

            ContentFrame?.NavigateToType(pageType, parameter, null);
        }

        public static void SaveState(BaseViewModel viewModel)
        {
            string viewModelId = viewModel?.GetType().FullName;
            if (viewModelId != null)
            {
                NavigationState[viewModelId] = viewModel;
            }
        }

        public static T RestoreState<T>() where T : BaseViewModel, new()
        {
            string viewModelId = typeof(T).FullName;

            if (viewModelId != null && NavigationState.ContainsKey(viewModelId))
            {
                return NavigationState[viewModelId] as T;
            }

            return new T();
        }

        public static void NavigateTo(Type pageType, object parameter = null)
        {
            ContentFrame?.NavigateToType(pageType, parameter, null);
        }

        public static void ChangeRadioStation(Radio radio)
        {
            ChangeRadioStationHandler?.Invoke(null, new ChangeRadioStationEventArgs { Radio = radio });
        }
    }
}
