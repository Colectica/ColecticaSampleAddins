# Colectica Designer Addins

Colectica Designer can be extended by developing Addins. Addins are developed as .NET class libraries, and can be implemented in C#, F#, or Visual Basic. Colectica Designer offers several extension points. See below for a description and sample source code for each type of extension point.

## Types of Addins

### Commands

#### IStandAloneCommand

Adds a button to the main ribbon, and executes your code when the user clicks the button.

#### IVersionableCommand

Adds a button to the ribbon for a particular item, and a menu item to the context menu for that item. Your code is executed when the user clicks the button or menu item.

#### IVersionableCommandProvider

Adds multiple buttons to the ribbon for an item, each of which executes the same code but with a different parameter.

#### IVersionableInitializerCommand

Adds code that is executed when a new item is created.

#### INodeCommand

Adds an item to the ribbon for a particular item in the navigator, and to the context menu for that item. 

### Views

#### IDockingView

Adds a view that can be docked to any of the sides of Colectica Designer.

#### IVersionableView

Adds a content view for an item, like the built-in Editor and DDI views.

### Quality Statements

#### IQualityStatementInformationGatherer

Collects information to be included in a Quality Statement.

#### IQualityStatementItemFilter

Filters which Quality Statements are currently displayed.

## Deploying Addins

Once you have a .NET assembly that implements one or more of the extension points described above, deploying the Addin is as simple as copying the DLL file to one of two locations:

- %programfiles(x86)%\Colectica\Colectica Designer\Addins
- %appdata%\Algenta\Colectica\Addins

The next time you restart Colectica Designer, your Addins will automatically be loaded.

## Sample Addins Project

Source code demonstrating each type of Addin is available at GitHub at <https://github.com/colectica/ColecticaSampleAddins>.

## Additional Extension Points

Please [let us know](http://www.colectica.com/contact/) what additional extension points would be useful for you. We look forward to expanding the Addin possibilities based on your feedback.

## Colectica Addins Workshop

Interested in working with the Colectica developers to create your own Addins? [Get in touch](http://www.colectica.com/contact/) to schedule a hands-on development workshop.