using System;
using System.Collections.Generic;

// interface: 규약
interface IEquatable { // 관례상 I로 시작함 + able
  bool Equals(Car obj); // public + abstract (class와 비슷하나 내부는 전부 abstract(public member))
}

interface ICloneable {
  Car Clone();
}

interface IStringifiable{ // IStringifiable interface
  string Stringify();
}

class Car : IEquatable, ICloneable, IStringifiable {
  public string Make {get; set;}
  public string Model {get; set;}
  public string Year {get; set;}

  public bool Equals(Car car) {
    if (Make == car.Make && Model == car.Model && Year == car.Year)
      return true;
    else
      return false;
  }

  public Car Clone() {
    Car car = new Car();
    car.Make = Make;
    car.Model = Model;
    car.Year = Year;
    return car;
  }

  public string Stringify() {
    return $"Make: {this.Make}, Model: {this.Model}, Year: {this.Year}";
  }
}

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Car car = new Car();
    car.Make = "BMW";
    car.Model = "Mini";
    car.Year = "2018";

    Car car2 = new Car();
    car2.Make = "BMW";
    car2.Model = "Mini";
    car2.Year = "2018";
    
    print(car.Equals(car2) == true);

    Car clone = car.Clone();
    print(clone.Equals(car) == true);
    clone.Make = "Tesla";
    print(car.Make == "BMW");
    print(clone.Make == "Tesla");

    // print(car is int == false);
    // print(car is Cake == false);
    print(car is Car == true); // is: 상속관계 or 규약을 따르고 있는가
    print(car is IEquatable == true);
    print(car is ICloneable == true);
    print(car is object);

    ICloneable ic = car as ICloneable; // as: type casting
    print(ic != null);
    print(ic.GetType().Name == "Car");

    print(car.Stringify() == "Make: BMW, Model: Mini, Year: 2018"); // IStringifiable testcode

  }
}

class Cake {

}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

// 숙제 : interface IStringifiable 만들어 보기