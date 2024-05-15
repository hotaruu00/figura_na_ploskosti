using System;

namespace ShapeInterface
{
    // Интерфейс определяет методы для работы с фигурой на плоскости
    interface IShape
    {
        // Метод для перемещения фигуры на заданные значения по осям X и Y
        void Move(double deltaX, double deltaY);

        // Метод для поворота фигуры на указанный угол
        void Rotate(double angle);

        // Метод для определения площади фигуры
        double GetArea();

        // Метод для получения текущего местоположения фигуры
        string GetLocation();
    }

    // Базовый класс, представляющий фигуру на плоскости
    class Shape : IShape
    {
        private double x;
        private double y;

        // Конструктор класса Shape, устанавливающий начальное местоположение фигуры
        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Реализация метода Move интерфейса IShape
        public void Move(double deltaX, double deltaY)
        {
            // Изменяем координаты фигуры на указанные значения
            x += deltaX;
            y += deltaY;
        }

        // Реализация метода Rotate интерфейса IShape
        public void Rotate(double angle)
        {
            // Здесь должна быть реализация логики поворота фигуры
            Console.WriteLine($"Фигура повернута на {angle} градусов.");
        }

        // Реализация метода GetArea интерфейса IShape
        public double GetArea()
        {
            // Здесь должна быть реализация логики определения площади фигуры
            Console.WriteLine("Расчет площади не реализован.");
            return 0;
        }

        // Реализация метода GetLocation интерфейса IShape
        public string GetLocation()
        {
            // Возвращаем текущие координаты фигуры в виде строки
            return $"({x}, {y})";
        }
    }

    // Класс для демонстрации работы с фигурой
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Shape
            Shape shape = new Shape(5, 8);
            Console.WriteLine("Начальное местоположение: " + shape.GetLocation());

            // Перемещаем фигуру
            shape.Move(6, 40);
            Console.WriteLine("Новое местоположение после перемещения: " + shape.GetLocation());

            // Поворачиваем фигуру
            shape.Rotate(45);
            Console.WriteLine("Местоположение после поворота: " + shape.GetLocation());
        }
    }
}
