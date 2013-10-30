# Colectica Designer Addins

Colectica Designer can be extended by developing Addins. Addins are developed as .NET class libraries, and can be implemented in C#, F#, or Visual Basic. Colectica Designer offers several extension points. See below for a description and sample source code for each type of extension point.

## Types of Addins

### Commands

#### IStandAloneCommand

Adds a button to the main ribbon, and executes your code when the user clicks the button.

![A sample stand-alone command](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/standalone-command.png)

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Commands/SampleStandAloneCommand.cs)

#### IVersionableCommand

Adds a button to the ribbon for a particular item, and a menu item to the context menu for that item. Your code is executed when the user clicks the button or menu item.

![A sample versionable command](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/versionable-command.png)

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Commands/SampleVersionableCommand.cs)

#### IVersionableCommandProvider

Adds multiple buttons to the ribbon for an item, each of which executes the same code but with a different parameter.

![A sample versionable command provider](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/versionable-command-provider.png)

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Commands/SampleVersionableCommandProvider.cs)

#### IVersionableInitializerCommand

Adds code that is executed when a new item is created.

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Commands/SampleVersionableInitializer.cs)

#### INodeCommand

Adds an item to the ribbon for a particular item in the navigator, and to the context menu for that item.

![A sample node command](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/node-command.png)

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Commands/SampleNodeCommand.cs)

### Views

#### IDockingView

Adds a view that can be docked to any of the sides of Colectica Designer.

![A sample docking view](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/docking-view.png)

Sample Source Code: [XAML](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Views/SampleDockingView.xaml), [CSharp](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Views/SampleDockingView.xaml.cs)

#### IVersionableView

Adds a content view for an item, like the built-in Editor and DDI views.

![A sample versionable view](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/versionable-view.png)

Sample Source Code: [XAML](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Views/SampleVersionableView.xaml), [CSharp](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Views/SampleVersionableView.xaml.cs)

### Quality Statements

#### IQualityStatementInformationGatherer

Collects information to be included in a Quality Statement.

![A sample quality statement item information gatherer](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/quality-item-information-gatherer.png)

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Quality/SampleQualityStatementInformationGatherer.cs)

#### IQualityStatementItemFilter

Filters which Quality Statements are currently displayed.

![A sample quality statement item filter](https://raw.github.com/Colectica/ColecticaSampleAddins/master/doc/img/quality-item-filter.png)

[Sample Source Code](https://github.com/Colectica/ColecticaSampleAddins/blob/master/src/Colectica.SampleAddins/Quality/SampleQualityStatementItemFilters.cs)

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