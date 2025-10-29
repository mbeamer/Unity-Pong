Unity Pong-like game

Files created:
- `Assets/Scripts/Paddle.cs` - paddle movement for left/right players (W/S and Up/Down).
- `Assets/Scripts/Ball.cs` - ball movement, collision response, scoring.
- `Assets/Scripts/GameManager.cs` - keeps score and resets the ball.
- `Assets/Scripts/UIManager.cs` - simple UI text updater.

Quick setup instructions (inside Unity):
1. Create a new 2D scene.
2. Add two paddles: create `GameObject > 2D Object > Sprite` or `Quad`, attach `Paddle` script and set `isLeft` appropriately. Add a `BoxCollider2D` and set tag to `Paddle`.
3. Add a ball: create `GameObject > 2D Object > Sprite`, attach `Ball` script and `Rigidbody2D` (set Body Type to Dynamic, Gravity Scale 0), and a `CircleCollider2D`.
4. Add top/bottom walls: create thin sprites with `BoxCollider2D` to bounce the ball.
5. Create an empty `GameObject` and attach `GameManager` script. Assign an instance of `UIManager` if you add UI Text objects.
6. Create UI Text objects (Legacy Text or TextMeshPro) and link to `UIManager`.

Controls:
- Left paddle: `W` (up), `S` (down)
- Right paddle: `UpArrow`, `DownArrow`

This is a minimal starting point. Tweak speeds, sizes, and physics settings in the inspector.
