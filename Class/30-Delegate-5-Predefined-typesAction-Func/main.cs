// https://docs.microsoft.com/ko-kr/dotnet/api/system.action?view=netframework-4.7.2
// https://docs.microsoft.com/ko-kr/dotnet/api/system.func-2?view=netframework-4.7.2

using System;

class MainClass {
  static double divide(int x, int y) {
    return (int)(x / y);
  }
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Action act1 = () => print("Action"); // lambda
    act1();
    Action<int> act2 = x => print(2 * x);
    act2(2);
    Action<double, double> act3 = (x, y) => print(x / y);
    act3(10, 20);

    Func<int> fn1 = () => 10; // param 1개면 Treturn만 있음
    print(fn1() == 10);
    Func<int, int, double> fn3 = divide;
    print(fn3(40, 20) == 2);
    Func<int, int, int, int, int, int, int, int, int, int, int, int, int> fn13;
    fn13 = (a, b, c, d, e, f, g, h,  i, j, k, l) => a+b+c+d+e+f+g+h+i+j+k+l;
    print(fn13(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1) == 12);
  }
}
