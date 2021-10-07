using System;
using System.Diagnostics;
using System.Linq;
using SDM.Compulsory1.Core.IServices;
using SDM.Compulsory1.Domain.IRepositories;
using SDM.Compulsory1.Domain.Services;
using SDM.Compulsory1.Infrastructure.Repositories;

namespace DalPerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IReviewRepository _repo = new ReviewRepository();
            IReviewService _service = new ReviewService(_repo);

            var reviews = _repo.GetAll().ToList();

            
            /*
            int c = 0;

            foreach (var r in reviews)
            {
                if (c == 5)
                {
                    break;
                }
                Console.WriteLine("----------------");
                Console.WriteLine("MovieId: " + r.Movie);
                Console.WriteLine("Grade: " + r.Grade);
                Console.WriteLine("Reviewer: " + r.Reviewer);
                Console.WriteLine("Review date: " + r.ReviewDate);
                Console.WriteLine("----------------");
                Console.WriteLine();
                c++;
            }
            */

            var before = DateTime.Now.Millisecond;
            var num = _service.GetTopRatedMovies(5);
            var now = DateTime.Now.Millisecond;
            
            Console.WriteLine("Time passed" + (now - before));

        }
    }
}