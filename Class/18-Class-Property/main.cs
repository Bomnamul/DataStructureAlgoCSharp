using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Book b = new Book();
    // b.title = "Maus"; // error !
    b.SetTitle("Maus");
    print(b.GetTitle() == "Maus");

    Book2 b2 = new Book2();
    b2.Title = "Tree";
    print(b2.Title == "Tree");
    b2.Title = "";
    print(b2.Title == "None");

    Book3 b3 = new Book3();
    b3.Title = "Bible";
    print(b3.Title == "Bible");

    Book4 b4 = new Book4 { // array 초기화와 비슷, Object Initializer
      Title = "TLOR",
      Price = 30000
    };
    print(b4.Price == 30000);
  }

  class Book4 {
    public string Title {get; set;}
    public int Price {get; set;}
  }

  class Book3 {
    public string Title {get; set;} // set없으면 Read-Only , private set: 다른 클래스에선 못쓰게...
  }

  class Book2 {
    string title;
    public string Title { // Property는 관례상 Uppercase로 시작
      get {
        return title;
      }
      set {
        Console.WriteLine("setter");
        if (value == "")
          title = "None";
        else
          title = value;
      }
    }
  } // private은 가능하면 건드리지 말라 but 건드리겠다면 Property를 사용...

  class Book {
    string title; // encapsulation이 기본이라 public 없으면 접근 못하게 함
    public string GetTitle() {return title;} // Getter
    public void SetTitle(string title) {     // Setter
      this.title = title;
    } // 변수마다 만들어주기 불편함...: C#에선 Property
  }
}