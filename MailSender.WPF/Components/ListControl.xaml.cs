using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MailSender.WPF.Components
{
    public partial class ListControl : UserControl
    {
        #region PanelName : string - Название панели

        /// <summary>Название панели</summary>
        public static readonly DependencyProperty PanelNameProperty =
            DependencyProperty.Register(
                nameof(PanelName),
                typeof(string),
                typeof(ListControl),
                new PropertyMetadata("Панель"));

        /// <summary>Название панели</summary>
        public string PanelName
        {
            get => (string) GetValue(PanelNameProperty);
            set => SetValue(PanelNameProperty, value);
        }

        #endregion

        #region Items : IEnumerable - Элементы списка

        /// <summary>Элементы списка</summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                nameof(Items),
                typeof(IEnumerable),
                typeof(ListControl),
                new PropertyMetadata(default(IEnumerable)));

        /// <summary>Элементы списка</summary>
        public IEnumerable Items
        {
            get => (IEnumerable) GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        #endregion

        #region SelectedElement : object - Выбранный элемент

        /// <summary>Выбранный элемент</summary>
        public static readonly DependencyProperty SelectedElementProperty =
            DependencyProperty.Register(
                nameof(SelectedElement),
                typeof(object),
                typeof(ListControl),
                new PropertyMetadata(default(object)));

        /// <summary>Выбранный элемент</summary>
        public object SelectedElement
        {
            get => (object) GetValue(SelectedElementProperty);
            set => SetValue(SelectedElementProperty, value);
        }

        #endregion

        #region DisplayMemberPath : string - Имя свойства, выводимого на экран

        /// <summary>Имя свойства, выводимого на экран</summary>
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(DisplayMemberPath),
                typeof(string),
                typeof(ListControl),
                new PropertyMetadata(default(string)));

        /// <summary>Имя свойства, выводимого на экран</summary>
        public string DisplayMemberPath
        {
            get => (string) GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        #endregion

        #region ItemTemplate : DataTemplate - Визуальный шаблон отображения данных

        /// <summary>Визуальный шаблон отображения данных</summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(ListControl),
                new PropertyMetadata(default(DataTemplate)));

        /// <summary>Визуальный шаблон отображения данных</summary>
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        #endregion

        #region CreateCommand : ICommand - Команда создания нового элемента

        /// <summary>Команда создания нового элемента</summary>
        public static readonly DependencyProperty CreateCommandProperty =
            DependencyProperty.Register(
                nameof(CreateCommand),
                typeof(ICommand),
                typeof(ListControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда создания нового элемента</summary>
        public ICommand CreateCommand
        {
            get => (ICommand) GetValue(CreateCommandProperty);
            set => SetValue(CreateCommandProperty, value);
        }

        #endregion

        #region EditCommand : ICommand - Команда редактирования выбранного элемента

        /// <summary>Команда редактирования выбранного элемента</summary>
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register(
                nameof(EditCommand),
                typeof(ICommand),
                typeof(ListControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда редактирования выбранного элемента</summary>
        public ICommand EditCommand
        {
            get => (ICommand) GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        #endregion

        #region DeleteCommand : ICommand - Команда удаления выбранного элемента

        /// <summary>Команда удаления выбранного элемента</summary>
        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(
                nameof(DeleteCommand),
                typeof(ICommand),
                typeof(ListControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Команда удаления выбранного элемента</summary>
        public ICommand DeleteCommand
        {
            get => (ICommand) GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        #endregion

        public ListControl() => InitializeComponent();
    }
}
