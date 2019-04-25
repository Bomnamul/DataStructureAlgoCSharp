using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Shape[] shapes = {
      new Square(5, "Square #1"),
      new Circle(3, "Circle #1")
    };
    double[] areas = new double[shapes.Length];
    for (int i = 0; i < shapes.Length; i ++) {
      areas[i] = shapes[i].Area;
    }
    Console.WriteLine(areas.Stringify() == "25 28.2743338823081");
  }

  // Shape s = new Shape("tri"); // error !
}

public abstract class Shape { // abstract를 하나라도 가지면 그 클래스는 abstract class
  string name;
  public Shape(string s) {
    Id = s;

  }
  public string Id {
    get {
      return name;
    }
    set {
      name = value;
    }
  }
  public abstract double Area {get;} // 추상적이라 property를 구체적으로 정의 못하겠다...
  public override string ToString() {
    return $"{Id} Area = {Area}";
  }
}

public class Square : Shape {
  int side;
  public Square(int side, string id) : base(id) {
    this.side = side;
  }
  public override double Area {
    get {
      return side * side;
    }
  }
}

public class Circle : Shape {
  int radius;
  public Circle(int radius, string id) : base(id) {
    this.radius = radius;
  }
  public override double Area {
    get {
      return Math.PI * radius * radius;
    }
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) { // 지금은 외워쓰자
    return String.Join(" ", list);
  }
}
