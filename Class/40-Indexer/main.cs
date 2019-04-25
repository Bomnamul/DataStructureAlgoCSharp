using System;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Student s = new Student();
    s[0] = 0;
    s[1] = 1;
    s[2] = 2;
    s[3] = 3;
    print(s[2] == 2);
  }
}

public class Student {
  int[] scores = new int[4];

  public int this[int i] { // indexer // dictionary도 이렇게... (해시테이블 만들 때 써야 함)
    get { return scores[i]; }
    set { scores[i] = value; }
  }
}
