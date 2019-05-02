using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasWebNetCore.UIForms.ViewModels
{
    public class MainViewModel
    {
        public LoginViewModel Login { get; set; }

        public MainViewModel()
        {
            //TODO: cambiar
            this.Login = new LoginViewModel();
        }
    }
}
