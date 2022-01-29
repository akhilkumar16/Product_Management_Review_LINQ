using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductReviewManagementWithLinq
{
    /// <summary>
    /// Master branch of "Product Review Management"
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program of Product Review Management");
            // Uc1//
            List<ProductReview> ProductReviewlist = new List<ProductReview>()
            {
                new ProductReview() { ProductID = 1, UserID = 1, Rating = 5, Review = "Good", isLike = true },
                new ProductReview() { ProductID = 2, UserID = 2, Rating = 4, Review = "Nice", isLike = true },
                new ProductReview() { ProductID = 3, UserID = 3, Rating = 3, Review = "Good", isLike = false },
                new ProductReview() { ProductID = 4, UserID = 4, Rating = 2, Review = " Nice", isLike = true},
                new ProductReview() { ProductID = 5, UserID = 5, Rating = 1, Review = "Avg", isLike = true },
                new ProductReview() { ProductID = 6, UserID = 6, Rating = 5, Review = "Nice", isLike = false },
                new ProductReview() { ProductID = 7, UserID = 7, Rating = 4, Review = "Nice", isLike = true },
                new ProductReview() { ProductID = 8, UserID = 8, Rating = 3, Review = "Good", isLike = true },
                new ProductReview() { ProductID = 9, UserID = 9, Rating = 2, Review = "Nice", isLike = false },
                new ProductReview() { ProductID = 10, UserID = 10, Rating = 1, Review = "Avg", isLike = true },
                new ProductReview() { ProductID = 11, UserID = 11, Rating = 4, Review = "Good", isLike = true },
                new ProductReview() { ProductID = 12, UserID = 12, Rating = 3, Review = "Avg", isLike = false },
                new ProductReview() { ProductID = 13, UserID = 13, Rating = 2, Review = "Good", isLike = true }

            };
            foreach (var list in ProductReviewlist)
            {
                Console.WriteLine("Product ID: " + list.ProductID + " " + "UserID: " + list.UserID + " " + "Rating: " + list.Rating + " " +
                    " Review: " + list.Review + " " + "islike: " + list.isLike);
            }

            //uc2//
            Console.WriteLine("\n Retrieve Top 3 Records from list \n");

            Management management = new Management();

            management.RetrieveTop3Records(ProductReviewlist);

            Console.WriteLine("\n");

        }
    }
}
