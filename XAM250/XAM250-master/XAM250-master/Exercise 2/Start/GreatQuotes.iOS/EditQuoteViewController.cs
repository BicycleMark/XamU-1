using System;
using GreatQuotes.Data;
using UIKit;

namespace GreatQuotes
{
	partial class EditQuoteViewController : UIViewController
	{
		GreatQuote quote;

		public EditQuoteViewController (IntPtr handle) : base (handle)
		{
		}

		public void SetQuote(GreatQuote value)
		{
			quote = value;
			UpdateView();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            this.SaveButton.TouchUpInside += (sender, e) => {
                if (string.IsNullOrEmpty(Author.Text)
                    || string.IsNullOrEmpty(Quote.Text))
                {
                    new UIAlertView("Validation problem", 
                        "Please set an author and a quote.", null, "OK")
                        .Show();
                    return;
                }
                quote.Author = Author.Text;
                quote.QuoteText = Quote.Text;
                NavigationController.PopViewController(true);
               // Quote.AddGestureRecognizer(new UITapGestureRecognizer(() => QuoteManager.Instance.SayQuote(quote)));
            };

			UpdateView();
		}

		void UpdateView()
		{
			if (IsViewLoaded && quote != null) {
				this.Author.Text = quote.Author;
				this.Quote.Text = quote.QuoteText;
			}
		}
	}
}
