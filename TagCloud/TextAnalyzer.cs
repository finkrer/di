using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TagCloud
{
    public class TextAnalyzer : ITextAnalyzer
    {
        private readonly IEnumerable<string> stopWords;
        private readonly IEnumerable<string> partsOfSpeech;
        private readonly bool useStems;
        public IEnumerable<string> Text { get; }
        public IReadOnlyList<Word> WordList { get; private set; }
        public int MaxFrequency { get; private set; }
        
        public TextAnalyzer(IEnumerable<string> text, IEnumerable<string> stopWords, IEnumerable<string> partsOfSpeech = null, bool useStems = false)
        {
            this.stopWords = stopWords;
            this.partsOfSpeech = partsOfSpeech;
            this.useStems = useStems;
            Text = text;
            Analyze();
        }

        private void Analyze()
        {
            var frequencies = GetWordStats();
            WordList = frequencies.Select(kvp => new Word(kvp.Key, kvp.Value)).ToList();
        }

        private Dictionary<string, int> GetWordStats()
        {
            var wordFrequencies = new Dictionary<string, int>();
            var maxFrequency = 0;
            var words = Text
                .Select(w => w.ToLowerInvariant())
                .Select(w => Regex.Replace(w, @"(\W|\d)", string.Empty, RegexOptions.Compiled))
                .Where(w => !stopWords.Contains(w));
            foreach (var word in words)
            {
                if (!wordFrequencies.ContainsKey(word))
                    wordFrequencies[word] = 0;
                if (wordFrequencies[word]++ > maxFrequency)
                    maxFrequency++;
            }

            MaxFrequency = maxFrequency;
            return wordFrequencies;
        }
    }
}
