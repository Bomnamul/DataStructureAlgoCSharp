/**
* 근의 공식을 이용해 이차방정식의 해 구하는 프로그램
* @date 2019/03/19
* @author 양덕진 <wdv1235@gmail.com>
*/

using System;

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine();
    Console.WriteLine("Quadratic Equation");
    Console.WriteLine();
    
    double x1;
    double x2;
    double a = 0;
    double b = 0;
    double c = 0;
    string sinput;

    Console.WriteLine("===================================================");
    Console.WriteLine("             Quadratic Equation Solver");
    Console.WriteLine("===================================================");
    Console.WriteLine();
    Console.WriteLine("ax^2 + bx + c = 0");
    Console.WriteLine();

    for (int i = 0; i < 3; i++) {                   //숫자 3번 입력받아 a, b, c에 저장
      Console.WriteLine("Please input number...");
      sinput = Console.ReadLine();
      if (i == 0) {
        a = Convert.ToDouble(sinput);
      } else if (i == 1) {
        b = Convert.ToDouble(sinput);
      } else {
        c = Convert.ToDouble(sinput);
      }
    }
    
    Console.WriteLine("({0}x^2) + ({1}x) + ({2})", a, b, c);
    
    if (a == 0) {                                    // a가 0일 경우 예외처리
    Console.WriteLine("Exception Error! : 'a' must be more then 0.");
    }

    double disc = Math.Pow(b, 2) - (4*a*c);

    if(disc > 0) {                                   // 판별식 값이 0보다 클 경우 해가 2개인 경우로 x1, x2 출력
      x1 = (-b + Math.Sqrt(disc)) / (2*a);
      x2 = (-b - Math.Sqrt(disc)) / (2*a);
      Console.WriteLine("===================================================");
      Console.WriteLine("Discriminant is positive : Two distinct real zeros.");
      Console.WriteLine("x1 = " + x1);
      Console.WriteLine("x2 = " + x2);
      Console.WriteLine((x1 == (-b + Math.Sqrt(disc)) / (2*a)) && (x2 == (-b - Math.Sqrt(disc)) / (2*a)));
    } else {
      if (disc == 0) {                               // 판별식 값이 0이면 중근을 가지므로 x1만 출력
        x1 = -b / (2*a);
        Console.WriteLine("===================================================");
        Console.WriteLine("Discriminant is zero : One real zero.");
        Console.WriteLine(x1);
        Console.WriteLine(x1 == (-b / (2*a)));
      } else {                                       // 판별식 값이 0보다 작을 경우 허수를 가지므로 아래 문자열 출력
        Console.WriteLine("===================================================");
        Console.WriteLine("Imaginary Number Found");
        Console.WriteLine((disc < 0 ) == true);
      }
    }
  }
}
