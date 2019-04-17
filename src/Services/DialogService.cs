using GalaSoft.MvvmLight.Ioc;
using Microsoft.Win32;
using Savaged.BlackNotepad.ViewModels;
using System;
using System.Reflection;
using System.Windows;

namespace Savaged.BlackNotepad.Services
{
    public class DialogService : IDialogService
    {
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

            var result = dialog.ShowDialog();
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

        private Window GetDialog(string dialogName)
        {
            Window value = null;
            foreach (var t in Assembly.GetEntryAssembly().GetTypes())
            {
                if (t.BaseType == typeof(Window)
                   || t.BaseType?.BaseType == typeof(Window))
                {
                    if (t.Name == dialogName)
                    {
                        value = (Window)Activator.CreateInstance(t);
                        break;
                    }
                }
            }
            return value;
        }
    }
}
