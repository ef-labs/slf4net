Simple Logging Facade for .Net (slf4net)
========

[![NuGet](https://img.shields.io/nuget/v/slf4net.svg)](https://www.nuget.org/packages/slf4net) 
[![NuGet](https://img.shields.io/nuget/dt/slf4net.svg)](https://www.nuget.org/packages/slf4net)
[![Build Status](https://travis-ci.org/ef-labs/slf4net.svg?branch=develop)](https://travis-ci.org/ef-labs/slf4net)

The slf4net project serves as a light weight abstraction layer for various logging frameworks such as log4net and NLog.  This allows the end user to plug in the desired logging framework at deployment time.


This project was inspired by the [Java slf4j project](http://www.slf4j.org/) (which it tries to follow as closely as possible) and an earlier [.Net slf project](http://slf.codeplex.com/).


Installing slf4net
-------------------
Find slf4net on nuget.org: http://nuget.org/packages?q=slf4net

When deploying your application, choose either the slf4net.log4net or slf4net.NLog package, or create your own wrapper for your favourite logging framework.


Configuration
-------------
See the [configuration wiki page](https://github.com/englishtown/slf4net/wiki/Configuration).


Getting started
----------------
Intall the slf4net nuget package to your project.  If a logger factory is not configured, a NOPLogger (no operation logger) will be used.  Start logging.

```c#
using System;

namespace slf4net.Samples
{
    public class MyClass
    {

        private static readonly slf4net.ILogger _logger = slf4net.LoggerFactory.GetLogger(typeof(MyClass));

        public void Foo()
        {
            _logger.Trace("Foo started at {0}.", DateTime.Now);

            // Do some work

            _logger.Trace("Foo() completed at {0}.", DateTime.Now);
        }

    }
}
```


License terms
-------------
slf4net is published under the [MIT license](http://englishtown.mit-license.org).


Building
-------------

Rebuild and run tests:

```bash
msbuild -t:clean,rebuild,test -restore -p:Configuration=Release src/slf4net.sln
```

Package:

```bash
version=1.0.0
path=${PWD}/nuget
msbuild -t:clean,rebuild,test,pack -restore -p:Configuration=Release,Version=${version},PackageOutputPath=${path} src/slf4net.sln
```
