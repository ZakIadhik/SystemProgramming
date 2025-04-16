using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EfThreadingDemo
{
    public class ManualStudentService
    {
        public void AddStudentManually(string name)
        {
            Console.WriteLine($"[Manual Add] Thread: {Thread.CurrentThread.ManagedThreadId}");

            Task.Run(() =>
            {
                using var context = new AppDbContext();
                context.Students.Add(new Student { Name = name });
                context.SaveChanges();

                Console.WriteLine($"[Manual Add -> Task] Thread: {Thread.CurrentThread.ManagedThreadId}");
            }).GetAwaiter().GetResult();
        }

        public void ShowAllStudentsManually()
        {
            Console.WriteLine($"[Manual Show] Thread: {Thread.CurrentThread.ManagedThreadId}");

            var students = Task.Run(() =>
            {
                using var context = new AppDbContext();
                var result = context.Students.ToList();

                Console.WriteLine($"[Manual Show -> Task] Thread: {Thread.CurrentThread.ManagedThreadId}");
                return result;
            }).GetAwaiter().GetResult();

            foreach (var student in students)
                Console.WriteLine($"[Manual] {student.Id}: {student.Name}");
        }
    }
}