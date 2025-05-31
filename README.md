# ![ListShuffle](https://raw.githubusercontent.com/MarkCiliaVincenti/ListShuffle/master/logo32.png)&nbsp;ListShuffle
 [![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/MarkCiliaVincenti/ListShuffle/dotnet.yml?branch=master&logo=github&style=flat)](https://actions-badge.atrox.dev/MarkCiliaVincenti/ListShuffle/goto?ref=master) [![Nuget](https://img.shields.io/nuget/v/ListShuffle?label=ListShuffle&logo=nuget&style=flat)](https://www.nuget.org/packages/ListShuffle) [![Nuget](https://img.shields.io/nuget/dt/ListShuffle?logo=nuget&style=flat)](https://www.nuget.org/packages/ListShuffle) [![Codacy Grade](https://img.shields.io/codacy/grade/4487c62452f240418a84e82893dcb6e9?style=flat)](https://app.codacy.com/gh/MarkCiliaVincenti/ListShuffle/dashboard) [![Codecov](https://img.shields.io/codecov/c/github/MarkCiliaVincenti/ListShuffle?label=coverage&logo=codecov&style=flat)](https://app.codecov.io/gh/MarkCiliaVincenti/ListShuffle)

Thread-safe list, array and span shuffle extension library, using Fisher-Yates shuffle and optional cryptographically-strong random.

## Installation
The recommended means is to use [NuGet](https://www.nuget.org/packages/ListShuffle), but you could also download the source code from [here](https://github.com/MarkCiliaVincenti/ListShuffle/releases).

## Usage (using `Random`)
```csharp
var myList = new List<string>();
myList.Add("Item A");
myList.Add("Item B");
myList.Add("Item C");

myList.Shuffle();
```

```csharp
var myArray = new string[3];
myArray[0] = "Item A";
myArray[1] = "Item B";
myArray[2] = "Item C";

myArray.Shuffle();
```

```csharp
Span<string> mySpan = stackalloc string[3];
mySpan[0] = "Item A";
mySpan[1] = "Item B";
mySpan[2] = "Item C";

mySpan.Shuffle();
```

## Usage (using `RandomNumberGenerator`)
If you need cryptographically-strong random in order to shuffle the list, array or span, you can use the `CryptoStrongShuffle` method instead. This method is less performant and only use it if you absolutely need to.

```csharp
var myList = new List<string>();
myList.Add("Item A");
myList.Add("Item B");
myList.Add("Item C");

myList.CryptoStrongShuffle();
```

```csharp
var myArray = new string[3];
myArray[0] = "Item A";
myArray[1] = "Item B";
myArray[2] = "Item C";

myArray.CryptoStrongShuffle();
```

```csharp
Span<string> mySpan = stackalloc string[3];
mySpan[0] = "Item A";
mySpan[1] = "Item B";
mySpan[2] = "Item C";

mySpan.CryptoStrongShuffle();
```
