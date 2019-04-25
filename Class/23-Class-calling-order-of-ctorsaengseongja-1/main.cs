using System;

class MainClass {
  class Book {
    public string title;
    public Book() {
      Console.WriteLine("Book ctor");
    }
  }

  class Novel : Book {
    public Novel() : base() {
      Console.WriteLine("Novel ctor");
    }
  }

  class SFNovel : Novel {
    public SFNovel() : base() {
      Console.WriteLine("SFNovel ctor");
    }
  }

  public static void Main (string[] args) {
    SFNovel nov = new SFNovel();
    nov.title = "The Hobbit";
  }
}

// ctor 생성자 호출 순서 (부모부터)
// 쓸일은 없지만 파괴자는 (자식부터)