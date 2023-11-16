# .NET core 6 LTS Console App template

## Overview

The Console App template from Visual Studio:

or the same result created with this command-line: `dotnet new xxx` generates a very basic Console App.

It lacks:

- Logging,
- Application settings,
- Separation of "doing something" from "launching the program",
- Dependency Injection (for adaptive coding and unit test capabilities),
- Asynchronous capability (recommended to use with WebAPI REST calls and Cloud (Azure) resources).

So I created this template that adds all these built-in.

It allows me to get started fast for all mt coding Proof of Concepts.

Enjoy,
Emmanuel.

## Disclaimer

It is a starting point. There are a lots of features and practices that can, and should, be added.
But this is a way better starting point than the default "Console App".
