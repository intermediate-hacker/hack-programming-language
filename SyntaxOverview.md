# Introduction #

Hack has a simple syntax, a little similar to Lua , Python , Pascal and C#.

## The 'Hello World' Example ##
A simple hello world program in the hack programming language. I will explain things later on.
```
writeln "Hello World!"
```

A more comprehensive program:
```
var hello = "Hello World!"
writeln hello
readln
```

# Details #
## Expressions ##
For now, you can't type more than one expression in a line, since the compiler differentiates expressions by '\n' instead of ';'.

## Variables ##
Variables can be declared with the **var** keyword. For example:
```
var mystr = "This is a string!"
var mynum = 23
var mychr = 'H'
```

The variable type is determined by the compiler either at compile-time or at run-time, depending on the situation.

## Function Calls ##
You can simple call functions by their name followed by their arguments separated by a ','. for example:
```
writeln "Hello World!"
readln
swap mystr1, mystr2
```

## Functions ##
<to be implemented>

## Inline C# Code ##
You can type inline C# code using the `#__csc__` and `#__end__` pre-processor directives. You can also use the local hack variables in the inline C# code. for example:
```
var m = "Hello!"
#__csc__
System.Windows.Forms.MessageBox.Show(m);
#__end__
writeln "I just used inline C Sharp!!!"
```