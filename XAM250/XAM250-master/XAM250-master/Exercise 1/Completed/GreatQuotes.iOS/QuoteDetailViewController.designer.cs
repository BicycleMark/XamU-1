// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace GreatQuotes
{
    [Register ("QuoteDetailViewController")]
    partial class QuoteDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Author { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Quote { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Author != null) {
                Author.Dispose ();
                Author = null;
            }

            if (Quote != null) {
                Quote.Dispose ();
                Quote = null;
            }
        }
    }
}