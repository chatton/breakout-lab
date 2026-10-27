# Breakout: MAUI mock lab exam (90 min)

`template/` is a ready-to-run MAUI project. `MainPage.xaml` and `MainPage.xaml.cs` contain the TODOs (with hints) for each part.

It targets **.NET 10** (`FadeToAsync`, `ScaleToAsync`, etc.). On .NET 8/9, drop the `Async` suffix from the animation methods.

## Running it

- **Windows (Visual Studio):** open `template/BreakoutExam.csproj` and run the Windows Machine target. This is the fastest option.
- **Command line, Android:** `dotnet build template -t:Run -f net10.0-android` with an emulator running or a phone connected.
- **Linux:** MAUI only supports Android on Linux, so use an emulator. See `run-android.sh`.

## Parts

| Part | Concept | Task | Time |
|---|---|---|---|
| A | XAML layout and styles | Grid layout, `x:Name` on the key elements, `BrickStyle` in resources | 15 min |
| B | Event handlers | Start button, paddle `Pressed`/`Released`, `SizeChanged` | 10 min |
| C | Runtime UI | Generate the brick grid in C#, applying `BrickStyle` from resources | 15 min |
| D | Async animations | Bricks drop in, game-over label, and brick destruction, all using `Task.WhenAll` | 15 min |
| E | Timers | Countdown clock shown in a label that ends the game at 0, plus the game-loop timer | 20 min |
| F | Gameplay | Paddle movement, wall/paddle/brick collisions, win/lose | 15 min |
| G | Preferences | Load the high score on startup, save it when beaten | 5 min |

That totals 95 minutes on paper. If time is short, cut F (D and E already cover async and timers).
