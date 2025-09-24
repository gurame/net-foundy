using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace NetFoundy.Concepts;

public class Lists
{
    public static void Run()
    {
        var list = new List<Course>
        {
            new Course { Name = "C# Basics" },
            new Course { Name = "Advanced C#" },
            new Course { Name = "ASP.NET Core" }
        };
        
        // keep a reference to the input list
        // So changes to the input list will be reflected in the ReadOnlyCollection
        // However, the ReadOnlyCollection itself does not allow modification of its elements
        // e.g., you cannot add or remove items from ro_courses
        var ro_courses = new ReadOnlyCollection<Course>(list);
        
        list[0].Name = "C# Fundamentals"; 

        foreach (var course in ro_courses)
        {
            Console.WriteLine(course.Name);
        }

        var fs_courses = ro_courses.ToFrozenSet();
        
        var im_list = ImmutableList.Create(1, 2, 3);
        var im_list_new = im_list.Add(4); // creates a new ImmutableList with the added element
        foreach (var number in im_list_new)
        {
            Console.WriteLine(number);
        }
    }
}

class Course
{
    public string Name { get; set; }
}