using System;

class MainClass {
  public static void Main (string[] args) {
    for (int i = 0; i < 9; i++) {
      for (int j = 0; j < i+1; j++)
        Console.Write("*");
      Console.WriteLine();
    }

    int num = 10;
    if(num > 0) {
      Console.WriteLine(true);
    } else {
      if (true) {

      } else {

      }
      Console.WriteLine(false);
    }
  }
}

// 절댓값 표현은 Math.~~
// 
// 근의 공식 짜오기 Math.sqrt
// testcase 만들고 검증
// 