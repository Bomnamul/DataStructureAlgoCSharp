/**
* 삼각형과 다이아몬드 모양으로 출력하는 프로그램
* @date 2019/03/19
* @author 양덕진 <wdv1235@gmail.com>
*/

using System;

class MainClass {
  public static void Main (string[] args) {

    Console.WriteLine();
    Console.WriteLine("Triangle Shape");
    Console.WriteLine();

    for (int i = 0; i < 9; i++) {   // Triangle Shape
      for (int k = 9; k > i+1; k--)
        Console.Write(" ");
      for (int j = 0; j < i+1; j++)
        Console.Write("*");
      Console.WriteLine();
    }

    Console.WriteLine();
    Console.WriteLine("Diamond Shape");
    Console.WriteLine();

    for (int p = 0; p < 5; p++) {   // Diamond Shape
      for (int m = 5; m > p+1; m--)
        Console.Write(" ");
      for (int n = 0; n < 2*p+1; n++)
        Console.Write("*");
      for (int o = 5; o > p+1; o--)
        Console.Write(" ");
      Console.WriteLine();
    }
    for (int a = 4; a > 0; a--) {
      for (int b = 4; b > a-1; b--)
        Console.Write(" ");
      for (int c = 0; c < 2*a-1; c++)
        Console.Write("*");
      for (int d = 4; d > a-1; d--)
        Console.Write(" ");
      Console.WriteLine();
    }
  }
}