using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleExerciseWPF
{
    public partial class MainWindow : Window
    {
        int count = 0;
        double sum = 0;

        public MainWindow()
        {
            InitializeComponent();
            ProgramInitialization();
        }

        private void ProgramInitialization()
        {
            buttonClicker.Click += ButtonClick;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            count++;
            clickCount.Content = $"Ilość: {count}";
        }

        private void TxtInputEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBox.Show(txtInput.Text);
            }
        }

        private void InputMethod(object sender, RoutedEventArgs e)
        {
            if (numInput1.Text != "" && numInput2.Text != "")
            {
                try
                {
                    if(numInput2.Text == "0") throw new DivideByZeroException();
                    else
                    {
                        double result = double.Parse(numInput1.Text) / double.Parse(numInput2.Text);
                        resultLabel.Content = $"Wynik: {result}";
                    }
                }
                catch (DivideByZeroException dx)
                {
                    resultLabel.Content = dx.Message;
                }
                catch(FormatException fx)
                {
                    resultLabel.Content = fx.Message;
                }
                catch(Exception ex)
                {
                    resultLabel.Content = ex.Message;
                }
            }
        }

        private void InputSumMethod(object sender, RoutedEventArgs e)
        {
            string[] numbers = sumInput.Text.Split(",");
            double sum = 0;
            int elemCount = 0;
            string[] numberStrings = sumInput.Text.Split(',');

            List<double> numbers2 = new List<double>();

            foreach (string numString in numberStrings)
            {
                string cleanNumString = new string(numString.Where(c => char.IsDigit(c)).ToArray());
                if (!string.IsNullOrEmpty(cleanNumString))
                {
                    numbers2.Add(double.Parse(cleanNumString));
                }
            }

            // Convert the list to an array if needed
            double[] numbersArray = numbers2.ToArray();

            // Bubble sort algorithm
            for (int i = 0; i < numbersArray.Length - 1; i++)
            {
                for (int j = i + 1; j < numbersArray.Length; j++)
                {
                    if (numbersArray[i] > numbersArray[j])
                    {
                        double temp = numbersArray[i];
                        numbersArray[i] = numbersArray[j];
                        numbersArray[j] = temp;
                    }
                }
            }

            // Join sorted numbers into a single string for display
            string sortedNumbers = string.Join(", ", numbersArray);
            sortLabel.Content = sortedNumbers;


            foreach (var numberStr in numbers)
            {
                if (double.TryParse(numberStr, out double number))
                {
                    sum += number;
                    elemCount++;
                }
            }
            
            sumLabel.Content = $"Suma: {sum}";
            loopCount.Content = $"Ilość cyfr: {elemCount}";
        }

    }
}
