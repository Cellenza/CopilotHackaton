// See https://aka.ms/new-console-template for more information

using DemoFix;

Console.WriteLine("Hello, World!");

// Run 10 tasks with a maximum of 2 concurrent tasks
await MyClassExemple5.Run(2, 10);