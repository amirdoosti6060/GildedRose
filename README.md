# Gilded Rose Refactoring Kata

Hi and welcome to team Gilded Rose. As you know, we are a small inn with a 
prime location in a prominent city ran by a friendly innkeeper named 
Allison. We also buy and sell only the finest goods. Unfortunately, our 
goods are constantly degrading in quality as they approach their sell by 
date. We have a system in place that updates our inventory for us. It was 
developed by a no-nonsense type named Leeroy, who has moved on to new 
adventures. Your task is to add the new feature to our system so that we 
can begin selling a new category of items. First an introduction to our 
system:

- All items have a SellIn value which denotes the number of days we have 
to sell the item
- All items have a Quality value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item

Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, Quality degrades twice as fast
- The Quality of an item is never negative
- "Aged Brie" actually increases in Quality the older it gets
- The Quality of an item is never more than 50
- "Sulfuras", being a legendary item, never has to be sold or decreases 
in Quality
- "Backstage passes", like aged brie, increases in Quality as it's SellIn 
value approaches; Quality increases by 2 when there are 10 days or less 
and by 3 when there are 5 days or less but Quality drops to 0 after the 
concert

We have recently signed a supplier of conjured items. This requires an 
update to our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any 
new code as long as everything still works correctly. However, do not 
alter the Item class or Items property as those belong to the goblin 
in the corner who will insta-rage and one-shot you as he doesn't 
believe in shared code ownership (you can make the UpdateQuality 
method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increase 
above 50, however "Sulfuras" is a legendary item and as such its 
Quality is 80 and it never alters.

## Developement Environment
Here is my developement environment and packages specification used for this project:
- Windows 10 Enterprise - 64 bits
- Visual Studio Enterprise 2022 (64 bits) - version 17.2.5
- Microsoft .NET Framework 4.8 (4.8.04084)
- Installed Packages:
	- GitVersionTask (5.5.1)
	- xunit (2.4.2)
	- xunit.abstractions (2.0.3)
	- xunit.analizers (1.0.0)
	- xunit.assert (2.4.2)
	- xunit.core (2.4.2)
	- xunit.extensibility.core (2.4.2)
	- xunit.extensibility.execution (2.4.2)
	- xunit.runner.visualstudio (2.4.5)

## How to run
1. Open the solution in appropriate Visual Studio
2. Run GildedRose.Console application simply by click on "Start" button. Just to be sure program run without problem
3. Open TestAssemblyTests.cs and Open "Test Explorer" and then click on "Run All Tests in View". All test should pass
4. From Test menu, execute "Analyze code coverage for all tests". Coverage for both project should be 100%

## Refactoring Steps
1. Clone original projects and initiate new git repository  
2. Prepare projects by converting them to .Net Framework 4.8 and update packages  
3. Implement unit tests and check current functionality with business rules  
4. Coverage code test and make sure it is good enough  
5. Refactoring 
	1. Implement Object Oriented approach  
	2. Define GuildedRoseApp class and use it  
	3. Define constants and finilize refactoring  
6. Add new feature (New item type) 
	1. Add new product (Conjured)  
	2. Add more unit tests and provide more test data  
7. Bug fix and code improvements  
8. Execute code coverage test and unit tests again  
9. Complete README.md

## Branching Strategy
For this project the following branching strategy is followed:
1. Keep master update as a main branch
2. For each major changes a new branch is created
3. After the change is done, the branch is merged to master
4. On master, only README.md file and minor changes is done

## License

MIT

## Suggested attribution

This exercise is implemented by **Amir Doosti** <amirdoosti@gmail.com>

This exersise is designed by [@TerryHughes](https://twitter.com/TerryHughes), [@NotMyself](https://twitter.com/NotMyself)

The original repository can be found at [https://github.com/NotMyself/GildedRose](https://github.com/NotMyself/GildedRose)
