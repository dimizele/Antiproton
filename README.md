# Antiproton

This framework was build to develop an extensible Selenium framework in .Net, that wraps the base Selenium classes, allowing for logging and additional custom features.

### Installing

To install the test framework simply download the code (or clone it) and open it in Visual Studio or other .NET Core IDE.

### Running the tests

The tests are run with the help of the NUnit NuGet package. Simply open the test explorer on the IDE of your choice and run the tests. The current version is using 88.0.4324.104 Chrome version, so if you have an older or a newer version it might not work. Try updating the Selenium.Chrome.WebDriver NuGet package to your current chrome version.

### Contributing

Pull requests are always welcome. With each pull request a separate job is started that builds the solution. If the build fails, please update your Pull request.

### Antiproton

This is the heart of the framework. Here we have the main Selenium wrappers. As well as some additional classes, for customizability. The changes here should be minimum.

### Entities

This is where we keep the Pages and PageComponents. The point is to try and get as seamless transition between pages and components as possible, so try to keep that in mind.

### Helpers

This is a helper class, feel free to add anything here that might help you.

### TestBase and Tests

This is where we initialize what we are going to need in the tests and write the tests themselves.
