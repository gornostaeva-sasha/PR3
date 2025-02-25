using System;
using System.Windows;
using System.Windows.Controls;

namespace PR3
{
    public partial class MainWindow : Window
    {
        private const decimal AssistantRate = 150;
        private const decimal DocentRate = 250;
        private const decimal ProfessorRate = 350;
        private const decimal TaxRate = 0.13m;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {

            txtGrossTotal.Text = "";
            txtTaxAmount.Text = "";
            txtNetTotal.Text = "";

            CalculateSalary();
        }

        private void CalculateSalary()
        {
            decimal hours;

            if (!decimal.TryParse(txtHours.Text, out hours))
            {
                MessageBox.Show("Некорректный ввод часов. Введите числовое значение.");
                return;
            }

            if (hours < 0)
            {
                MessageBox.Show("Количество часов не может быть отрицательным.");
                return;
            }

            if (hours > 168)
            {
                MessageBox.Show("Слишком большое количество часов.");
                return;
            }

            decimal rate = 0;
            if (rbAssistant.IsChecked == true)
            {
                rate = AssistantRate;
            }
            else if (rbDocent.IsChecked == true)
            {
                rate = DocentRate;
            }
            else if (rbProfessor.IsChecked == true)
            {
                rate = ProfessorRate;
            }
            else
            {
                MessageBox.Show("Выберите должность.");
                return;
            }

            decimal grossTotal = hours * rate; // Зарплата до уплаты налогов
            decimal taxAmount = 0;
            decimal netTotal = grossTotal; // Зарплата после уплаты налогов

            if (cbTax.IsChecked == true)
            {
                taxAmount = grossTotal * TaxRate;
                netTotal = grossTotal - taxAmount;
            }

            txtGrossTotal.Text = grossTotal.ToString("F2");
            txtTaxAmount.Text = taxAmount.ToString("F2");
            txtNetTotal.Text = netTotal.ToString("F2");
        }
    }
}
