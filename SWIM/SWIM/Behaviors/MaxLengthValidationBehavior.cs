using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SWIM.Behaviors
{
    public class MaxLengthValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", 
                                                               typeof(int), typeof(MaxLengthValidationBehavior), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs args)
        {
            if (args.NewTextValue.Length >= MaxLength)
            {
                ((Entry)sender).Text = args.NewTextValue.Substring(0, MaxLength);
            }
        }
    }
}
