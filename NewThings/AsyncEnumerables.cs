using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewThings
{
    public class AsyncEnumerables
    {
        public async Task PrintDataItemsAsync()
        {
            await foreach (var item in LoadDataItemsAsync())
            {
                Console.WriteLine($"[{item.Number}] => {item.Name}");
            }
        }

        public async IAsyncEnumerable<(int Number, string Name)> LoadDataItemsAsync()
        {
            var numbers = Enumerable.Range(1, 10);

            foreach (var number in numbers)
            {
                yield return await LoadItemAsync(number);
            }
        }

        private async Task<(int Number, string Name)> LoadItemAsync(int number)
        {
            await Task.Delay(500);

            return (number, $"Item #{number}");
        }
    }
}
