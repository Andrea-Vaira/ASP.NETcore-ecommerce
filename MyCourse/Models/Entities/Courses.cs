using System;
using System.Collections.Generic;
using MyCourse.Models.ValueTypes;

namespace MyCourse.Models.Entities
{
    public partial class Courses
    {
        public Courses(string title, string author)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Il titolo del corso non può essere nullo o vuoto");
            }
            if(string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("L'autore del corso non può essere nullo o vuoto");
            }

            Title = title;
            Author = author;

            Lessons = new HashSet<Lesson>();
        }

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public string Author { get; private set; }
        public string Email { get; private set; }
        public double Rating { get; private set; }
        public Money FullPrice { get; private set; }
        public Money CurrentPrice { get; private set; }

        public void ChangeTitle(string newTitle)
        {
            if(string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Il titolo del corso non può essere nullo o vuoto");
            }
            Title = newTitle;
        }

        public void ChangePrices(Money newFullPrice, Money newDiscountPrice)
        {
            if (newFullPrice == null || newDiscountPrice == null)
            {
                throw new ArgumentException("Prices can't be null");
            }
            if (newFullPrice.Currency != newDiscountPrice.Currency)
            {
                throw new ArgumentException("Currencies don't match");
            }
            if (newFullPrice.Amount < newDiscountPrice.Amount)
            {
                throw new ArgumentException("Full price can't be less than the current price");
            }
            FullPrice = newFullPrice;
            CurrentPrice = newDiscountPrice;
        }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
