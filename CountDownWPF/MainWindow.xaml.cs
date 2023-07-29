using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CountDownWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // G l o b a l   V a r i a b l e s
        public List<string> word01 = new();
        public List<string> word02 = new();
        public List<string> word03 = new();
        public List<string> word04 = new();
        public List<string> word05 = new();
        public List<string> word06 = new();
        public List<string> word07 = new();
        public List<string> word08 = new();
        public List<string> word09 = new();
        public List<string> word10 = new();
        public List<string> word11 = new();
        public List<string> word12 = new();
        public List<string> word13 = new();
        public List<string> word14 = new();
        public List<string> word15 = new();
        public List<string> word16 = new();
        public List<string> word17 = new();
        public List<string> word18 = new();
        public List<string> word19 = new();
        public List<string> word20 = new();
        public List<string> word21 = new();

        const string alpha = "abcdefghijklmnopqrstuvwxyz";
        const string vowels = "aeiou";
        const string consonant = "bcdfghjklmnpqrstvwxyz";

        public MainWindow()
        {
            InitializeComponent();

            LoadWords(word01, word02, word03, word04, word05, word06, word07, word08, word09, word10,
                word11, word12, word13, word14, word15, word16, word17, word18, word19, word20, word21);

            WireUpMaxLettersCB();
            WireUpCountToCB();
            WireUpMinVowelsCB();

            int TotalWords = word01.Count + word02.Count + word03.Count + word04.Count +
                            word05.Count + word06.Count + word07.Count + word08.Count +
                            word09.Count + word10.Count + word11.Count + word12.Count +
                            word13.Count + word14.Count + word15.Count + word16.Count +
                            word17.Count + word18.Count + word19.Count + word20.Count +
                            word21.Count;

            lblTotalWords.Content = $"Total Words: {TotalWords}";

            lblCompleted.Content = "";
        }

        // ************************************
        private static void LoadWords(List<string> word01, List<string> word02, List<string> word03, List<string> word04,
            List<string> word05, List<string> word06, List<string> word07, List<string> word08,
            List<string> word09, List<string> word10, List<string> word11, List<string> word12,
            List<string> word13, List<string> word14, List<string> word15, List<string> word16,
            List<string> word17, List<string> word18, List<string> word19, List<string> word20,
            List<string> word21)
        {
            string folder = @"C:\Users\we364\source\repos\CountDownApp\CountDown";
            string file = "ukenglish.txt";
            string[] words = System.IO.File.ReadAllLines(folder + "\\" + file);

            foreach (string word in words)
            {
                switch (word.Length)
                {
                    case 1:
                        word01.Add(word);
                        break;

                    case 2:
                        word02.Add(word);
                        break;

                    case 3:
                        word03.Add(word);
                        break;

                    case 4:
                        word04.Add(word);
                        break;

                    case 5:
                        word05.Add(word);
                        break;

                    case 6:
                        word06.Add(word);
                        break;

                    case 7:
                        word07.Add(word);
                        break;

                    case 8:
                        word08.Add(word);
                        break;

                    case 9:
                        word09.Add(word);
                        break;

                    case 10:
                        word10.Add(word);
                        break;

                    case 11:
                        word11.Add(word);
                        break;

                    case 12:
                        word12.Add(word);
                        break;

                    case 13:
                        word13.Add(word);
                        break;

                    case 14:
                        word14.Add(word);
                        break;

                    case 15:
                        word15.Add(word);
                        break;

                    case 16:
                        word16.Add(word);
                        break;

                    case 17:
                        word17.Add(word);
                        break;

                    case 18:
                        word18.Add(word);
                        break;

                    case 19:
                        word19.Add(word);
                        break;

                    case 20:
                        word20.Add(word);
                        break;

                    case 21:
                        word21.Add(word);
                        break;

                    default:
                        break;
                }
            }
        }

        // ************************************
        private void WireUpMaxLettersCB()
        {
            cbMaxLetters.Items.Clear();

            cbMaxLetters.Items.Add("*");

            for (int i = 1; i < 22; i++)
            {
                cbMaxLetters.Items.Add(i.ToString());
            }

            cbMaxLetters.SelectedValue = "9";
        }

        // ************************************
        private void WireUpCountToCB()
        {
            cbCountTo.Items.Clear();

            for (int i = 0; i < 100; i++)
            {
                cbCountTo.Items.Add(i.ToString());
            }

            cbCountTo.SelectedValue = "10";
        }

        // ************************************
        private void WireUpMinVowelsCB()
        {
            cbMinVowels.Items.Clear();

            for (int i = 0; i < 10; i++)
            {
                cbMinVowels.Items.Add(i.ToString());
            }

            cbMinVowels.SelectedValue = "3";
        }

        // ************************************
        private void SelectionChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            lblLetterCount.Content = $"({tbSelection.Text.Length})";
            lblCompleted.Content = "";

            string text = tbSelection.Text;
            int MaxLetters = int.Parse(cbMaxLetters.Text);

            // Make sure that the Number of letters do not exceed the maxLetter value
            // * = Unlimited
            if (cbMaxLetters.Text != "*")
            {
                if (text.Length > MaxLetters)
                {
                    tbSelection.Text = text.Substring(0, MaxLetters);
                }
            }

            // Check that the letters contain sufficent Vowels
            int VowelCount = 0;
            string selectedText = tbSelection.Text.Trim();
            foreach (var v in vowels)
            {
                if (tbSelection.Text.Contains(v))
                {
                    // count multiply time a letter occures
                    VowelCount += selectedText.Count(f => (f == v));
                }
            }

            lblVowelCount.Content = VowelCount.ToString();
            lblConstCount.Content = (tbSelection.Text.Count() - VowelCount).ToString();

            // If there is the correct number of letters, allow a search to take place
            if (text.Length != MaxLetters)
            {
                btSearch.IsEnabled = false;
            }
            else
            {
                btSearch.IsEnabled = true;
            }
        }

        // ************************************
        private string RemoveNonAlpha(string input)
        {
            // This could have been done with a REGEX in the SelectionChanged method

            char[] inputArray = input.ToCharArray();
            string output = "";

            foreach (char c in inputArray)
            {
                if (alpha.Contains(c))
                {
                    output = output + c.ToString();
                }
            }
            return output;
        }

        // ************************************
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            int count = 0;
            tbSelection.Text = tbSelection.Text.Trim().ToLower();
            string selectedText = tbSelection.Text;
            selectedText = RemoveNonAlpha(selectedText);
            tbResults.Text = "";
            int size = selectedText.Length;
            int countTo = int.Parse(cbCountTo.Text);
            lblCompleted.Content = "";
            int MinVowels = int.Parse(cbMinVowels.Text);
            int VowelCount = int.Parse((string)lblVowelCount.Content);

            if (VowelCount >= MinVowels)
            {
                if (size == 21)
                {
                    tbResults.AppendText(checkwords(word21, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 20)
                {
                    tbResults.AppendText(checkwords(word20, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 19)
                {
                    tbResults.AppendText(checkwords(word19, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 18)
                {
                    tbResults.AppendText(checkwords(word18, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 17)
                {
                    tbResults.AppendText(checkwords(word17, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 16)
                {
                    tbResults.AppendText(checkwords(word16, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 15)
                {
                    tbResults.AppendText(checkwords(word15, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 14)
                {
                    tbResults.AppendText(checkwords(word14, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 13)
                {
                    tbResults.AppendText(checkwords(word13, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 12)
                {
                    tbResults.AppendText(checkwords(word12, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 11)
                {
                    tbResults.AppendText(checkwords(word11, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 10)
                {
                    tbResults.AppendText(checkwords(word10, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 9)
                {
                    tbResults.AppendText(checkwords(word09, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 8)
                {
                    tbResults.AppendText(checkwords(word08, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 7)
                {
                    tbResults.AppendText(checkwords(word07, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 6)
                {
                    tbResults.AppendText(checkwords(word06, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 5)
                {
                    tbResults.AppendText(checkwords(word05, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 4)
                {
                    tbResults.AppendText(checkwords(word04, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 3)
                {
                    tbResults.AppendText(checkwords(word03, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                if (size >= 2)
                {
                    tbResults.AppendText(checkwords(word02, selectedText, ref count, countTo));
                    lblWordsFound.Content = count.ToString();
                }

                lblCompleted.Content += " * C O M P L E T E D *";
            }
        }

        // ************************************
        private string checkwords(List<string> words, string selection, ref int count, int maxWords)
        {
            StringBuilder sb = new();

            sb.Append($"{words[0].Length} - ");

            foreach (var w in words)
            {
                if (maxWords != 0)
                {
                    if (contains(w, selection) && count != maxWords)
                    {
                        sb.Append($"{w}, ");
                        count++;
                    }
                }
                else
                {
                    if (contains(w, selection))
                    {
                        sb.Append($"{w}, ");
                        count++;
                    }
                }
            }

            sb.Append("\n");

            return sb.ToString();
        }

        // ************************************
        private static bool contains(string word, string letters)
        {
            int[] alphabet = new int[26];

            foreach (var l in letters)
            {
                int pos = alpha.IndexOf(l);

                if (pos > -1)
                {
                    alphabet[pos]++;
                }
            }

            foreach (var w in word)
            {
                int pos = alpha.IndexOf(w);

                if (pos > -1)
                {
                    alphabet[pos]--;
                }
            }

            foreach (var count in alphabet)
            {
                if (count < 0)
                {
                    return false;
                }
            }

            return true;
        }

        // ************************************
        private void RandomClick(object sender, RoutedEventArgs e)
        {
            int Vowels = int.Parse(cbMinVowels.Text);
            int len = int.Parse(cbMaxLetters.Text);

            string output = "";

            for (int i = 0; i < Vowels; i++)
            {
                output += RndChoose(vowels);
            }

            for (int i = Vowels; i < len; i++)
            {
                output += RndChoose(consonant);
            }

            tbSelection.Text = output;
        }
        // ************************************
        private string RndChoose(string input)
        {
            char[] inputArray = input.ToCharArray();

            int max = inputArray.Count();

            Random rnd = new();

            return inputArray[rnd.Next(max)].ToString();
        }
        // ************************************
    }
}