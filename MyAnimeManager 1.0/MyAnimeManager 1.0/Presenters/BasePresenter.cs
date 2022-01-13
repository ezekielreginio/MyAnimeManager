using MyAnimeManager_1._0.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnimeManager_1._0.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        private IErrorMessageView _errorMessageView;

        public BasePresenter()
        {

        }
        BasePresenter(IErrorMessageView errorMessageView)
        {
            _errorMessageView = errorMessageView;
        }
        public void ShowErrorMessage(string windowTitle, string errorMessage)
        {
            ErrorMessageView errorMessageView = new ErrorMessageView();
            errorMessageView.ShowErrorMessageView(windowTitle, errorMessage);
        }
    }
}
