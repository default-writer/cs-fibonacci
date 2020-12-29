using System;
using System.Collections;
using System.Collections.Generic;

class MyEnumerator: IEnumerator<int> {
    readonly int number;
    int f1 = 1;
    int f2 = 1;
    public MyEnumerator(int N) 
    {
        number = N;
    }
    public bool MoveNext()
    {
        if (f1 + f2 < number) {
            int tmp = f2;
            f1 = f1 + f2;
            f2 = tmp;
            return true;
        }
        return false;
    }
    public void Reset()
    {
        f1 = 1;
        f2 = 1;        
    }
    object IEnumerator.Current { get { return Current; } }
    public int Current { get { return f1; } }
    void IDisposable.Dispose() {}
}

public class MyEnumerable<T> : IEnumerable<T> {
  private IEnumerator<T> m_enumerator;
  public MyEnumerable(IEnumerator<T> e) {
    m_enumerator = e;
  }
  public IEnumerator<T> GetEnumerator() { 
    return m_enumerator;
  }
  IEnumerator IEnumerable.GetEnumerator() { return (IEnumerator)GetEnumerator(); }
}

class MainClass {
  public static void Main (string[] args) {
    Console.WriteLine("До какого числа считать ряд Фибонначи");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Hello World");
    foreach(int fibonacci in new MyEnumerable<int>(new MyEnumerator(number)))
    {
        Console.WriteLine(fibonacci);
    }
  }
}