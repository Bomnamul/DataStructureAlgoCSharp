using System;
using System.Collections;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    Tokens f = new Tokens("this is a sample sentence.", new char[] {' ', '-'});

    foreach (string item in f) {
      Console.WriteLine(item);
    }
  }
}

public class Tokens : IEnumerable {
  string Str { get; set; }
  char[] List { get; set; }

  public Tokens(string str, char[] list) {
    Str = str;
    List = list;
  }
  
  public string[] Tokenize() {
    string[] split = Str.Split(List);
    return split;
  }

  public TokensEnum GetEnumerator() { return new TokensEnum(split); }
  IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

  public class TokensEnum : IEnumerator {
    public string[] split = Str.Split(List);
    int position = -1;

    public TokensEnum(string[] split) {
      this.split = split;
    }

    public string Current {
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