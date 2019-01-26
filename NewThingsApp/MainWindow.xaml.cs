using System;
using System.Windows;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
using NewThings;

namespace NewThingsApp
{
    public partial class MainWindow : Window
    {
        private readonly NullableReferenceTypes nullRefs = new NullableReferenceTypes();
        private readonly AsyncEnumerables asyncEnums = new AsyncEnumerables();
        private readonly RangesAndIndices ranges = new RangesAndIndices();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnExitClicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnMapLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is MapControl map)
            {
                var microsoftCapeTown = new BasicGeoposition { Latitude = -33.947285, Longitude = 18.490868 };
                var sandtonConvention = new BasicGeoposition { Latitude = -26.104620, Longitude = 28.055849 };

                map.TrySetViewAsync(new Geopoint(sandtonConvention), 16);
            }
        }

        // Nullable Reference Types

        private void OnGeneratePeopleClicked(object sender, RoutedEventArgs e)
        {
            nullRefs.GeneratePeople();
            UpdatePeopleList();
        }

        private void OnAddPersonClicked(object sender, RoutedEventArgs e)
        {
            var personDialog = new PersonDialog();
            if (personDialog.ShowDialog() == true)
            {
                nullRefs.AddPerson(personDialog.FirstName, null, personDialog.LastName);
                UpdatePeopleList();
            }
        }

        private void UpdatePeopleList()
        {
            peopleList.ItemsSource = nullRefs.GetPeople();
        }

        // Async Enumerables

        private async void OnLoadDataClicked(object sender, RoutedEventArgs e)
        {
            dataList.Items.Clear();

            await foreach (var item in asyncEnums.LoadDataItemsAsync())
            {
                dataList.Items.Add(item);
            }
        }

        // Ranges & Indices

        private void OnSelectItemFromStart(object sender, RoutedEventArgs e)
        {
            try
            {
                var number = int.Parse(fromIndexTextBox.Text);
                rangeLabel.Text = $"Number: {ranges.SelectFromStart(number)}";
            }
            catch (Exception ex)
            {
                rangeLabel.Text = $"Error: {ex.GetType().Name}";
            }
        }

        private void OnSelectItemFromEnd(object sender, RoutedEventArgs e)
        {
            try
            {
                var number = int.Parse(fromIndexTextBox.Text);
                rangeLabel.Text = $"Number: {ranges.SelectFromEnd(number)}";
            }
            catch (Exception ex)
            {
                rangeLabel.Text = $"Error: {ex.GetType().Name}";
            }
        }

        private void OnSelectItemRange(object sender, RoutedEventArgs e)
        {
            try
            {
                var from = int.Parse(fromRangeTextBox.Text);
                var to = int.Parse(toRangeTextBox.Text);
                rangeLabel.Text = $"Range: [ {string.Join(", ", ranges.SelectRange(from, to))} ]";
            }
            catch (Exception ex)
            {
                rangeLabel.Text = $"Error: {ex.GetType().Name}";
            }
        }
    }
}
