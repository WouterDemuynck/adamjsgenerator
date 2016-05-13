# Introducing Adam.JSGenerator

Coding C# that produces JavaScript was, until now, an error prone task that primarily included concatenating a bunch of hardcoded strings with converted variables. Throw in a call to String.Format here and use a StringBuilder object there, and everything becomes a pretty unreadable mess. You’d have to make sure the names of variables are identical everywhere. You’d have to keep in mind that strings need to be properly quoted. And you’d have to match up the endless parade of brackets, be it square, curly or round. 

No more.

With **Adam.JSGenerator**, writing code that spits out snippets of JavaScript becomes a breeze. 

Now, instead of writing this line of unmaintainable code (selector, color and background are strings):

```csharp
return "jQuery('" + selector + "').css({color:'" + color + "';background:'" + background +"'});";
```

Can be written as:

```csharp
return JS.JQuery(selector).Dot("css").Call(JS.Object(new {color = color, background = background}));
```
## To get started

Have a look at our quick tour, install the package using NuGet, download the sourcecode, and run the demonstration program to give you a head start.

## What's changed in 1.3?

This new version contains two additions: the introduction of the ``ThisExpression`` class and the ``SnippetStatement`` class.

The ThisExpression class is used to produce the ``this`` keyword. It's easy to use like this:

```csharp
return JS.This().Dot("__someVar").AssignWith(JS.Null);
```

The ``SnippetStatement`` class is used in those cases where you wanted to include a snippet of code, but that code is already a statement and does not need a closing semicolon. In addition to adding this new class, two methods have been added to ``JS`` and one has been obsoleted. Where you would previously do this:

```csharp
return JS.Snippet("debugger");
```

you would now call the JS.Expression() method:

```csharp
return JS.Expression("debugger");
```

The two methods do exactly the same thing, but we've obsoleted the former to avoid any confusion. 

If you were to have some snippet that already includes the semicolon you would call the ``JS.Statement()`` method:

```csharp
return JS.Statement("debugger;");
```

Other than that, the ``SnippetStatement`` class derives from ``Statement``, not ``Expression``, so you can't use it by accident in those instances where an ``Expression`` object is required.

Feedback is welcomed!
## What's changed in 1.2?

Besides a couple smaller bugfixes, what's new in 1.2 is that the setup project is dropped and there will be no more binary releases on **CodePlex**. Please use **NuGet** to use the library in your project and automatically stay up-to-date!
