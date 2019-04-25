using System;
using System.Collections.Generic;

// interface: 규약
interface IEquatable { // 관례상 I로 시작함 + able
  bool Equals(Car obj); // public + abstract (class와 비슷하나 내부는 전부 abstract(public member))
}

interface ICloneable {
  Car Clone();
}

class Car : IEquatable, ICloneable, IComparable { // IComparable.CompareTo (순서를 비교, 정렬규칙을 지정할 수 있음)
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

  public int CompareTo(object obj) {
    return this.Year.CompareTo((obj as Car).Year); // 오름차순
    // return (obj as car).Year.CompareTo(this.Year); // 내림차순
  }

  public override string ToString() {
    return Make + Year;
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
    car2.Year = "2017";
    
    Car car3 = new Car();
    car3.Make = "Volvo";
    car3.Model = "X";
    car3.Year = "2012";
    
    print(car.Equals(car2) == false);

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

    IComparable[] cars = {car, car2, car3};
    Array.Sort(cars);
    print(cars.Stringify() == "Volvo2012 BMW2017 BMW2018");
  }
}

class Cake {

}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}