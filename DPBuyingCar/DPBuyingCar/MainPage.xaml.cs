using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DPBuyingCar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// we process and check for any invalid input the form and set the result value to the input/entry values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDesignCar_Clicked(object sender, EventArgs e)
        {
            // Variables for make, color, condition, price
            string make = "", color = "", condition = "";
            decimal price = 0m;
            //use our methods below to check if our inputs were correctly entered. 
            if (MakeIsValid(ref make))
            {
                if (ColorIsValid(ref color))
                {
                    price = GetValidPrice();
                    if (price > -1)
                    {
                        condition = SetCondition();
                        DisplayMyCar(make, color, price, condition);
                    }
                }
            }
        }
        /// <summary>
        /// changes results text to whatever our entry and picker values were
        /// </summary>
        /// <param name="make"></param>
        /// <param name="color"></param>
        /// <param name="price"></param>
        /// <param name="condition"></param>
        private void DisplayMyCar(string make, string color, decimal price, string condition)
        {
            //using template literals (? might be a javascript term) to concatenate a string for the results label
            LblResults.Text = $"{condition} {color} {make} for {price.ToString("c")}";
        }

        /// <summary>
        /// checks if condition is true or false and returns new or used
        /// </summary>
        /// <returns></returns>
        private string SetCondition()
        {

            //string condition = "";
            //if (SwtchCondition.IsToggled) condition = "New";
            //else condition = "Used";
            //we use a ternary operator to check if swtCondition is true or false and return "new" or "used" respectively
            return SwtchCondition.IsToggled ? "New" : "Used"; 
        }

        /// <summary>
        /// checks if the make is a valid input
        /// </summary>
        /// <param name="m"></param>
        /// <returns> returns true or false </returns>
        private bool MakeIsValid(ref string m)
        {
            //
            if (PckMake.SelectedIndex > -1)
            {
                m = PckMake.SelectedItem.ToString();
                return true;
            }
            else
            {
                DisplayAlert("Invalid Input", "Please select a make", "Close");
                return false;
            }
        }
        /// <summary>
        /// checks if the color is a valid input and returns true or false
        /// </summary>
        /// <param name="c"></param>
        /// <returns>boolean</returns>
        private bool ColorIsValid(ref string c)
        {
            // checks if an index is valid then turns it into a string and returns true. else displays error and returns false
            if (PckMake.SelectedIndex > -1)
            {
                c = PckColor.SelectedItem.ToString();
                return true;
            }
            else
            {
                DisplayAlert("Invalid Input", "Please select a color", "Close");
                return false;
            }
        }
        /// <summary>
        /// checks if the price is a positive decimal value and returns price. else returns -1 and an alert. 
        /// </summary>
        /// <returns>price</returns>
        private decimal GetValidPrice()
        {
            if (decimal.TryParse(EntryPrice.Text, out decimal price) && price >= 0)
            {
                return price;
            }
            else
            {
                DisplayAlert("Invalid Input", "Please enter a price for the car", "Close");

                return -1;
            }
        }
    }
}
