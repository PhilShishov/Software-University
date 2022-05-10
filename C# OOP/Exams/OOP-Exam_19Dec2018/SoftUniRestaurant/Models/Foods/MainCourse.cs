﻿namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int InitialServingSize = 500;

        public MainCourse(string name, decimal price)
            : base(name, InitialServingSize, price)
        {
        }
    }
}
