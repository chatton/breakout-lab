namespace BreakoutExam;

// The game settings and state fields below are given to you. Everything marked TODO is yours.
// Work through the parts in order (A to G). The app should build and run after every part.

public partial class MainPage : ContentPage
{
    // ---- Game settings (given) ----
    const int BrickRows = 5;
    const int BrickColumns = 8;
    const double BrickHeight = 20;
    const double BrickSpacing = 6;
    const double BrickTopOffset = 40;

    const double PaddleWidth = 100;
    const double PaddleHeight = 15;
    const double PaddleBottomOffset = 30;
    const double PaddleSpeed = 10;

    const double BallSize = 16;
    const double BallSpeed = 3;

    const int GameLengthSeconds = 60;

    const string HighScoreKey = "HighScore";

    static readonly Color[] RowColors =
        { Colors.Red, Colors.Orange, Colors.Yellow, Colors.LimeGreen, Colors.DeepSkyBlue };

    // ---- Game state (given) ----
    IDispatcherTimer? gameTimer;
    IDispatcherTimer? countdownTimer;
    readonly List<BoxView> bricks = new();

    double ballX, ballY;   // ball position (top-left corner)
    double dx, dy;         // ball velocity per tick
    double paddleX;        // paddle position (left edge)
    int moveDirection;     // -1 = left, 0 = still, 1 = right
    int score;
    int highScore;
    int secondsLeft;
    bool isPlaying;

    // TODO (after Part A): uncomment once GameArea exists in your XAML.
    // The paddle's y position: near the bottom of the play area.
    // double PaddleY => GameArea.Height - PaddleBottomOffset - PaddleHeight;

    public MainPage()
    {
        InitializeComponent();

        // TODO E1: create the game loop timer (~60 ticks per second) and hook up OnGameTick.
        // Hint: gameTimer = Dispatcher.CreateTimer();
        // Hint: Interval is a TimeSpan, e.g. TimeSpan.FromMilliseconds(16)
        // Hint: subscribe to an event with  gameTimer.Tick += OnGameTick;

        // TODO E2: create the countdown timer (once per second) and hook up OnCountdownTick.

        // TODO G1: call LoadHighScore() so the saved best score shows as soon as the app opens.
    }

    // =====================================================================
    // PART B: button handlers  (~10 min)
    // =====================================================================

    // TODO B1: Start button.
    //   1. Disable StartButton so it can't be pressed twice
    //   2. Call ResetGame() and CreateBricks()
    //   3. Await AnimateBricksInAsync() (Part D)
    //   4. Set isPlaying = true and start both timers (Part E)
    // Hint: event handlers are the one place where "async void" is OK.
    void OnStartClicked(object? sender, EventArgs e)
    {
    }

    // TODO B2: set moveDirection to -1, 1, or 0.
    // The paddle does NOT move here. The game loop moves it every tick while a button is held.
    void OnLeftPressed(object? sender, EventArgs e)
    {
    }

    void OnRightPressed(object? sender, EventArgs e)
    {
    }

    void OnMoveReleased(object? sender, EventArgs e)
    {
    }

    // TODO B3: if the game isn't running, call CentrePaddleAndBall().
    // Why here and not in the constructor? Try printing GameArea.Width in the constructor.
    void OnGameAreaSizeChanged(object? sender, EventArgs e)
    {
    }

    // =====================================================================
    // PART C: creating UI at runtime  (~15 min)
    // =====================================================================

    // TODO C1: create BrickRows x BrickColumns BoxViews and add them to GameArea and to the bricks list.
    //   - Work out brickWidth so BrickColumns bricks, with BrickSpacing between and around them,
    //     fill GameArea.Width
    //   - Apply the BrickStyle from your XAML resources
    //   - Give each row its own colour from RowColors
    //   - For Part D: start each brick with Opacity = 0 and TranslationY = -200
    // Hint: var brickStyle = (Style)Resources["BrickStyle"];
    // Hint: AbsoluteLayout.SetLayoutBounds(brick, new Rect(x, y, width, height));
    // Hint: GameArea.Children.Add(brick);
    void CreateBricks()
    {
    }

    // TODO C2: get ready for a new game.
    //   - Remove any old bricks from GameArea.Children and clear the list
    //   - Reset score, secondsLeft, and moveDirection, and update both labels
    //   - Hide GameOverLabel again
    //   - Call CentrePaddleAndBall() and set the ball's starting velocity (dx, dy)
    // Hint: Random.Shared.Next(2) gives 0 or 1, handy for a random left/right start
    void ResetGame()
    {
    }

    // TODO C3: put the paddle centred horizontally and the ball in the middle of the play area,
    //   then call PlacePaddle() and PlaceBall().
    void CentrePaddleAndBall()
    {
    }

    // =====================================================================
    // PART D: async animations with Task.WhenAll  (~15 min)
    // =====================================================================
    // Animation methods (.NET 10): FadeToAsync, ScaleToAsync, TranslateToAsync, RotateToAsync.
    //   (On .NET 8/9 they are called FadeTo, ScaleTo, TranslateTo, RotateTo.)
    // They all return a Task, so you can await them.
    // Task.WhenAll(task1, task2, ...) runs them at the same time and finishes when ALL are done.

