class House
{
    protected int houseNumber;
    protected int numberOfApartments;
    protected int constructionYear;
    public House(int houseNumber, int numberOfApartments, int constructionYear)
    {
        this.houseNumber = houseNumber;
        this.numberOfApartments = numberOfApartments;
        this.constructionYear = constructionYear;
    }
    public virtual int GetQuality()
    {
        int currentYear = DateTime.Now.Year;
        int Q = numberOfApartments + 2 * (currentYear - constructionYear);
        return Q;
    }
    public virtual void PrintInfo()
    {
        Console.WriteLine($"House number: {houseNumber}");
        Console.WriteLine($"Number of apartments: {numberOfApartments}");
        Console.WriteLine($"Construction year: {constructionYear}");
        Console.WriteLine($"Quality: {GetQuality()}");
    }
}
class DistrictHouse : House
{
    private string district;
    public DistrictHouse(int houseNumber, int numberOfApartments, int constructionYear, string district) : base(houseNumber, numberOfApartments, constructionYear)
    {
        this.district = district;
    }
    public override int GetQuality()
    {
        int Qp;
        int Q = base.GetQuality();

        if (district == "center")
        {
            Qp = 2 * Q;
        }
        else
        {
            Qp = (int)(0.5 * Q);
        }

        return Qp;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"District: {district}");
        Console.WriteLine($"Quality in district: {GetQuality()}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        House house = new House(1, 10, 2000);
        house.PrintInfo();
        Console.WriteLine();
        DistrictHouse districtHouse = new DistrictHouse(2, 20, 1990, "center");
        districtHouse.PrintInfo();

        Console.ReadLine();
    }
}