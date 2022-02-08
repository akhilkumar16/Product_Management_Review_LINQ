using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;

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
        public static void RetrieveCountOfReviewForEachProductId(List<ProductReview> productReviewlist)
        {
            var RecordedData = (productReviewlist.GroupBy(p => p.ProductID).Select(x => new { ProductId = x.Key, Count = x.Count() }));
            Console.WriteLine("\n Count group by ProductId");
            foreach (var List in RecordedData)
            {
                Console.WriteLine($"ProductId:- {List.ProductId}   || Count :- {List.Count}");
            }
        }

        internal static void RetrieveProductIDAndReviewOfAllRecords(List<ProductReview> productReviewlist)
        {
            throw new NotImplementedException();
        }
        public static void RetrieveProductIDReviewOfAllRecords(List<ProductReview> productReviewlist)
        {
            try
            {
                var RecordedData = (from products in productReviewlist
                                    select new { ProductId = products.ProductID, Review = products.Review });
                Console.WriteLine("Retrieving Product and Review from list:-");
                foreach (var productReview in RecordedData)
                {
                    Console.WriteLine($"ProductID:-  {productReview.ProductId}  \t Review:-  { productReview.Review}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void SkipTopFiveRecords(List<ProductReview> productReviewlist)
        {
            try
            {
                var RecordedData = (from products in productReviewlist
                                    select products).Skip(5);
                Console.WriteLine("\n Skiping the Top five records and Display others ");
                foreach (var productReview in RecordedData) 
                {
                    Console.WriteLine($"ProductId:- {productReview.ProductID}\tUserId:- {productReview.UserID}\tRating:- {productReview.Rating}\t  Review:- {productReview.Review}  \t    isLike:- {productReview.isLike}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void RetrieveProductIDAndReviewUsingLambdaSyntax(List<ProductReview> productReviewlist)
        {
            try
            {                 
                var RecordedData = productReviewlist.Select(reviews => new { ProductId = reviews.ProductID, Review = reviews.Review });
                Console.WriteLine("\nRetrieving Product and Review from list");
                foreach (var productReview in RecordedData) 
                {
                    Console.WriteLine($"ProductId:- {productReview.ProductId}\tReview:- {productReview.Review}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

