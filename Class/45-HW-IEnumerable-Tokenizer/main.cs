// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.ienumerable?view=netframework-4.7.2
// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.ienumerator?view=netframework-4.7.2
// https://docs.microsoft.com/ko-kr/dotnet/api/system.collections.generic.ienumerator-1?view=netframework-4.7.2

using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {

    Tokens tokens = new Tokens("this is a sample sentence.", new char[] {' ', '-'});
    foreach (string t in tokens) {
      Console.WriteLine(t);
    }
  }
}

public class Tokens : IEnumerable {
  string[] elements;

  public Tokens(string source, char[] delimiters) {
    elements = source.Split(delimiters);
  }

  public IEnumerator GetEnumerator() {
    // return elements.GetEnumerator(); // 가능
    return new TokenEnumerator(this); // elements 가능? tokens type
  }

  class TokenEnumerator : IEnumerator {
    Tokens t;
    int position = -1;
    
    public TokenEnumerator(Tokens t) {
      this.t = t;
    }

    public bool MoveNext() {
      if (position < t.elements.Length - 1) {
        position++;
        return true;
      } else {
        return false;
      }
    }

    public object Current {
      get {
        return t.elements[position];
      }
    }

    public void Reset() {
      position = -1;
    }
  }
}
