# ![NetworkPorts](https://raw.githubusercontent.com/MarkCiliaVincenti/NetworkPorts/master/logo32.png) NetworkPorts
 [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/MarkCiliaVincenti/NetworkPorts/.NET?logo=github&style=for-the-badge)](https://actions-badge.atrox.dev/MarkCiliaVincenti/NetworkPorts/goto?ref=master) [![Nuget](https://img.shields.io/nuget/v/NetworkPorts?label=NetworkPorts&logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/NetworkPorts) [![Nuget](https://img.shields.io/nuget/dt/NetworkPorts?logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/NetworkPorts)

Constants for common network ports. Stop writing port numbers like 80 and 443 in your code and start using NetworkPort.Http and NetworkPort.Https instead.

## Installation
The recommended means is to use [NuGet](https://www.nuget.org/packages/NetworkPorts), but you could also download the source code from [here](https://github.com/MarkCiliaVincenti/NetworkPorts/releases).

## Usage
```csharp
builder.WebHost.UseKestrel(k =>
{
    k.ListenAnyIp(
        NetworkPort.Http,
        listenOptions =>
        {
            listenOptions.Protocols = HttpProtocols.Http1;
        });
    });
}
```
