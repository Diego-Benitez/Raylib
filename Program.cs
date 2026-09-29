using System.Numerics;
using Raylib_cs;

class Program
{
    static void Main(string[] args)
    {
        // Inicjalizacja okna
        Raylib.InitWindow(600, 400, "Raylib w C# - Pierwszy program");
        Raylib.SetTargetFPS(60);

        //Ball ball = new Ball(new Vector2(50, 10), Color.Lime);
        List<Ball> balls = new();

        // Główna pętla programu
        while (!Raylib.WindowShouldClose())
        {
            if(Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Vector2 clickPosition = Raylib.GetMousePosition();
                Ball newBall = new Ball(clickPosition);
                balls.Add(newBall);
            }

            // Start rysowania
            Raylib.BeginDrawing();

            // Wyczyść ekran
            Raylib.ClearBackground(Color.Black);

            for(int i = balls.Count-1; i >= 0; i--)
            {
                balls[i].Update();
                balls[i].Draw();

                if(balls[i].IsOutOfScreen())
                    balls.RemoveAt(i);
            }
            // Rysuj tekst
            Raylib.DrawText("Kliknij!", 25, 15, 25, Color.SkyBlue);
            Raylib.DrawText($"Kulki: {balls.Count}", 25, 50, 15, Color.SkyBlue);

            // Zakończ rysowanie
            Raylib.EndDrawing();
        }

        // Zamknięcie okna
        Raylib.CloseWindow();
    }
}