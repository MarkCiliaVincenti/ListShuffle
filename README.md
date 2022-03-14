# ![ListShuffle](https://raw.githubusercontent.com/MarkCiliaVincenti/ListShuffle/master/logo32.png) ListShuffle
 [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/MarkCiliaVincenti/ListShuffle/.NET?logo=github&style=for-the-badge)](https://actions-badge.atrox.dev/MarkCiliaVincenti/ListShuffle/goto?ref=master) [![Nuget](https://img.shields.io/nuget/v/ListShuffle?label=ListShuffle&logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/ListShuffle) [![Nuget](https://img.shields.io/nuget/dt/ListShuffle?logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/ListShuffle)

Thread-safe list shuffle extension library, using Fisher-Yates shuffle and optional cryptographically-strong random.

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

## Usage (using `RandomNumberGenerator`)
If you need cryptographically-strong random in order to shuffle the list, you can use the `CryptoStrongShuffle` method instead. This method is less performant and only use it if you absolutely need to.

```csharp
var myList = new List<string>();
myList.Add("Item A");
myList.Add("Item B");
myList.Add("Item C");

myList.CryptoStrongShuffle();
```
