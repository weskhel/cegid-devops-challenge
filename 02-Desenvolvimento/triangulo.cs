using System;

public abstract class Triangulo
{
    protected double lado1, lado2, lado3;

    public Triangulo(double lado1, double lado2, double lado3)
    {
        this.lado1 = lado1;
        this.lado2 = lado2;
        this.lado3 = lado3;
    }

    public abstract string ClassificarLados();
    public abstract string ClassificarAngulos();
    public abstract double CalcularArea();
    public abstract double CalcularPerimetro();
}

public class TrianguloEquilatero : Triangulo
{
    public TrianguloEquilatero(double lado) : base(lado, lado, lado) {}

    public override string ClassificarLados()
    {
        return "Equilátero";
    }

    public override string ClassificarAngulos()
    {
        return "Retângulo";
    }

    public override double CalcularArea()
    {
        return Math.Sqrt(3) / 4 * lado1 * lado1;
    }

    public override double CalcularPerimetro()
    {
        return 3 * lado1;
    }
}

public class TrianguloIsosceles : Triangulo
{
    public TrianguloIsosceles(double lado1, double lado2, double lado3) : base(lado1, lado2, lado3) {}

    public override string ClassificarLados()
    {
        if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            return "Isósceles";
        else
            return "Escaleno";
    }

    public override string ClassificarAngulos()
    {
        if (lado1 == lado2 && lado1 == lado3)
            return "Equilátero";
        else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            return "Isósceles";
        else
            return "Escaleno";
    }

    public override double CalcularArea()
    {
        double p = CalcularPerimetro() / 2;
        double baseTriangulo = lado1 == lado2 ? lado3 : lado2;
        return Math.Sqrt(p * (p - lado1) * (p - baseTriangulo) * (p - baseTriangulo)) ;
    }

    public override double CalcularPerimetro()
    {
        return lado1 + lado2 + lado3;
    }
}

public class TrianguloEscaleno : Triangulo
{
    public TrianguloEscaleno(double lado1, double lado2, double lado3) : base(lado1, lado2, lado3) {}

    public override string ClassificarLados()
    {
        return "Escaleno";
    }

    public override string ClassificarAngulos()
    {
        if (Math.Pow(lado1, 2) + Math.Pow(lado2, 2) == Math.Pow(lado3, 2) ||
            Math.Pow(lado1, 2) + Math.Pow(lado3, 2) == Math.Pow(lado2, 2) ||
            Math.Pow(lado2, 2) + Math.Pow(lado3, 2) == Math.Pow(lado1, 2))
            return "Retângulo";
        else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            return "Isósceles";
        else
            return "Escaleno";
    }

    public override double CalcularArea()
    {
    double p = CalcularPerimetro() / 2;
    return Math.Sqrt(p * (p - lado1) * (p - lado2) * (p - lado3));
    }

    public override double CalcularPerimetro()
    {
        return lado1 + lado2 + lado3;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Digite as medidas dos lados do triângulo separadas por espaço:");
        string[] medidas = Console.ReadLine().Split();
        double lado1 = Convert.ToDouble(medidas[0]);
        double lado2 = Convert.ToDouble(medidas[1]);
        double lado3 = Convert.ToDouble(medidas[2]);
        Triangulo triangulo;

        if (lado1 == lado2 && lado1 == lado3)
            triangulo = new TrianguloEquilatero(lado1);
        else
            triangulo = new TrianguloIsosceles(lado1, lado2, lado3);

        Console.WriteLine("Classificação quanto aos lados: " + triangulo.ClassificarLados());
        Console.WriteLine("Classificação quanto aos ângulos: " + triangulo.ClassificarAngulos());
        Console.WriteLine("Área: " + triangulo.CalcularArea());
        Console.WriteLine("Perímetro: " + triangulo.CalcularPerimetro());
    }
}