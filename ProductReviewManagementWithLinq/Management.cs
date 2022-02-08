using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProductReviewManagementWithLinq
{
    class Management
    {
        public void RetrieveTop3Records(List<ProductReview> review)
        {
            var recordData = (from products in review
                              orderby products.Rating descending
                              select products).Take(3);

            foreach (var list in recordData)
            {
                Console.WriteLine("Product ID: " + list.ProductID + " " + "UserID: " + list.UserID + " " + "Rating: " + list.Rating + " " +
                   " Review: " + list.Review + " " + "islike: " + list.isLike);
            }
        }
        public void RetrieveRecordsWithGreaterThanThreeRating(List<ProductReview> review)
        {
            var recordData = (from products in review
                              where (products.ProductID == 1 ||
                              products.ProductID == 4 ||
                              products.ProductID == 9)
                              && products.Rating > 3
                              select products);

            foreach (var list in recordData)
            {
                Console.WriteLine("Product Id : " + list.ProductID + " || User Id : " + list.UserID + " || Rating : " + list.Rating 
                    + " || Review : " + list.Review + " || Is Like : " + list.isLike);
            }
        }
    }
}
