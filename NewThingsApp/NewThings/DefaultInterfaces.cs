using System;

namespace NewThings
{
    public class DefaultInterfaces
    {
        private readonly IDefaultInterface defaults = new DefaultImplementation();

        public void PrintCreations()
        {
            var number = defaults.CreateRandomNumber();

            //var guid = defaults.CreateGuid(true);
        }
    }

    public class DefaultImplementation : IDefaultInterface
    {
        private readonly Random random = new Random();

        public double CreateRandomNumber()
        {
            var number = random.NextDouble();
            return number;
        }
    }

    public interface IDefaultInterface
    {
        double CreateRandomNumber();

        //string CreateGuid(bool shorter)
        //{
        //    var guid = Guid.NewGuid().ToString("N");
        //    if (shorter)
        //        guid = guid.Substring(0, 8);
        //    return guid;
        //}
    }
}
