using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    Action<object> print = Console.WriteLine;

    List<Student> list = new List<Student> {
      new Student() {Id = 0, Name = "ctkim", Height = 175},
      new Student() {Id = 1, Name = "Steve", Height = 167},
      new Student() {Id = 2, Name = "Brown", Height = 180},
      new Student() {Id = 3, Name = "Won",   Height = 171},
      new Student() {Id = 4, Name = "JJ",    Height = 165}
    };

    List<Score> scores = new List<Score> {
      new Score() {StudentId = 0, /* Name = "ctkim", */ Subject = "Math", Point = 100},
      new Score() {StudentId = 4, /* Name = "JJ",    */ Subject = "Math", Point = 50},
      new Score() {StudentId = 3, /* Name = "Won",   */ Subject = "Math", Point = 90},
      new Score() {StudentId = 2, /* Name = "Brown,  */ Subject = "Math", Point = 10},
      new Score() {StudentId = 1, /* Name = "Steve", */ Subject = "Math", Point = 60},
      new Score() {StudentId = 0, /* Name = "ctkim", */ Subject = "English", Point = 75},
      new Score() {StudentId = 4, /* Name = "JJ",    */ Subject = "English", Point = 100},
      new Score() {StudentId = 3, /* Name = "Won",   */ Subject = "English", Point = 75},
      new Score() {StudentId = 2, /* Name = "Brown", */ Subject = "English", Point = 11},
      new Score() {StudentId = 1, /* Name = "Steve", */ Subject = "English", Point = 65}
    };

    var ss4 = // 낙제생 (과락(60미만)없이 평균 80이상) 쿼리로 뽑기
      from s in (
        from s in list
        join score in scores on s.Id equals score.StudentId
        group score by s.Name into studentGroup
        select new {Name = studentGroup.Key, 
                    Average = studentGroup.Average(s => s.Point), 
                    Min = studentGroup.Min(s => s.Point)}
      )
      where s.Average < 80 || s.Min < 60
      select s.Name;

    print(ss4.Stringify());
  }
}

public class Student {
  public int Id {get; set;}
  public string Name {get; set;}
  public int Height {get; set;}

  public override string ToString() {return Name;}
}

public class Score {
  public int StudentId {get; set;}
  public string Name {get; set;}
  public string Subject {get; set;}
  public int Point {get; set;}
}

public static class ClassExtension {
  public static string Stringify<T>(this IEnumerable<T> list) {
    return String.Join("\n", list);
  }
}

/*
2019-04-12
1.
낙제생 (과락(60미만)없이 평균 80이상) 쿼리로 뽑기
합격생도...

출력은 이름만 찍기
*/
