# MathExtended.Common

Pure C# MathLibrary.

# Legal information and credits

MathExtended is project by Ales Hotko and was first released in 2020. It's licensed under the MIT license.

------



### Clamping

<details>
<summary>Code Example with Output</summary>
<p>

```csharp
for (double x = -0.5; x <= 1.5; x += 0.1)
{
    double clampDefault = Clamping.Clamp(x);
    double clampLimited = Clamping.Clamp(x, -2.0, 1.5);
    double smoothStep = Clamping.SmoothStep(x); //same as SmoothStep3
    double smoothStep3 = Clamping.SmoothStep3(x);
    double smoothStep5 = Clamping.SmoothStep5(x);
    double smoothStep7 = Clamping.SmoothStep7(x);
    double smootherStep = Clamping.SmootherStep(x);

    Console.WriteLine();
    Console.WriteLine($"Clamping.Clamp({x:N1}) = {clampDefault:N3}");
    Console.WriteLine($"Clamping.Clamp({x:N1}, -2.0, 1.5) = {clampLimited:N3}");
    Console.WriteLine($"Clamping.SmoothStep({x:N1}) = {smoothStep:N3}");
    Console.WriteLine($"Clamping.SmoothStep3({x:N1}) = {smoothStep3:N3}");
    Console.WriteLine($"Clamping.SmoothStep5({x:N1}) = {smoothStep5:N3}");
    Console.WriteLine($"Clamping.SmoothStep7({x:N1}) = {smoothStep7:N3}");
    Console.WriteLine($"Clamping.SmootherStep({x:N1}) = {smootherStep:N3}");
}

// The Output is:
// Clamping.Clamp(-0.1) = 0.000
// Clamping.Clamp(-0.1, -2.0, 1.5) = -0.100
// Clamping.SmoothStep(-0.1) = 0.000
// Clamping.SmoothStep3(-0.1) = 0.000
// Clamping.SmoothStep5(-0.1) = 0.000
// Clamping.SmoothStep7(-0.1) = 0.000
// Clamping.SmootherStep(-0.1) = 0.000
// 
// Clamping.Clamp(0.0) = 0.000
// Clamping.Clamp(0.0, -2.0, 1.5) = 0.000
// Clamping.SmoothStep(0.0) = 0.000
// Clamping.SmoothStep3(0.0) = 0.000
// Clamping.SmoothStep5(0.0) = 0.000
// Clamping.SmoothStep7(0.0) = 0.000
// Clamping.SmootherStep(0.0) = 0.000
// 
// Clamping.Clamp(0.1) = 0.100
// Clamping.Clamp(0.1, -2.0, 1.5) = 0.100
// Clamping.SmoothStep(0.1) = 0.028
// Clamping.SmoothStep3(0.1) = 0.028
// Clamping.SmoothStep5(0.1) = 0.009
// Clamping.SmoothStep7(0.1) = 0.003
// Clamping.SmootherStep(0.1) = 0.009
// 
// Clamping.Clamp(0.2) = 0.200
// Clamping.Clamp(0.2, -2.0, 1.5) = 0.200
// Clamping.SmoothStep(0.2) = 0.104
// Clamping.SmoothStep3(0.2) = 0.104
// Clamping.SmoothStep5(0.2) = 0.058
// Clamping.SmoothStep7(0.2) = 0.033
// Clamping.SmootherStep(0.2) = 0.058
// ...
// Clamping.Clamp(0.9) = 0.900
// Clamping.Clamp(0.9, -2.0, 1.5) = 0.900
// Clamping.SmoothStep(0.9) = 0.972
// Clamping.SmoothStep3(0.9) = 0.972
// Clamping.SmoothStep5(0.9) = 0.991
// Clamping.SmoothStep7(0.9) = 0.997
// Clamping.SmootherStep(0.9) = 0.991
// 
// Clamping.Clamp(1.0) = 1.000
// Clamping.Clamp(1.0, -2.0, 1.5) = 1.000
// Clamping.SmoothStep(1.0) = 1.000
// Clamping.SmoothStep3(1.0) = 1.000
// Clamping.SmoothStep5(1.0) = 1.000
// Clamping.SmoothStep7(1.0) = 1.000
// Clamping.SmootherStep(1.0) = 1.000
// 
// Clamping.Clamp(1.1) = 1.000
// Clamping.Clamp(1.1, -2.0, 1.5) = 1.100
// Clamping.SmoothStep(1.1) = 1.000
// Clamping.SmoothStep3(1.1) = 1.000
// Clamping.SmoothStep5(1.1) = 1.000
// Clamping.SmoothStep7(1.1) = 1.000
// Clamping.SmootherStep(1.1) = 1.000
```

</p>
</details>


### Mapping

```csharp
// Mapping values in range [-5, 5] to range [3, 8]
for (double x = -5.0; x <= 5.0; x += 0.5)
{
    double mapping = Mapping.Map(x, -5.0, 5.0, 3.0, 8.0);
    Console.WriteLine($"{x,5:N1} {mapping,9:N1}");
}

// The Output is:
//     x    mapped
//  -5.0       3.0
//  -4.5       3.3
//  -4.0       3.5
//  -3.5       3.8
//  -3.0       4.0
//  -2.5       4.3
//  -2.0       4.5
//  -1.5       4.8
//  -1.0       5.0
//  -0.5       5.3
//   0.0       5.5
//   0.5       5.8
//   1.0       6.0
//   1.5       6.3
//   2.0       6.5
//   2.5       6.8
//   3.0       7.0
//   3.5       7.3
//   4.0       7.5
//   4.5       7.8
//   5.0       8.0
```



### Wrapping

```csharp
for (double x = -5.0; x <= 5.0; x += 0.5)
{
    double wrapping = Wrapping.Wrap(x, -1, 1);

    Console.WriteLine($"{x,5:N1} {wrapping,9:N1}");
}

// The Output is:
//    x    wrapped
//  -5.0      -1.0
//  -4.5      -0.5
//  -4.0       0.0
//  -3.5       0.5
//  -3.0      -1.0
//  -2.5      -0.5
//  -2.0       0.0
//  -1.5       0.5
//  -1.0      -1.0
//  -0.5      -0.5
//   0.0       0.0
//   0.5       0.5
//   1.0      -1.0
//   1.5      -0.5
//   2.0       0.0
//   2.5       0.5
//   3.0      -1.0
//   3.5      -0.5
//   4.0       0.0
//   4.5       0.5
//   5.0      -1.0
```


