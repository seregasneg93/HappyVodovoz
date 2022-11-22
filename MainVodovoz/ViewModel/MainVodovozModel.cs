using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.ViewModelBases;

namespace MainVodovoz.ViewModel
{
    public class MainVodovozModel : ViewModelBase
    {
        private string _titleJouernalErrors = ""; // 
        public string TitleJouernalErrors
        {
            get => _titleJouernalErrors;
            set
            {
                _titleJouernalErrors = value;
                OnPropeertyChanged();
            }
        }

        public MainVodovozModel()
        {
                
        }
    }
}