    // TODO D1: drop ALL the bricks in at the same time, and finish when the last one lands.
    //   Await this before the game starts.
    // Hint: call DropInAsync for every brick, then Task.WhenAll the resulting tasks
    // Stretch: make each row start a little later than the one above (row = i / BrickColumns)
    Task AnimateBricksInAsync()
    {
        return Task.CompletedTask; // replace with your own code
    }

    // TODO D2: wait delayMs, then fade the brick in AND move it into place at the same time.
    // Hint: await Task.Delay(delayMs);
    // Hint: brick.TranslateToAsync(0, 0, 600, Easing.BounceOut) moves it back to its real slot
    static async Task DropInAsync(BoxView brick, int delayMs)
    {
        await Task.CompletedTask; // remove this line once you've added your own awaits
    }

    // TODO D3 (used in Part F): animate a hit brick away (fade + scale + rotate together),
    //   THEN remove it from GameArea.Children.
    // Think: when should it be removed from the bricks LIST, before or after the animation? Why?
    async Task DestroyBrickAsync(BoxView brick)
    {
        await Task.CompletedTask; // remove this line once you've added your own awaits
    }

    // TODO D4: show GameOverLabel with the message and the final score,
    //   fading in and scaling up at the same time.
    // Hint: set Scale small, Opacity to 0 and IsVisible = true BEFORE animating
    // Hint: "\n" in a string starts a new line in the label
    async Task ShowGameOverAsync(string message)
    {
        await Task.CompletedTask; // remove this line once you've added your own awaits
    }

    // =====================================================================
    // PART E: timers  (~20 min)
    // =====================================================================

    // TODO E3: count down by one, update TimeLabel, and end the game ("Time's up!") at zero.
    void OnCountdownTick(object? sender, EventArgs e)
    {
    }

    // TODO E4: called ~60 times a second. Move the paddle, then move the ball.
    void OnGameTick(object? sender, EventArgs e)
    {
    }

    // TODO E5: stop the game.
    //   - Guard against ending twice (both the clock and the ball can end the game)
    //   - Stop BOTH timers and reset moveDirection
    //   - (Part G) if score beats highScore, SaveHighScore(score) and add "New high score!" to the message
    //   - Await ShowGameOverAsync(message)
    //   - Re-enable StartButton (text "Play again")
    async Task EndGameAsync(string message)
    {
        await Task.CompletedTask; // remove this line once you've added your own awaits
    }

    // =====================================================================
    // PART F: gameplay  (~15 min)
    // =====================================================================

    // TODO F1: move paddleX by moveDirection * PaddleSpeed, keep it inside the play area, then PlacePaddle().
    // Hint: Math.Clamp(value, min, max)
    void MovePaddle()
    {
    }

    // TODO F2: the ball.
    //   1. Add dx/dy to ballX/ballY
    //   2. Bounce off the left, right and top walls
    //   3. If it goes past the bottom: EndGameAsync("Missed!")
    //   4. Bounce off the paddle
    //   5. If it hits a brick: reverse dy, add to the score, DestroyBrickAsync(brick),
    //      and if no bricks are left: EndGameAsync("You win!")
    //   6. PlaceBall()
    // Hint: var ballRect = new Rect(ballX, ballY, BallSize, BallSize);
    //       ballRect.IntersectsWith(otherRect)
    // Hint: AbsoluteLayout.GetLayoutBounds(brick) gives a brick's Rect
    // Hint: don't await DestroyBrickAsync or EndGameAsync in here. What would happen
    //       to the game loop if you did? Use  _ = DestroyBrickAsync(hit);
    // Hint: if the ball gets "stuck" in a wall, set dx = Math.Abs(dx) instead of dx = -dx
    void MoveBall()
    {
    }

    // =====================================================================
    // PART G: preferences (high score)  (~5 min)
    // =====================================================================
    // Preferences store small key/value settings that survive closing and reopening the app.
    // Hint: Preferences.Default.Get(key, defaultValue) returns defaultValue if nothing is saved yet
    // Hint: Preferences.Default.Set(key, value)
    // Use the HighScoreKey constant for the key so the two methods can't disagree on spelling.

    // TODO G2: read the saved high score into highScore and update HighScoreLabel.
    void LoadHighScore()
    {
    }

    // TODO G3: store the new high score in highScore AND in Preferences, then update HighScoreLabel.
    void SaveHighScore(int newHighScore)
    {
    }

    // =====================================================================
    // Helpers (fill these in after Part A, once the named elements exist)
    // =====================================================================

    // TODO H1: HighScoreLabel.Text = "Best: N"
    void UpdateHighScoreLabel()
    {
    }

    // TODO H2: move Paddle to (paddleX, PaddleY), size PaddleWidth x PaddleHeight.
    // Hint: AbsoluteLayout.SetLayoutBounds(Paddle, new Rect(...));
    void PlacePaddle()
    {
    }

    // TODO H3: move Ball to (ballX, ballY), size BallSize x BallSize.
    void PlaceBall()
    {
    }

    // TODO H4: ScoreLabel.Text = "Score: N"
    void UpdateScoreLabel()
    {
    }

    // TODO H5: TimeLabel.Text = "Time: N"
    void UpdateTimeLabel()
    {
    }
}
