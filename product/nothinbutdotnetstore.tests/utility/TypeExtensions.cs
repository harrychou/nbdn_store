using System;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.tests.utility
{
    static public class TypeExtensions
    {
        static public ConstructorInfo greediest_contructor(this Type type)
        {
            return type.GetConstructors().OrderByDescending(
                info => info.GetParameters().Count()).First();
        }
    }
}