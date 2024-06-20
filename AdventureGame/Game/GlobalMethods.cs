using System.Reflection;

namespace AdventureGame.Game
{
    public class GlobalMethods
    {
        public static object? CallByName<T>(T a, string name, object[] paramsToPass)
        {
            //Search public methods
            MethodInfo? method = a.GetType().GetMethod(name);
            if (method == null)
            {
                Console.WriteLine($"Method {name} not found on type {a.GetType()}.");
                return null;
            }
            else
            {
                object? result = method.Invoke(a, paramsToPass);
                return result;
            }
        }
    }
}
