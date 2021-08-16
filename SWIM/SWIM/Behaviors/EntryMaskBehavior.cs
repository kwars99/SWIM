using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SWIM.Behaviors
{
    public class EntryMaskBehavior : Behavior<Entry>
    {
        private string mask = "";

        public string Mask
        {
            get => mask;
            set
            {
                mask = value;
            }
        }

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

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = sender as Entry;
            var text = entry.Text;

            if (!string.IsNullOrWhiteSpace(Mask))
            {
                // 1. Adding the MaxLength
                if (text.Length == mask.Length)
                {
                    entry.MaxLength = mask.Length;
                }     
            }

            // 2. Evaluating if the user is removing test
            if ((args.OldTextValue == null) || (args.OldTextValue.Length <= args.NewTextValue.Length))
            {
                // 3. Evaluating mask positions
                for (int i = Mask.Length; i >= text.Length; i--)
                {
                    if (Mask[(text.Length - 1)] != '#')
                    {
                        text = text.Insert((text.Length - 1), Mask[(text.Length - 1)].ToString());
                    }
                }
            }

            entry.Text = text;
        }
    }
}
