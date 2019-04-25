// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic.ienumerator-1?view=netframework-4.7.2

using System;
using System.Collections;
using System.Collections.Generic;

public class Person {
  public string Name { get; set; }
  public override string ToString() { return Name; }
}

public class People : IEnumerable<Person> { // 중요?
  public List<Person> list { get; set; }

  // public IEnumerator<Person> GetEnumerator() { return list.GetEnumerator(); }
  public IEnumerator<Person> GetEnumerator() { return new PersonEnumerator(list); } // ICloneable 했던 거...
  IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

  class PersonEnumerator : IEnumerator<Person> {
    int position = -1;
    List<Person> list;

    public PersonEnumerator(List<Person> list) {
      this.list = list;
    }
    public Person Current {
      get {
        return list[position];
      }
    }
    object IEnumerator.Current {
      get {
        return this.Current;
      }
    }

    public bool MoveNext() {
      if (position < list.Count - 1) {
        position++;
        return true;
      } else
      return false;
    }
    public void Reset() {
      position = -1;
    }
    public void Dispose() {}
  }
}

class MainClass {
  public static void Main (string[] args) {
    People people = new People();
    people.list = new List<Person>() {
      new Person() { Name = "djyang" },
      new Person() { Name = "Steve" },
      new Person() { Name = "Brown" },
      new Person() { Name = "Won" },
      new Person() { Name = "JJ" },
    };

    foreach(var person in people)
    Console.WriteLine(person.Name);
  }
}

/*
Enumerator 직접 만들기
split 함수로 쪼개서 string
string array에 대한 Enumerator 만들기

Tokens f = new Tokens("this is a sample sentence.", new char[] {' ', '-'});
foreach (string item in f)
{
  System.Console.WriteLine(item);
}

this
is
a
sample
sentence.
*/