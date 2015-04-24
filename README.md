# ObjectToDictionaryParser
Excellent for parsing object to querystring

Example of usage:
class Epsilon{
  public Delta d;
  public Alfa[] a;
  public int i;
}
class Delta{
  public string x;
}
class Alfa{
  public int a;
  public int b;
}

Epsilon e = new Epsilon();
e.d = new Delta();
e.i = 14;
e.a = new Alfa[3]();
e.d.x = "hello";
e.a[0].a = 0;
e.a[0].b = 1;
e.a[1].a = 2;
e.a[1].b = 3;

Dictionary<string,string> dic = new Dictionary<string,string>();
ObjectToDictionaryParser.parseObjectToDictionary(e, dic, True);

Dic output as Key = Value
d.x = hello
a[0].a = 0
a[0].b = 1
a[1].a = 2
a[1].b = 3
a[2] = null
i = 14
