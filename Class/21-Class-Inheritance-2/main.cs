using System;

class MainClass {
  class Book {
    public string title;
    public string genre;

    public virtual void Print() {
      Console.WriteLine($"{title}, {genre}");
    }
  }

  class Novel : Book {
    public string writer;
    public override void Print() {
      base.Print();
      Console.WriteLine($"{writer}");
    }
  }

  class Magazine : Book {
    public int releaseDay;
    public override void Print() {
      base.Print();
      Console.WriteLine($"{releaseDay}");
    } 
  }

  /*
  virtual, override 없으면 44 line의 Book타입의 Print가 출력 (static binding)
                    있으면 실행시점에 type을 변경 (dynamic binding)
                    (최상위에는 virtual 하위엔 override 있어야 함)

  base: 부모의 기능을 사용 ( + 원하는 기능 추가 ok)
  */

  public static void Main (string[] args) {
    Novel nov = new Novel();
    nov.title = "The Hobbit"; nov.genre = "Fantasy";
    nov.writer = "J.R.R Tolkien";
    nov.Print();
    Console.WriteLine();

    Magazine mag = new Magazine();
    mag.title = "Hello Computer Magazine";
    mag.genre = "Computer";
    mag.releaseDay = 1;
    mag.Print();

    Book[] books = {nov, mag}; // polymorphism: subtyping (하위 타입을 상위 타입으로 포함할 수 있음, 상위쪽으로 자동 캐스팅)
    foreach (var b in books){  // 실제 호출되는 것은 b에 담은 하위 타입의 Print가 Call됨
      b.Print();
      Console.WriteLine();
    }
  }
}

// shape다각형(사각형, 정사각형, 원(파이r제곱), 이등변삼각형) 넓이구하기 상속개념
// 어레이에 넓이 각각 담아서 Stringify로 확인 testcase
