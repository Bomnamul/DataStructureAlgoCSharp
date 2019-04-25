using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Hashtable ht = new Hashtable();
    ht.Add("txt", "notepad.exe");
    ht.Add("bmp", "paint.exe");
    ht.Add("dib", "paint.exe");
    ht.Add("rtf", "wordpad.exe");
    print(ht.Count == 4);

    try {
      ht.Add("txt", "winword.exe"); // key는 unique해야 함
    } catch {
      print("already exist !");
    }
    print(ht.Count == 4);

    ht["max"] = "3dsmax.exe"; // array 참조 연산자를 사용가능?
    print(ht.Count == 5);

    print((string)ht["max"] == "3dsmax.exe");

    print(ht.ContainsKey("bmp") == true);
    ht.Remove("bmp");
    print(ht.ContainsKey("bmp") == false);

    Hashtable users = new Hashtable();
    users[100] = new User(100, "djyang", 26);
    users[101] = new User(101, "brown", 30);
    users[102] = new User(102, "hash", 10);
    print(users.Count == 3);
  }
}

public class User {
  public int Id {get; set;}
  public string Name {get; set;}
  public int Age {get; set;}
  public User(int id, string name, int age) {
    Id = id;
    Name = name;
    Age = age;
  }
}
