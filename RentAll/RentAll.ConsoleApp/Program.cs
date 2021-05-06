
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Domain.Models;
using RentAll.Infrastructure.Data;
using RentAll.Infrastructure.Repositories;
using RentAll.Infrastructure.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Transactions;

namespace RentAll.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //CustomSeeding
            //using (var rentAllDbContext = new RentAllDbContext())
            //{


            //    rentAllDbContext.Categories.Add(new Category { CategoryName = "Food" });
            //    rentAllDbContext.SaveChanges();

            //    rentAllDbContext.Activities.AddRange(new Activity
            //    {
            //        ActivityName = "Fast-Food",
            //        Category = rentAllDbContext.Categories.FirstOrDefault(c=>c.CategoryName=="Food")
            //    },
            //    new Activity
            //    {
            //        ActivityName = "Restaurant",
            //        Category = rentAllDbContext.Categories.Find(4)
            //    }
            //    ) ;

            //    rentAllDbContext.SaveChanges();


            //}

            var connectionString = "Data Source=RALU\\SQLEXPRESS;Initial Catalog=RentAllDb;" +
            "Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



            //Share connection and transaction (multiple context instances that share the same connection
            // UseTransaction to enlist both contexts in the same transaction

            //var options = new DbContextOptionsBuilder<RentAllDbContext>()
            //    .UseSqlServer(new SqlConnection(connectionString)).Options;

            //using (var context1 = new RentAllDbContext(options))
            //{
            //    using (var transaction = context1.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            context1.Categories.Add(new Category { CategoryName = "Health" });
            //            context1.SaveChanges();

            //            using (var context2 = new RentAllDbContext(options))
            //            {
            //                context2.Database.UseTransaction(transaction.GetDbTransaction());
            //                var categories = context2.Categories.OrderBy(c => c.CategoryName).ToList();
            //                foreach (var item in categories)
            //                {
            //                    Console.WriteLine(item.CategoryName);
            //                }


            //            }
            //            transaction.Commit();
            //        }
            //        catch (Exception)
            //        {
            //            //transaction.Rollback();
            //        }




            //    }


            //using (var scope = new TransactionScope(TransactionScopeOption.Required,
            //        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            //{
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();

            //    using (var transaction = connection.BeginTransaction())
            //    {
            //    try
            //    {
            //        //Run Ado.Net command in the transaction
            //        var command = connection.CreateCommand();
            //            command.Transaction = transaction;
            //            command.CommandText = "INSERT INTO dbo.Categories VALUES('Park')";
            //            command.ExecuteNonQuery();

            //            //Run EF Core command in the transaction
            //            var options2 = new DbContextOptionsBuilder<RentAllDbContext>()
            //                .UseSqlServer(connection).Options;

            //            using (var context = new RentAllDbContext(options2))
            //            {
            //                context.Database.UseTransaction(transaction);
            //                context.Categories.Add(new Category { CategoryName = "Health" });
            //                context.SaveChanges();

            //            }
            //            transaction.Commit();
            //    }
            //    catch (System.Exception)
            //    {
            //        //transaction.Rollback();
            //    }
            //}

            //}
            //}


            //    create queries, use filters, projections and ordering.
            //    investigate what queries are generated in sql profile

            //var options = new DbContextOptionsBuilder<RentAllDbContext>()
            //.UseSqlServer(new SqlConnection(connectionString)).Options;

            //using (var context1 = new RentAllDbContext(options))
            //{
                //var funCategory = context1.Categories
                //                  .Single(c => c.CategoryName == "Entertainment");


                //var activitiesCount = context1.Entry(funCategory)
                //                  .Collection(c => c.Activities)
                //                  .Query().Count();

                //var activitiesCount1 = context1.Activities
                //    .Where(c => c.Category.CategoryName == "Entertainment")
                //    .Count();


                //Console.WriteLine(activitiesCount);              
                //Console.WriteLine(activitiesCount1);

                //var categoriesWithMoreThanOneActivity = context1.Categories
                //                        .Where(c => c.Activities.Count > 1)
                //                        .OrderBy(c => c.CategoryName)
                //                        .Select(c => new { Id = c.Id, Name = c.CategoryName });

                //foreach (var item in categoriesWithMoreThanOneActivity)
                //{
                //    Console.WriteLine(item);
                //}

            }


            //N+1 problem

            //using (var context1 = new RentAllDbContext(options))
            //{

            //    foreach (var category in context1.Categories)
            //    {
            //        foreach (var activity in category.Activities)
            //        {
            //            Console.WriteLine($"{category.CategoryName}, {activity.ActivityName}");
            //        }
            //    }

            //    foreach (var category in context1.Categories.Include("Activities"))
            //    {
            //        foreach (var activity in category.Activities)
            //        {
            //            Console.WriteLine($"{category.CategoryName}, {activity.ActivityName}");
            //        }
            //    }

            
            //}

            //  Create queries with all types of joins.
            //using (var context1 = new RentAllDbContext(options))
            //{
            //    //INNER JOIN
                //IQueryable<Center> outer = context1.Centers;
                //IQueryable<Lease> inner = context1.Leases;

                //var leasesInIuliusTimisoara = from center in outer
                //                              join lease in inner
                //                              on center.Id equals lease.CenterId
                //                              select new
                //                              {
                //                                  Center = center.CenterName,
                //                                  LeaseNumber = lease.LeaseNumber
                //                              };
                //foreach (var item in leasesInIuliusTimisoara)
                //{
                //    Console.WriteLine(item);
                //}


                //LEFT JOIN 
                //IQueryable<Category> outer = context1.Categories;
                //IQueryable<Activity> inner = context1.Activities;
                //var activitiesPerCategory = outer
                //.GroupJoin(
                //inner: inner,
                //outerKeySelector: category => category.Id,
                //innerKeySelector: activity => activity.Category.Id,
                //resultSelector: (category, activities) =>
                //new { Category = category, Activities = activities }) // Define query.
                //       .SelectMany(
                //collectionSelector: category => category.Activities
                //.DefaultIfEmpty(), // INNER JOIN if DefaultIfEmpty is missing.
                //           resultSelector: (category, activity) =>
                //new { Category = category.Category.CategoryName, Activity = activity.ActivityName });



                //var activitiesPerCategory1 = from category in outer
                //                join activity in inner
                //                on category.Id equals activity.Category.Id 
                //                into activities from activity in activities.DefaultIfEmpty()
                //                select new { Category = category.CategoryName, 
                //                Activity = activity.ActivityName };

                //foreach (var item in activitiesPerCategory.ToList())
                //{
                //    Console.WriteLine(item);
                //}

             

                //Console.ReadLine();
            }

        }
    }


}

