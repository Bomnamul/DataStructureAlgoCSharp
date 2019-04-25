using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Tokens f = new Tokens("this is a sample sentence.", new char[] {' ', '-'});
    
    foreach (string item in f) {
      System.Console.WriteLine(item);
    }
  }
}

public class Tokenize {
  public string Str { get; set; }
}

public class Tokens : IEnumerable<Tokenize> {
  string Str { get; set; }
  char[] List { get; set; }

  string[] split = Str.Split(List);

  public IEnumerator<string[]> GetEnumerator() { return new StringEnumerator(split); }
  IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

  class StringEnumerator : IEnumerator<string[]> {
    int position = -1;
    string[] split;

    public StringEnumerator(string[] split) {
      this.split = split;
    }

    public string[] Current {
      get { 
        return split[position];
      }
    }
    object IEnumerator.Current {
      get {
        return this.Current;
      }
    }

    public bool MoveNext() {
      if (position < split.Count - 1) {
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
/*
   Enumerator 직접 만들기
   split 함수로 쪼개서 string
   string array에 대한 Enumerator 만들기
   new char[] {' ', '-'} : Tokenize 기준

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
