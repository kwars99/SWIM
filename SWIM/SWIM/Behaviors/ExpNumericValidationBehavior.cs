using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SWIM.Behaviors
{
    public class ExpNumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            string input = args.NewTextValue.Replace(@"/", "");

            bool isValid = input.All(c => Char.IsDigit(c));

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
