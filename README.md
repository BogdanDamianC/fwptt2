# fwptt2
fwptt it's a Web application tester program for load testing web applications.

I have decided to work on another version that moves from xsl to T4 templates and from Threads&webrequest to using the async framework & RestSharp.

Most of the features kinda work there for sure there are still things that I need to fix but in general most of the stuff works. There are a lot of big and small changes from the previous version, this release has 75% of the features developed as plugins, I moved from threads to tasks, this also cleared some of the shutdown issues that existed in the previous version.

Reloading the test results after the tests have were run is still something I have to do

There are 2 applications that you can use

1. fwptt.Desktop.App - desktop app that has a few wizzards for generating the tests and a fancyer test runner

2. fwptt.Console.App - this is a console application that can be used to run & rerun the test runs defined with the desktop application.


The Initial features for the desktop app are done there are a few more features that I'm adding to the console application
