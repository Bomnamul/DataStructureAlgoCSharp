using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    Student std1 = new Student("양덕진", new List<int> {97, 70, 62, 82, 69});
    Student std2 = new Student("김섬뜩", new List<int> {55, 93, 88, 76, 90});
    Student std3 = new Student("알파카", new List<int> {10, 22, 100, 7, 13});
    Student std4 = new Student("재민이", new List<int> {100, 89, 95, 97, 88});
    Student[] students = {std1, std2, std3, std4};

    List<string> repeaters = new List<string>();
    List<string> nonRepeaters = new List<string>();

    for (int i = 0; i < students.Length; i++) {
      bool result = students[i].Scores.TrueForAll(x => x >= 60); // 과락 검사, FindAll 쓰면 for 루프 필요없음
      if (result == true) {
        nonRepeaters.Add(students[i].Name);
      } else {        
        repeaters.Add(students[i].Name);
      }
    }

    print(nonRepeaters.Stringify() == "양덕진 재민이"); // 과락 testcase
    print(repeaters.Stringify() == "김섬뜩 알파카");
  }
}

public class Student {
  public string Name {get; set;}
  public List<int> Scores {get; set;}

  public Student(string name, List<int> scores) {
    Name = name;
    Scores = scores;
  }
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join(" ", list);
  }
}

/*
student class
string name get set
list<int> scores get set
list method

점수중에 60점 미만이 하나라도 있으면 (과락) 낙제생 리스트 (이름) 넣기
낙제생이 아닌 사람들 리스트 (이름) 구하기

Console.WriteLine(nonRepeaters.String..)
repeaters

최대한 compact 하게?
*/