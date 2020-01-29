using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSEntityFramework
{
    public static class StudentDb
    {
        /// <summary>
        /// Returns a list of all the students
        /// sorted by StudendId in ascending order
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetAllStudents()
        {
            //var context = new StudentContext(); //optional when type is explicit
            StudentContext context = new StudentContext();

            // LINQ - Language INtegrated Query
            // LINQ Query Syntax
            List<Student> students =
                (from s in context.Students
                 orderby s.StudentId ascending
                 select s).ToList();

            // LINQ Method Syntax
            List<Student> students2 = context.Students
                .OrderBy(stu => stu.StudentId)
                .ToList();

            return students;
        }

        public static Student Add(Student stu)
        {
            // Check Panopto video 1/27 to see how to wrap using around this.
            StudentContext context = new StudentContext();
            context.Students.Add(stu);// Preparing insert query
            context.SaveChanges();    // Execute insert query against DB

            return stu;               // Return student with StudentId set
        }


        /// <summary>
        /// Deletes student from database, by their studentID
        /// Disconnected Scenario, save trip to DB
        /// See Also: https://www.tektutorialshub.com/entity-framework/ef-deleting-records/
        /// </summary>
        /// <param name="s"></param>
        public static void Delete(Student s)
        {
            using (StudentContext context = new StudentContext()) //using statement vs using directive at the top of the page
            {
#if DEBUG                
                context.Database.Log = Console.WriteLine; // Log query generated to output window
#endif
                //context.Students.Add(s); // This looks odd, as we are not trying to reinsert s into the database
                context.Students.Attach(s);
                context.Entry(s).State = EntityState.Deleted; // removed System.Data.Entity & added using
                context.SaveChanges();
            }

            //// This is what a using statment generates:
            //// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement
            //// manual dispose, the using statement above does this for us
            //var context2 = new StudentContext();
            //try
            //{
            //    //DB Code goes here
            //}
            //finally
            //{
            //    context2.Dispose();
            //}
        }

        /// <summary>
        /// Updates all student data except for PrimaryKey
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Student Update(Student s)
        {
            using (StudentContext context = new StudentContext()) //using statement vs using directive at the top of the page
            {
#if DEBUG                
                context.Database.Log = Console.WriteLine; // Log query generated to output window
#endif
                context.Students.Attach(s);
                context.Entry(s).State = EntityState.Modified;
                context.SaveChanges();
                return s;
            }
        }

        /// <summary>
        /// If StudentId = 0 they will be added
        /// else, it will update based upon StudentId
        /// </summary>
        /// <exception cref="System.Data.Entity.Infrastructure.DbUpdateConcurrencyException"
        /// <param name="s"></param>
        /// <returns></returns>
        public static Student AddOrUpdate(Student s)
        {
            using (StudentContext context = new StudentContext())
            {
                //ternary operator, https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/conditional-operator
                context.Entry(s).State = (s.StudentId == 0) ? EntityState.Added : EntityState.Modified;
                context.SaveChanges();
                return s;
            }
        }
    }
}
