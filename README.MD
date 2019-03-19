# Math calculator

Calculator evaluates expression by converting [Infix](https://en.wikipedia.org/wiki/Infix_notation) notation to [Postfix](https://en.wikipedia.org/wiki/Reverse_Polish_notation).

Calculator has several types of expression elements:
+ number (float with point)
+ constant (PI, E)
+ operator (+, -, *, /)
+ function (sin, cos)

# Usage

1. Enter your expression to console
1. Get result

`Attention`: Current realization of parser can parse only elements between which exists whitespace.

# Extension 

## Adding new expression elements

1. Choose what type of element you want to add
1. Inherit new element class from base element
1. Define class attribute `StringDefinitionAttribute` with string value of element
1. Add implementation logic of your element
1. ???
1. Profit