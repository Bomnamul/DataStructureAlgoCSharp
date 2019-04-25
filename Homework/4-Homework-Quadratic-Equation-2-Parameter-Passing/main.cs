using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;
    
    double root0;
    double root1;
    double disc;

    Solver(1, 4, -21, out disc, out root0, out root1);
    print(disc > 0);                                    // d > 0 Test Code
    print((1 * (root0 * root0) + 4 * root0 -21) == 0);
    print((1 * (root1 * root1) + 4 * root1 -21) == 0);

    Solver(1, 2, 1, out disc, out root0, out root1);
    print(disc == 0);                                   // d == 0 Test Code
    print((1 * (root0 * root0) + 2 * root0 + 1) == 0);

    Solver(3, 6, 10, out disc, out root0, out root1);
    print(disc < 0);                                    // D < 0 Test Code
  }

  public static void Solver(double a, double b, double c, out double disc, out double root0, out double root1) {
    double d = (b * b) - (4 * a * c);
    if (d > 0) {
      root0 = (-b + Math.Sqrt(d)) / (2*a);
      root1 = (-b - Math.Sqrt(d)) / (2*a);
      disc = d;
      Console.WriteLine("root0 = " + root0);
      Console.WriteLine("root1 = " + root1);
    } else if (d == 0) {
      root0 = -b / (2*a);
      root1 = -b / (2*a);
      disc = d;
      Console.WriteLine("root = " + root0);
    } else {
      root0 = 0;
      root1 = 0;
      disc = d;
      Console.WriteLine("Imaginary number found");
    }
  }
}
