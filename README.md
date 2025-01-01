# Games

Just a quick test repo to experiment a bit with SpecFlow Testing.

Also, learning a tiny bit about [chess programming](https://www.chessprogramming.org/Main_Page).


## Testing

Read the file `MakeMove.feature`. It contains a background, which will be applied before each test.
Each test then runs with a few preparation statements (`When` keyword). In that step, it will execute the code that is behind it.
After that, it asserts everything that is described in the `Then` section.

I also made a few "StepTransformations" to make it easier viewing the chess board. That way, I don't have to work with coordinates etc.

Hint: get a Req'n'Roll extension in your IDE.
- JetBrains Rider: https://plugins.jetbrains.com/plugin/24012-reqnroll-for-rider
- Visual Studio 2022: https://marketplace.visualstudio.com/items?itemName=Reqnroll.ReqnrollForVisualStudio2022

Then, just control-click the steps in the `.feature` files to see the code-behind.