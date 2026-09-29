using System.Numerics;
using Raylib_cs;

class Ball
{
    Vector2 position;
    Color color = Color.Lime;
    int size = 10;
    Vector2 velocity;
    float gravity = 0.5f;

    List<Vector2> trail = new();

    static Random random = new Random();
    public Ball(Vector2 startPos)
    {
        position = startPos;
        velocity = new Vector2(
            (float)(random.NextDouble() * 2 - 1) * 5,
            -5
        );
    }

    public void Draw()
    {
        for(int i=0; i < trail.Count; i++)
        {
            float scale = (float) i / trail.Count * size;
            Raylib.DrawCircleV(trail[i], scale, Color.Red);
        }
        Raylib.DrawCircleV(position, size, color);
    }

    public void Update()
    {
        trail.Add(position);
        if(trail.Count > 10)
        {
            trail.RemoveAt(0);
        }

        position += velocity;
        if(position.Y >= Raylib.GetScreenHeight() - size)
        {
            velocity.Y *= -1;
            position.Y = Raylib.GetScreenHeight() - size;
        }

        velocity.Y += gravity;
    }

    public bool IsOutOfScreen()
    {
        return position.X < 0 || position.X > Raylib.GetScreenWidth();
    }
}