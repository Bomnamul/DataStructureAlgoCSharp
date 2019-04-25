using System;

class MainClass {
  public static int Comp(int x, int y) { return x.CompareTo(y); }

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    int[] scores = {2, 4, 5, 3, 6, 8, 1, 7};
    print(scores.GetType().ToString() == "System.Int32[]");
    print(scores.GetType().BaseType.ToString() == "System.Array");
    
    print(Stringify(new int[] {2}) == "2");
    print(Stringify(new int[] {}) == String.Empty);
    print(Stringify(scores) == "2 4 5 3 6 8 1 7");

    Array.ForEach(scores, v => Console.Write(v*2 + " ")); // => : Lambda Expression 익명함수 표현법 (용도 : callback)
    print("\n");
    
    // Sorting: 오름차순(Ascending order)
    print("\t\tSorting");
    Array.Sort( scores ); // in-place algorithm
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");
    // public static int Comp(int x, int y) { return x.CompareTo(y); } // sorting하는 순서
    Array.Sort( scores, Comp );
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");
    Array.Sort( scores, delegate (int x, int y) { return x.CompareTo(y); }); // 바로 콜백으로 만들어 씀
    Array.Sort( scores, (x, y) => x.CompareTo(y));                           // 더 간단히
    print(Stringify(scores) == "1 2 3 4 5 6 7 8");
    Array.Sort( scores, (x, y) => x-y );                                     // 더더 간단히

    // Sorting: 내림차순(Descending order)
    Array.Sort( scores, (x, y) => y.CompareTo(x));
    print(Stringify(scores) == "8 7 6 5 4 3 2 1");
    Array.Sort( scores, (x, y) => x-y );
    print(Stringify(scores) == "8 7 6 5 4 3 2 1");

    print(1.CompareTo(2) < 0);
    print(2.CompareTo(1) > 0);
    print(1.CompareTo(1) == 0);
    print(2.CompareTo(2) == 0);
  }

  public static string Stringify(int[] list) {
    return String.Join(" ", list);
  }
}