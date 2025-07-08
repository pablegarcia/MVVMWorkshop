# MVVMWorkshop
Workshop to show the MVVM architecture

## .NET

Used .NET 8.

## Apps

There are 2 types of apps to run, Desktop (MVVMApp) and Web (MVVMApp.TS)

### Desktop App

To run the desktop app, a customized View and Model layers have to be configured first.

1. Set MVVMApp as startup project
2. Open ```appsettings.json``` file and edit View and Model settings with any these sopported values
```
View: AAA, BBB, CCC
Model: DB, FileSystem, Web
```
3. Build and run the program

### Web App

To run the web app,

1. Set MVVMApp.API as startup project
2. Run MVVMApp.API
3. Go to MVVMApp.TS folder and in a command prompt run
```
npm install
npm run start
```
4. Open the URL http://localhost:1337