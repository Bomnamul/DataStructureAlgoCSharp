using System;
using System.Collections.Generic;

class Shape {
  public int edge;
  public int line;
  public double lineLength;

  public virtual double Area() {
    Console.WriteLine("Need more information...");
    return 0;
  }
}

class Triangle : Shape {
  public double height;

  public override double Area() {
    return lineLength * height / 2;
  }
}

class Square : Shape {
  public override double Area() {
    return lineLength * lineLength;
  }
}

class Rectangle : Shape {
  public double height;

  public override double Area() {
    return lineLength * height;
  }
}

class Circle : Shape {
  public double radius;

  public override double Area() {
    return Math.PI * radius * radius;
  }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Triangle tri = new Triangle();
    tri.edge = 3;
    tri.line = 3;
    tri.lineLength = 10;
    tri.height = 4;

    Square sqr = new Square();
    sqr.edge = 4;
    sqr.line = 4;
    sqr.lineLength = 2;

    Rectangle rec = new Rectangle();
    rec.edge = 4;
    rec.line = 4;
    rec.lineLength = 3;
    rec.height = 5;

    Circle cir = new Circle();
    cir.edge = 0;
    cir.line = 1;
    cir.lineLength = 0;
    cir.radius = 5;

    Shape[] shapes = {tri, sqr, rec, cir};
    double[] array = new double[shapes.Length];
    
    for (int i = 0; i < shapes.Length; i ++) {
      array[i] = shapes[i].Area();
    }
    print(array.Stringify() == "20 4 15 78.5398163397448");
  }  
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) { // 지금은 외워쓰자
    return String.Join(" ", list);
  }
}

// shape다각형(사각형, 정사각형, 원(파이r제곱), 이등변삼각형) 넓이구하기 상속개념
// 어레이에 넓이 각각 담아서 Stringify로 확인 testcase