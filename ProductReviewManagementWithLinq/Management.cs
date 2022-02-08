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
        public static void CreateDataTable() //create method
        {
            try
            {
                DataTable table = new DataTable(); 
                table.Columns.Add("ProductId", typeof(Int32)); 
                table.Columns.Add("UserId", typeof(Int32)); 
                table.Columns.Add("Rating", typeof(double)); 
                table.Columns.Add("Review", typeof(string)); 
                table.Columns.Add("isLike", typeof(bool)); 
                table.Rows.Add(1, 1, 4, "Average", true); 
                table.Rows.Add(1, 2, 2, "Bad", false); 
                table.Rows.Add(3, 3, 4, "Nice", true); 
                table.Rows.Add(4, 4, 5, "Good", false); 
                table.Rows.Add(5, 5, 6, "Excelent", false); 
                table.Rows.Add(6, 10, 4, "Nice", true); 
                table.Rows.Add(7, 6, 3, "Average", true); 
                table.Rows.Add(8, 5, 2, "Bad", true); 
                table.Rows.Add(9, 10, 5, "Good", true);
                table.Rows.Add(10, 41, 6, "Excelent", false); 
                table.Rows.Add(11, 5, 4, "Nice", false); 
                table.Rows.Add(12, 4, 1, "Very Bad", true); 
                table.Rows.Add(13, 48, 0, "Excelent", false); 
                table.Rows.Add(14, 41, 3, "Average", true); 
                table.Rows.Add(15, 51, 4, "Nice", true); 
                table.Rows.Add(16, 8, 1, "Very Bad", false); 
                table.Rows.Add(17, 18, 6, "Excelent", true); 
                table.Rows.Add(18, 9, 5, "Good", true); 
                table.Rows.Add(19, 10, 4, "Nice", false); 
                table.Rows.Add(20, 7, 3, "Average", true); 
                table.Rows.Add(21, 6, 2, "Bad", true); 
                table.Rows.Add(22, 5, 1, "Very Bad", false); 
                table.Rows.Add(23, 10, 5, "Good", false);
                table.Rows.Add(24, 8, 2, "Bad", true); 
                table.Rows.Add(22, 12, 3, "Average", false); 

                Console.WriteLine("DataTable Records");
                foreach (var list in table.AsEnumerable())
                {
                    Console.WriteLine($"ProductId:- { list.Field<int>("ProductId")}    UserId:- {list.Field<int>("UserId")}\tRating:- {list.Field<double>("Rating")}\tReview:- { list.Field<string>("Review")} \tisLike:- {list.Field<bool>("isLike")}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

