using System;
using System.Collections.Generic;
using System.Linq;


namespace Firealarm
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
     
    
       
        public BaseWindow()
        {
            InitializeComponent();
            Title = "Untitled";
        }

        DependencyProperty IsDraggableProperty = CreateProperty<BaseWindow, bool>("IsDraggable", true);

        public bool IsDraggable
        {
            get
            {
                return (bool)GetValue(IsDraggableProperty);
            }
            set
            {
                if ((bool)GetValue(IsDraggableProperty) != value)
                {
                    SetValue(IsDraggableProperty,value);
                }
            }
        }

        DependencyProperty TitleBarHeightProperty = CreateProperty<BaseWindow, double>("TitleBarHeight", 10.0);

        public double  TitleBarHeight
        {
            get
            {
                return (double)GetValue(TitleBarHeightProperty);
            }
            set
            {
                if ((double)GetValue(TitleBarHeightProperty) != value)
                {
                    SetValue(IsDraggableProperty, value);
                }
            }
        }

      
        #region Mouse Drag handling for basic window
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (IsDraggable)
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    Point point = e.GetPosition(this);

                    if (((point.X > 0) && (point.X < this.Width))
                         && (point.Y < TitleBarHeight))
                    {
                        this.DragMove();
                    }
                  
                }
            }
        }
        #endregion

        /// <summary>
        ///  The static function is used to created 
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <typeparam name="ObjectType"></typeparam>
        /// <param name="Name"></param>
        /// <param name="DefaultValue"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        static protected DependencyProperty CreateProperty<Parent, ObjectType>(string Name,
                                                           ObjectType DefaultValue = default(ObjectType),
                                                           PropertyChangedCallback Action = null)

        {
            return DependencyProperty.Register(Name, typeof(ObjectType), typeof(Parent),
                                             new FrameworkPropertyMetadata(DefaultValue,
                                             FrameworkPropertyMetadataOptions.AffectsRender, Action));
        }




    }
}
