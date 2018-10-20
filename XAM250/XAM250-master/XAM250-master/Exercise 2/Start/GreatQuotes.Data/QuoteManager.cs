using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GreatQuotes.GreatQuotes;

namespace GreatQuotes.Data
{
    public class QuoteManager
    {
        static readonly Lazy<QuoteManager> instance = new Lazy<QuoteManager>(() => new QuoteManager());
        public static QuoteManager Instance { get { return instance.Value; } }

        readonly IQuoteLoader repo;
        public IList<GreatQuote> Quotes { get; private set; }

        private QuoteManager()
        {
            repo = QuoteLoaderFactory.Create();
            Quotes = new ObservableCollection<GreatQuote>(repo.Load());
        }

        public void Save()
        {
            repo.Save(Quotes);
        }

        public void SayQuote(GreatQuote quote)
        {
            if (quote == null)
                throw new ArgumentNullException("quote");

            ITextToSpeech tts = ServiceLocator.Instance.Resolve<ITextToSpeech>();

            var text = quote.QuoteText;

            if (!string.IsNullOrWhiteSpace(quote.Author))
                text += $" by {quote.Author}";

            tts.Speak(text);

        }
    }
}
