MonopolyProject

# MONOPOLY 
## Implementing the iterator, singleton and decorator design patterns

### Game functionalities 
#### The Gameboard
After testing a few different options, I decided the most practical way of displaying the gamebard would be to lay out the entire circuit horizontally. 

![gameboard2](https://user-images.githubusercontent.com/58735251/70862655-42a91780-1f3f-11ea-92cd-f32da26c6bbd.png)

This made it easy to display such things as the letters A and B of the players moving along the board, or mark which properties they own.
#### The Properties
The property class is defined by the following attributes: box number, name, property price, total price, and the owner.
I based the property locations, names and price on the following monopoly board:

![monopoly](https://user-images.githubusercontent.com/58735251/70861266-dffa5080-1f2b-11ea-915c-fb54bacba80c.PNG)

The total price was added as an attribute because the overall value of the property increases when the player adds houses or hotels to the property. A house costs *0.5 x propertyprice* and a hotel costs the full price of the property. The total sum of all of these costs is then used to calculate the higher tax price for an opposing player that lands on this property.
The Owner attribute corresponds to a the Player that owns said property.

#### The Players

### Design Patterns
#### Singleton

#### Iterator

#### Decorator





