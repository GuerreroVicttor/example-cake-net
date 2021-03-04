var target = Argument("target", "Publish");
var configuration = Argument("configuration", "Release");

var solutionFolder = "./";
var deployWebApiFolder = "./deploy/webapi";

Task("Clean")
    .Does(() =>
    {
        CleanDirectory(deployWebApiFolder);
        CleanDirectories("**/bin/" + configuration);
        CleanDirectories("**/obj/" + configuration);
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetCoreRestore(solutionFolder);
    });

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetCoreBuild(solutionFolder, new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetCoreTest(solutionFolder, new DotNetCoreTestSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true
        });
    });

Task("Publish")
    .IsDependentOn("Test")
    .Does(() =>
    {
        DotNetCorePublish(solutionFolder, new DotNetCorePublishSettings
        {
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = deployWebApiFolder
        });
    });

RunTarget(target);