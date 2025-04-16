using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfThreadingDemo
{
    public class AsyncStudentService
    {
        public async Task AddStudentAsync(string name)
        {
            Console.WriteLine($"[Async Add] Thread: {Thread.CurrentThread.ManagedThreadId}");

            using var context = new AppDbContext();
            await context.Students.AddAsync(new Student { Name = name });
            await context.SaveChangesAsync();

            Console.WriteLine($"[Async Add -> DB] Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task ShowAllStudentsAsync()
        {
            Console.WriteLine($"[Async Show] Thread: {Thread.CurrentThread.ManagedThreadId}");

            using var context = new AppDbContext();
            var students = await context.Students.ToListAsync();

            Console.WriteLine($"[Async Show -> DB] Thread: {Thread.CurrentThread.ManagedThreadId}");
            foreach (var student in students)
                Console.WriteLine($"[Async] {student.Id}: {student.Name}");
        }
    }
}