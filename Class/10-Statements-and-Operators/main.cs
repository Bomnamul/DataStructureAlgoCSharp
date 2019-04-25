using System;

class MainClass {
  public enum Color { Red, Green, Blue };

  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Random rnd = new Random();
    Color c = (Color) rnd.Next(0, 4); // 0 ~ 3 random value
    if (c == Color.Red)
      print(c == Color.Red);
    else if (c == Color.Green)
      print(c == Color.Green);
    else if (c == Color.Blue)
      print(c == Color.Blue);
    else
      print("Unknown Color !");
    
    switch(c) { // object 타입이 올 수 있다 단, Equals가 정의되어야함
      case Color.Red:
        print(c == Color.Red);
        break;
      case Color.Green:
        print(c == Color.Green);
        break;
      case Color.Blue:
        print(c == Color.Blue);
        break;
      default:
        print("Unknown Color !");
        break;
    }

    switch(c) {
      case Color.Red:
      case Color.Green:
      case Color.Blue:
        print(c);
        break;
      default:
        print("Unknown Color !");
        break;
    }

    int[] scores = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    print(SumIf(scores, v => v%2==0) == 30);
    print(SumIf(scores, v => v%2!=0) == 25);
    print(SumIf(scores, v => v > 6) == 34);
    print(SumIf(scores, v => true ) == 55);

    print(SumIf2(scores, v => v%2==0) == 30);

    int count = 1;
    print(++count == 2);
    count = 1;
    print(count++ == 1);

    int a = 9, b = 8;
    int carry = a+b > 10 ? 1 : 0;
    int remainder = a+b > 10 ? a+b-10 : a+b;
    print(carry == 1 && remainder == 7); // short-circuit evaluation
  }

   // Func<param, return>
   // bool fuction(int v); same
   // condition : 함수를 가지는 변수
  public static int SumIf(int[] list, Func<int, bool> condition) {
    int i = 0;
    int sum = 0;
    while (i < list.Length) {
      if (!condition(list[i])) {
        i++;
        continue;
        // break; 하면 while 루프 종료
      } else {
        sum += list[i++];
      }
    }
    return sum;
  }

  public static int SumIf2(int[] list, Func<int, bool> condition) {
    int i = 0;
    int sum = 0;
    do {
      if (condition(list[i]))
        sum += list[i];
    } while(++i < list.Length); //한번은 실행된다는 보장이 있음
    return sum;
  }
}
