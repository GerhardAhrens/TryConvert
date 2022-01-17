# TryConvert <img src="./TryConvert.png" style="width:50px;"/>

### The program is written for .NET5

## TryConvert for any Type

The TryConvert class provides a collection of methods for converting types. I think the creation and use of extension is a good thing. Extension can be easily applied to a data type. But a disadvantage is, that it is not possible to filter or group extension. So it is possible that per data type many extension methods are shown per data type. Thus the selection becomes unclear.

### Example
```
Dictionary<int,string> dict = new Dictionary<int, string>() 
{
    { 1, "value1" },
    { 2, "value2" }
};

string text = TryConvert.ToString(dict);

```
## Result
```
1=value1;2=value2
```
