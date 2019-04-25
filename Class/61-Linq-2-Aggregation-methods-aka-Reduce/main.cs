using System;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    print(numbers.Sum() == 55);
    print(numbers.Average() == 5.5);
    print(numbers.Max() == 10);
    print(numbers.Min() == 1);
    print(numbers.Count() == 10);
    print(numbers.First() == 1);
    print(numbers.Last() == 10);

    print(numbers.Aggregate(0, (memo, n) => memo + n) == 55); // Sum
    print(numbers.Aggregate((memo, n) => memo + n) == 55); // Sum (0 생략 가능)
    print(numbers.Aggregate((memo, n) => memo + 1) == 10); // Count
    print(numbers.Aggregate((memo, n) => n > memo ? n : memo) == 10); // Max
    print(numbers.Aggregate(int.MaxValue, (memo, n) => n < memo ? n : memo) == 1); // Min

    var str = new[] {"a", "b", "c", "d"};
    print(str.GetType().ToString());
    print(str.Aggregate((memo, s) => memo + " " + s) == "a b c d"); // Stringify
  }
}
