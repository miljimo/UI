
using Base.Data;
using System;
using System.Windows.Input;

namespace Firealarm.ViewModels
{
    /// <summary>
    ///  The base viewmodel that all other view model have to derived from indirectly or directly
    /// </summary>
    public abstract class BaseViewModel :  BasePropertyChanged
    {
       
        private IResource        __Resource;
        private BaseViewModel    __Parent;

        #region Contructors     
  
        public  BaseViewModel(BaseViewModel Parent, IResource Resource)
        {
            __Parent   = Parent;
            __Resource = Resource;
        }

        /// <summary>
        ///   The parent view model.
        /// </summary>
        public BaseViewModel Parent
        {
            get
            {
                return __Parent;
            }
            set
            {
                if( (__Parent != value) && (__Parent == null))
                {
                    __Parent = value;
                    RaisePropertyChanged("Parent");
                }
            }
        }

        #endregion


        #region Resource Accessing
        /// <summary>
        ///  The function  get the resource of the applications 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ResId"></param>
        /// <returns></returns>
        public virtual T Localize<T>(string ResId)
        {
            return (T)Resource.Localize<object>(ResId);
        }
        /// <summary>
        ///  THe application resources object class.
        /// </summary>
        public   IResource Resource
        {
            get
            {
                return __Resource ;
            }
           private  set
            {
                if (value != __Resource )
                {
                    __Resource = value;
                    RaisePropertyChanged("Resources");
                }
            }
        }

        #endregion

       
        #region Create New Command Methods
        /// <summary>
        ///  The function created a relay command to the ModelView
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Action"></param>
        /// <param name="Predicate"></param>
        /// <returns></returns>
         protected ICommand CreateCommand<T> (Action<T> Action , Predicate<T> Predicate = null)
        {
            return new RelayCommand<T>(Action, Predicate);
           
        }

        /// <summary>
        /// The function create a relay command for the view model.
        /// </summary>
        /// <param name="Action"></param>
        /// <param name="Predicate"></param>
        /// <returns></returns>
        protected ICommand CreateCommand(Action<object> Action, Predicate<object> Predicate = null)
        {
            return CreateCommand<object>(Action, Predicate);
        }
        #endregion


    }
}
