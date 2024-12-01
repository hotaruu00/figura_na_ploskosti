using System;

namespace ShapeInterface
{
    // Интерфейс определяет методы для работы с фигурой на плоскости
    interface IShape
    {
        void Move(double deltaX, double deltaY); // Перемещение фигуры
        void Rotate(double angle);              // Поворот фигуры
        double GetArea();                       // Площадь фигуры
        string GetLocation();                   // Текущее местоположение
    }

    // Базовый класс, представляющий фигуру на плоскости
    class Shape : IShape
    {
        protected double x; // Координата X
        protected double y; // Координата Y
        protected double rotationAngle; // Текущий угол поворота фигуры

        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.rotationAngle = 0; // Начальный угол поворота
        }

        public void Move(double deltaX, double deltaY)
        {
            x += deltaX;
            y += deltaY;
        }

        public void Rotate(double angle)
        {
            rotationAngle += angle;
            rotationAngle %= 360; // Угол остается в пределах 0–360 градусов
            Console.WriteLine($"Фигура повернута. Текущий угол: {rotationAngle} градусов.");
        }

        public virtual double GetArea()
        {
            Console.WriteLine("Площадь фигуры базового класса не определена.");
            return 0;
        }

        public string GetLocation()
        {
            return $"({x}, {y})";
        }
    }

    // Производный класс Rectangle (Прямоугольник)
    class Rectangle : Shape
    {
        private double width;  // Ширина
        private double height; // Высота

        public Rectangle(double x, double y, double width, double height) : base(x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override double GetArea()
        {
            return width * height;
        }
    }

    // Производный класс Triangle (Треугольник)
    class Triangle : Shape
    {
        private double baseLength; // Основание
        private double height;     // Высота

        public Triangle(double x, double y, double baseLength, double height) : base(x, y)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public override double GetArea()
        {
            return 0.5 * baseLength * height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация работы с прямоугольником
            Rectangle rect = new Rectangle(5, 8, 10, 4);
            Console.WriteLine("Прямоугольник:");
            Console.WriteLine("Начальное местоположение: " + rect.GetLocation());
            Console.WriteLine("Площадь: " + rect.GetArea());

            rect.Move(6, 4);
            Console.WriteLine("Новое местоположение: " + rect.GetLocation());
            rect.Rotate(45);

            // Демонстрация работы с треугольником
            Triangle tri = new Triangle(2, 3, 6, 4);
            Console.WriteLine("\nТреугольник:");
            Console.WriteLine("Начальное местоположение: " + tri.GetLocation());
            Console.WriteLine("Площадь: " + tri.GetArea());

            tri.Move(1, 1);
            Console.WriteLine("Новое местоположение: " + tri.GetLocation());
            tri.Rotate(30);
        }
    }
}
