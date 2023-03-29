class Apple {
    public string Color { get; set; }
    public int Weight { get; set; }
}

List<Apple> apples = new List<Apple>(){
    new Apple() { Color = "red", Weight = 190 },
    new Apple() { Color = "green", Weight = 200 },
    new Apple() { Color = "red", Weight = 300 },
    new Apple() { Color = "green", Weight = 400 },
    new Apple() { Color = "red", Weight = 500 },
    new Apple() { Color = "green", Weight = 600 },
    new Apple() { Color = "red", Weight = 700 },
    new Apple() { Color = "green", Weight = 800 },
    new Apple() { Color = "red", Weight = 900 },
    new Apple() { Color = "green", Weight = 1000 },
};

apples.Where(a => a.Color == "red").Sum(a => a.Weight);
apples.Where(a => a.Color == "red").Select(a => a.Weight).Average();

int es1 = apples.Where(a => a.Color == "red").Select(a => a.Weight).Min();

string es2 = apples.Where(a => a.Weight == 190).Select(a => a.Color).ToString();

int es3= apples.Where(a => a.Color == "red").Count();

int es4 = apples.Where(a => a.Color == "green").Select(a => a.Weight).Sum();

Console.WriteLine(es1.ToString()+" "+ es2+" "+ es3.ToString()+" "+ es4);