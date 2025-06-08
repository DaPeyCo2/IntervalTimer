# IntervalTimer

This repository contains a basic .NET MAUI application for Android and iOS that implements a configurable interval timer. Users can create templates consisting of multiple time intervals and a global repetition count. Templates are stored locally on the device.

## Structure
- **IntervalTimerApp** – MAUI project containing the code
  - `Models` – timer data classes
  - `Services` – simple JSON storage service
  - `Views` – pages used in the application
  - `Platforms` – platform specific stubs for Android and iOS

## Usage
This project was created manually without running `dotnet new maui`. If you have a .NET MAUI environment, open the solution and deploy to Android or iOS.
