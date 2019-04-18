using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using Savaged.BlackNotepad.ViewModels;
using Savaged.BlackNotepad.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace Savaged.BlackNotepad.Services
{
    public class DialogService : IDialogService
    {
        private Dialog _visibleExclusiveDialog;

        public T GetDialogViewModel<T>() 
            where T : IDialogViewModel
        {
            var value = SimpleIoc.Default.GetInstance<T>();
            return value;
        }

        public T GetDialog<T>() where T : CommonDialog
        {
            var value = SimpleIoc.Default.GetInstance<T>();
            return value;
        }

        public bool? ShowDialog(IDialogViewModel vm)
        {
            var vmName = vm.GetType().Name;
            var dialogName = vmName
                .Substring(0, vmName.IndexOf("ViewModel"));

            var dialog = GetDialog(dialogName);
            dialog.DataContext = vm;

            if (vm is IExclusiveDialogViewModel)
            {   
                if (_visibleExclusiveDialog is null)
                {
                    _visibleExclusiveDialog = dialog;
                }
                else if (_visibleExclusiveDialog != dialog)
                {
                    _visibleExclusiveDialog.Hide();
                    _visibleExclusiveDialog = dialog;
                }
            }
            bool? result;
            result = dialog.ShowDialog();
            return result;
        }

        public bool? ShowDialog(
            string msg, 
            string title, 
            bool yesNoButtons = false, 
            bool yesNoCancelButtons = false)
        {
            var btns = MessageBoxButton.OK;
            if (yesNoButtons)
            {
                btns = MessageBoxButton.YesNo;
            }
            if (yesNoCancelButtons)
            {
                btns = MessageBoxButton.YesNoCancel;
            }
            var result = MessageBox.Show(msg, title, btns);
            var value = result == MessageBoxResult.Yes;
            return value;
        }

        private Dialog GetDialog(string dialogName)
        {
            Dialog value = null;
            foreach (var t in Assembly.GetEntryAssembly().GetTypes())
            {
                if (t.BaseType == typeof(Dialog)
                   || t.BaseType?.BaseType == typeof(Dialog))
                {
                    if (t.Name == dialogName)
                    {
                        value = (Dialog)Activator.CreateInstance(t);
                        break;
                    }
                }
            }
            return value;
        }
    }
}
