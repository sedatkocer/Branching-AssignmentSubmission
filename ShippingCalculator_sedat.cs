// Express Shipping Rate Calculator
// Developer: James Anderson
// Last Modified: March 2024
using System;
using System.Threading.Tasks;

namespace ShippingQuoteSystem
{
    class QuoteGenerator
    {
        static async Task Main(string[] args)
        {
            // Show program header
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            try
            {
                // Input package weight
                decimal weightValue = await GetUserInputAsync("Please enter the package weight:");

                // Maximum weight validation
                if (weightValue > 50)
                {
                    Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                    return;
                }

                // Input package dimensions
                decimal sizeW = await GetUserInputAsync("Please enter the package width:");
                decimal sizeH = await GetUserInputAsync("Please enter the package height:");
                decimal sizeL = await GetUserInputAsync("Please enter the package length:");

                // Calculate total size
                decimal totalDimensions = sizeW + sizeH + sizeL;

                // Maximum size validation
                if (totalDimensions > 50)
                {
                    Console.WriteLine("Package too big to be shipped via Package Express.");
                    return;
                }

                // Calculate shipping cost
                // Cost = (width * height * length * weight) / 100
                decimal shippingTotal = await CalculateShippingCostAsync(sizeW, sizeH, sizeL, weightValue);

                // Show shipping cost
                Console.WriteLine($"Your estimated total for shipping this package is: ${shippingTotal:F2}");
                Console.WriteLine("Thank you!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format entered.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static async Task<decimal> GetUserInputAsync(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(await Task.FromResult(Console.ReadLine()), out decimal result))
                {
                    if (result >= 0)
                        return result;
                    Console.WriteLine("Please enter a non-negative number.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        private static async Task<decimal> CalculateShippingCostAsync(decimal width, decimal height, decimal length, decimal weight)
        {
            return await Task.FromResult((width * height * length * weight) / 100);
        }
    }
} 