using System.Text;

namespace PPON.Generator
{
  class Program
  {
    private static readonly char[] CharPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

    private static readonly char[] EuansIdea = "ABCDEFGHIJKLMNPQRSTUVWXYZ".ToCharArray();
    private static readonly char[] EuansIdea2 = "123456789".ToCharArray();

    private static readonly HashSet<string> GeneratedCodes = new HashSet<string>();
    private static readonly Random RandomGenerator = new Random();

    static void Main(string[] args)
    {
      var EuanCount = CalculateTotalCombinationsEuan();
      var sammyCount = CalculateTotalCombinations();
      Console.WriteLine("Total combinations for Sammy's Idea: " + sammyCount.ToString("N0"));
      Console.WriteLine("Total combinations for Euan's Idea: " + EuanCount.ToString("N0"));

      while (Console.ReadKey().Key != ConsoleKey.Escape)
      {
        //Console.WriteLine("Generated Sammy's Idea: Your PPON is ");
        //string uniqueCode = GenerateSammysIdea();
        //Console.Write(uniqueCode);
        //Console.WriteLine("---------------------------------------------------------------");

        Console.WriteLine("Generated Euans's Idea: Your PPON is");
        string uniqueCodeEuan = GenerateEuanssIdea();
        Console.WriteLine(uniqueCodeEuan);

        Console.WriteLine("---------------------------------------------------------------");
      }


    }

    private static string GenerateSammysIdea()
    {
      string code;
      do
      {
        code = GenerateCodePattern() + "-" + GenerateMultiplier();
      } while (!GeneratedCodes.Add(code)); // Ensure the code is unique

      return code;
    }

    private static string GenerateEuanssIdea()
    {
      string code;
      do
      {
        code = GenerateCodePatternEuan() + "-" + GenerateMultiplierEuan();
      } while (!GeneratedCodes.Add(code)); // Ensure the code is unique

      return code;
    }

    private static string GenerateCodePattern()
    {
      var builder = new StringBuilder();
      for (int i = 0; i < 12; i++)
      {
        builder.Append(CharPool[RandomGenerator.Next(CharPool.Length)]);
        if ((i + 1) % 4 == 0 && i != 11) // Add hyphens after every 4 characters, except the last group
        {
          builder.Append("-");
        }
      }
      return builder.ToString();
    }

    private static string GenerateMultiplier()
    {
      var builder = new StringBuilder();
      for (int i = 0; i < 2; i++)
      {
        builder.Append(CharPool[RandomGenerator.Next(CharPool.Length)]);
      }
      return builder.ToString();
    }

    private static string GenerateCodePatternEuan()
    {
      var builder = new StringBuilder();
      for (int i = 0; i < 12; i++)
      {
        char nextChar = (i / 4) % 2 == 0
                    ? EuansIdea[RandomGenerator.Next(EuansIdea.Length)]
                    : EuansIdea2[RandomGenerator.Next(EuansIdea2.Length)];



        builder.Append(nextChar);

        if ((i + 1) % 4 == 0 && i != 11) // Add hyphens after every 4 characters, except the last group
        {
          builder.Append("-");
        }
      }
      return builder.ToString();
    }

    private static string GenerateMultiplierEuan()
    {
      var builder = new StringBuilder();
      for (int i = 0; i < 2; i++)
      {
        builder.Append(CharPool[RandomGenerator.Next(CharPool.Length)]);
      }
      return builder.ToString();
    }

    private static double CalculateTotalCombinations()
    {
      double totalCombinations = Math.Pow(CharPool.Length, 14); // 62^14 combinations
      return totalCombinations; // Format with commas for readability
    }

    private static double CalculateTotalCombinationsEuan()
    {
      double totalCombinations = Math.Pow(10, 4) * Math.Pow(52, 4) * Math.Pow(10, 4) * Math.Pow(62, 2);
      return totalCombinations;
    }
  }
}
