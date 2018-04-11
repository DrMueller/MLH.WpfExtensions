using System.Windows;
using System.Windows.Input;

namespace Mmu.Mlh.WpfExtensions.Areas.DependencyProperties
{
    public static class MouseMoveCommandBinding
    {
        public static readonly DependencyProperty MouseMoveCommandProperty =
            DependencyProperty.RegisterAttached(
                "MouseMoveCommand",
                typeof(ICommand),
                typeof(MouseMoveCommandBinding),
                new PropertyMetadata(null, MouseMoveCommandPropertyChangedCallback));
        public static readonly DependencyProperty MouseMoveCommandParameterProperty =
            DependencyProperty.RegisterAttached(
                "MouseMoveCommandParameter",
                typeof(object),
                typeof(MouseMoveCommandBinding),
                new PropertyMetadata(null, null));

        public static ICommand GetMouseMoveCommand(DependencyObject dependencyObject) => (ICommand)dependencyObject.GetValue(MouseMoveCommandProperty);

        public static object GetMouseMoveCommandParameter(DependencyObject dependencyObject) => dependencyObject.GetValue(MouseMoveCommandParameterProperty);

        public static void SetMouseMoveCommand(DependencyObject dependencyObject, ICommand value)
        {
            dependencyObject.SetValue(MouseMoveCommandProperty, value);
        }

        public static void SetMouseMoveCommandParameter(DependencyObject dependencyObject, object value)
        {
            dependencyObject.SetValue(MouseMoveCommandParameterProperty, value);
        }

        private static void MouseMoveCommandPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is UIElement uiElement))
            {
                return;
            }

            if (e.OldValue != null)
            {
                uiElement.RemoveHandler(UIElement.MouseMoveEvent, new MouseEventHandler(OnMouseMove));
            }
            if (e.NewValue != null)
            {
                uiElement.AddHandler(UIElement.MouseMoveEvent, new MouseEventHandler(OnMouseMove), true);
            }
        }

        private static void OnMouseMove(object sender, MouseEventArgs e)
        {
            var uiElement = sender as UIElement;

            if (!(uiElement?.GetValue(MouseMoveCommandProperty) is ICommand cmd))
            {
                return;
            }

            var parameter = uiElement.GetValue(MouseMoveCommandParameterProperty);

            if (cmd.CanExecute(parameter))
            {
                cmd.Execute(parameter);
            }
        }
    }
}