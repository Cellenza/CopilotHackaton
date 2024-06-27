using ComplexMethod;

var reverseDictionary = new SearchInDictionary();

var dimensions = new Dictionary<string, int>
{
    { "1.0.5.6", 5},
    { "12.4.5.6", 12},
};

var result = reverseDictionary.Execute(dimensions, 12);
Console.WriteLine(result);