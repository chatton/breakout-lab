# Breakout: MAUI mock lab exam (90 min)

`template/` contains just two files: `MainPage.xaml` (given complete: layout, styles and `x:Name`s, but no event wiring) and `MainPage.xaml.cs` (all the TODOs, with hints). No XAML needs to be written.

It targets **.NET 10** (`FadeToAsync`, `ScaleToAsync`, etc.). On .NET 8/9, drop the `Async` suffix from the animation methods.

## Setup

1. Create a new MAUI app named `BreakoutExam`:
   - **Visual Studio 2026** (needs the *.NET Multi-platform App UI development* workload): Create a new project → **.NET MAUI App** → name it `BreakoutExam` → Framework **.NET 10.0**. Leave **Include sample content** unticked: that option moves `MainPage` into a `Pages/` folder with a view model, and these files won't fit it. Visual Studio 2022 doesn't support .NET 10.
   - **Command line:** `dotnet new maui -n BreakoutExam`
2. Replace the new project's `MainPage.xaml` and `MainPage.xaml.cs` (in the project root, next to `App.xaml`) with the two files from `template/`. In Visual Studio you can copy them over in File Explorer; it picks up the change automatically.

Nothing else in the project needs changing. If you use a different project name, change `BreakoutExam` in the `namespace` line and in `x:Class`.

## Running it

- **Windows (Visual Studio):** pick **Windows Machine** in the run target dropdown and press F5. This is the fastest option. On Windows the paddle buttons work with press-and-hold of the mouse.
- **macOS (Mac Catalyst):** `dotnet build BreakoutExam -f net10.0-maccatalyst && dotnet build BreakoutExam -t:Run -f net10.0-maccatalyst`. `-t:Run` on its own doesn't rebuild, so build first. If your Xcode is a newer minor version than the .NET MacCatalyst pack expects, add `-p:ValidateXcodeVersion=false` to both.
- **Command line, Android:** `dotnet build BreakoutExam -t:Run -f net10.0-android` with an emulator running or a phone connected.
- **Linux:** MAUI only supports Android on Linux, so use an emulator: `./run-android.sh path/to/BreakoutExam`.

## Parts

| Part | Concept | Task | Time |
|---|---|---|---|
| A | XAML layout and styles | Given: read `MainPage.xaml` to see the named elements and `BrickStyle` | — |
| B | Event wiring | Subscribe handlers in C# (`Clicked`, paddle `Pressed`/`Released`, `SizeChanged`) and write them | 10 min |
| C | Runtime UI | Generate the brick grid in C#, applying `BrickStyle` from resources | 15 min |
| D | Async animations | Bricks drop in, game-over label, and brick destruction, all using `Task.WhenAll` | 15 min |
| E | Timers | Countdown clock shown in a label that ends the game at 0, plus the game-loop timer | 20 min |
| F | Gameplay | Paddle movement, wall/paddle/brick collisions, win/lose | 15 min |
| G | Preferences | Load the high score on startup, save it when beaten | 5 min |

That totals 80 minutes on paper. If time is short, cut F (D and E already cover async and timers).
