using System;
using System.Reflection;
using System.Linq;

namespace test
{
    /// <summary>
    /// Central menu-driven runner for all DSA problems.
    /// Uses reflection to discover all classes with a public static void Run() method.
    /// 
    /// Usage:
    ///   dotnet run                → Interactive menu (browse & select)
    ///   dotnet run -- ClassName   → Run a specific problem directly
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Discover all classes with a public static void Run() method
            var runnableTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetMethod("Run", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null) != null)
                .OrderBy(t => t.Namespace ?? "")
                .ThenBy(t => t.Name)
                .ToList();

            // If a class name was passed as argument, run it directly
            if (args.Length > 0)
            {
                string target = args[0];
                var match = runnableTypes.FirstOrDefault(t =>
                    t.Name.Equals(target, StringComparison.OrdinalIgnoreCase));

                if (match != null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n▶ Running: {match.Name}");
                    Console.WriteLine(new string('─', 50));
                    Console.ResetColor();
                    RunProblem(match);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"❌ No problem found matching '{target}'");
                    Console.ResetColor();
                    Console.WriteLine("\nAvailable problems:");
                    foreach (var t in runnableTypes)
                        Console.WriteLine($"  • {t.Name}");
                }
                return;
            }

            // Interactive menu
            ShowMenu(runnableTypes);
        }

        static void ShowMenu(List<Type> runnableTypes)
        {
            // Group by namespace/category
            var groups = runnableTypes
                .GroupBy(t => GetCategory(t.Namespace))
                .OrderBy(g => g.Key)
                .ToList();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔══════════════════════════════════════════════════╗");
                Console.WriteLine("║          📚 DSA Practice Problems Runner         ║");
                Console.WriteLine("╚══════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();

                int index = 1;
                var flatList = new List<Type>();

                foreach (var group in groups)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  ── {group.Key} ──");
                    Console.ResetColor();

                    foreach (var type in group)
                    {
                        Console.Write($"    ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"[{index,3}] ");
                        Console.ResetColor();
                        Console.WriteLine(type.Name);
                        flatList.Add(type);
                        index++;
                    }
                    Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"  Total: {runnableTypes.Count} problems");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("  Enter number (or 'q' to quit, or type a name to search): ");

                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input) || input.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n  Goodbye! 👋\n");
                    return;
                }

                // Try as number
                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= flatList.Count)
                {
                    var selected = flatList[choice - 1];
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"\n▶ Running: {selected.Name} ({GetCategory(selected.Namespace)})");
                    Console.WriteLine(new string('─', 50));
                    Console.ResetColor();

                    RunProblem(selected);

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(new string('─', 50));
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else
                {
                    // Search by name
                    var matches = runnableTypes
                        .Where(t => t.Name.Contains(input, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (matches.Count == 1)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\n▶ Running: {matches[0].Name}");
                        Console.WriteLine(new string('─', 50));
                        Console.ResetColor();

                        RunProblem(matches[0]);

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(new string('─', 50));
                        Console.WriteLine("\nPress Enter to return to menu...");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else if (matches.Count > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n  Found {matches.Count} matches:");
                        Console.ResetColor();
                        foreach (var m in matches)
                            Console.WriteLine($"    • {m.Name}");
                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n  ❌ No match for '{input}'");
                        Console.ResetColor();
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                }
            }
        }

        static void RunProblem(Type type)
        {
            try
            {
                var method = type.GetMethod("Run", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);
                method?.Invoke(null, null);
            }
            catch (TargetInvocationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n⚠ Error: {ex.InnerException?.Message ?? ex.Message}");
                Console.ResetColor();
            }
        }

        static string GetCategory(string? ns)
        {
            if (string.IsNullOrEmpty(ns)) return "General";
            // e.g. "test.BinaryTrees" -> "Binary Trees"
            string category = ns.Replace("test.", "").Replace("test", "");
            if (string.IsNullOrEmpty(category)) return "General";

            return category switch
            {
                "BinaryTrees" => "Binary Trees",
                "DynamicProgramming" => "Dynamic Programming",
                "TGPC3" => "TGP-C3",
                "TGPC4" => "TGP-C4",
                "TGPC5" => "TGP-C5",
                _ => category
            };
        }
    }
}
