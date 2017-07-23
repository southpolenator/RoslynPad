using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Immutable;
using System.Globalization;

namespace RoslynPad.Roslyn.Completion
{
    public sealed class CompletionHelper
    {
        private readonly Microsoft.CodeAnalysis.Completion.CompletionHelper _inner;

        private CompletionHelper(Microsoft.CodeAnalysis.Completion.CompletionHelper inner)
        {
            _inner = inner;
        }

        public static CompletionHelper GetHelper(Document document, CompletionService service)
        {
            return new CompletionHelper(Microsoft.CodeAnalysis.Completion.CompletionHelper.GetHelper(document));
        }

        public int CompareItems(CompletionItem item1, CompletionItem item2, string pattern, CultureInfo culture)
        {
            return _inner.CompareItems(item1, item2, pattern, culture);
        }

        public ImmutableArray<TextSpan> GetHighlightedSpans(string text, string pattern, CultureInfo culture)
        {
            return _inner.GetHighlightedSpans(text, pattern, culture);
        }

        public bool MatchesPattern(string text, string pattern, CultureInfo culture)
        {
            return _inner.MatchesPattern(text, pattern, culture);
        }

        public bool MatchesFilterText(CompletionItem item, string filterText)
        {
            return MatchesPattern(item.FilterText, filterText, CultureInfo.InvariantCulture);
        }
    }
}