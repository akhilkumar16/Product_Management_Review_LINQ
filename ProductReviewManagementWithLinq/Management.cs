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
    }
}
