kkkusing System;
using Xamarin.Forms;

namespace SalaryExpenseTracker
{
    public class MainPage : ContentPage
    {
        private Entry salaryEntry;
        private Entry rentEntry;
        private Entry groceriesEntry;
        private Entry utilitiesEntry;
        private Entry transportationEntry;
        private Entry entertainmentEntry;
        private Label dailyLimitLabel;
        private double dailyLimit;
        private double groceries;
        private double utilities;
        private double transportation;
        private double entertainment;

        public MainPage()
        {
            salaryEntry = new Entry
            {
                Placeholder = "Enter monthly salary"
            };

            rentEntry = new Entry
            {
                Placeholder = "Enter monthly rent"
            };

            groceriesEntry = new Entry
            {
                Placeholder = "Enter monthly groceries expense"
            };

            utilitiesEntry = new Entry
            {
                Placeholder = "Enter monthly utilities expense"
            };

            transportationEntry = new Entry
            {
                Placeholder = "Enter monthly transportation expense"
            };

            entertainmentEntry = new Entry
            {
                Placeholder = "Enter monthly entertainment expense"
            };

            var calculateButton = new Button
            {
                Text = "Calculate",
                BackgroundColor = Color.Green,
                TextColor = Color.White
            };
            calculateButton.Clicked += OnCalculateButtonClicked;

            dailyLimitLabel = new Label
            {
                TextColor = Color.Green
            };

            var groceriesProgress = new ProgressBar
            {
                Progress = GroceriesProgress
            };

            var utilitiesProgress = new ProgressBar
            {
                Progress = UtilitiesProgress
            };

            var transportationProgress = new ProgressBar
            {
                Progress = TransportationProgress
            };

            var entertainmentProgress = new ProgressBar
            {
                Progress = EntertainmentProgress
            };

            var stackLayout = new StackLayout
            {
                Margin = 20,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    salaryEntry,
                    rentEntry,
                    groceriesEntry,
                    utilitiesEntry,
                    transportationEntry,
                    entertainmentEntry,
                    calculateButton,
                    dailyLimitLabel,
                    groceriesProgress,
                    utilitiesProgress,
                    transportationProgress,
                    entertainmentProgress
                }
            };

            Content = stackLayout;
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            double salary = double.Parse(salaryEntry.Text);
            double rent = double.Parse(rentEntry.Text);
            groceries = double.Parse(groceriesEntry.Text);
            utilities = double.Parse(utilitiesEntry.Text);
            transportation = double.Parse(transportationEntry.Text);
            entertainment = double.Parse(entertainmentEntry.Text);

            var currentMonth = DateTime.Now.Month;
            var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, currentMonth);

            dailyLimit = (salary - rent) / daysInCurrentMonth;
            dailyLimitLabel.Text = $"Your daily limit is {dailyLimit:0.##}";
        }

        private double GroceriesProgress
        {
            get
            {
                var currentMonth = DateTime.Now.Month;
                var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, currentMonth);
                return groceries / (dailyLimit * daysInCurrentMonth);
            }
        }

        private double UtilitiesProgress
        {
            get
            {
                var currentMonth = DateTime.Now.Month;
                var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, currentMonth);
                return utilities / (dailyLimit * daysInCurrentMonth);
            }
        }

        private double TransportationProgress
        {
            get
            {
                var currentMonth = DateTime.Now.Month;
                var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, currentMonth);
                return transportation / (dailyLimit * daysInCurrentMonth);
            }
        }

        private double EntertainmentProgress
        {
            get
            {
                var currentMonth = DateTime.Now.Month;
                var daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Now.Year, currentMonth);
                return entertainment / (dailyLimit * daysInCurrentMonth);
            }
        }
    }
}


