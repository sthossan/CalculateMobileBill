MobileBillCalculate();
Console.WriteLine("Y/N");
if (Console.ReadLine().ToLower() == "y")
    MobileBillCalculate();

static void MobileBillCalculate()
{
    Console.Clear();
    var peakHourStart = new TimeSpan(9, 0, 0);
    var peakHourEnd = new TimeSpan(22, 59, 0);

    var offPeakHourStart = new TimeSpan(23, 0, 0);
    var offPeakHourEnd = new TimeSpan(8, 59, 0);



    Console.WriteLine("Input Start Time (2019-08-31 08:59:13 am):");
    DateTime startTime = Convert.ToDateTime(Console.ReadLine().ToString());

    Console.WriteLine("End Time (2019-08-31 09:00:39 am):");
    DateTime endTime = Convert.ToDateTime(Console.ReadLine().ToString());


    decimal bill = 0;

    if (startTime >= endTime)
    {
        Console.WriteLine("Invalid Time");
        endTime = Convert.ToDateTime(Console.ReadLine());
    }
    DateTime timeNow = startTime;
    bool stratFromPeak = (timeNow.TimeOfDay.CompareTo(peakHourStart) >= 0 && timeNow.TimeOfDay.CompareTo(peakHourEnd) <= 0);

    while (timeNow <= endTime)
    {
        timeNow = timeNow.AddSeconds(19);
        TimeSpan timeOfcall = timeNow.TimeOfDay;

        if (stratFromPeak || (timeOfcall.CompareTo(peakHourStart) >= 0 && timeOfcall.CompareTo(peakHourEnd) <= 0))
        {
            bill += .3M;
            Console.WriteLine("{0}, {1} ", bill, timeNow);
        }
        else if (timeOfcall.CompareTo(offPeakHourStart) >= 0 && timeOfcall.CompareTo(offPeakHourEnd) <= 0)
        {
            bill += .2M;
            Console.WriteLine("{0}, {1} ", bill, timeNow);

        }
    }

    Console.WriteLine("{0:#,0.00} taka", bill);
}