//// See https://aka.ms/new-console-template for more information
//using System.Globalization;

//var time = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:fff");


//var date = time.Substring(0,19);
//var milliSecond = double.Parse(time.Substring(20,3));
//DateTime dt = DateTime.Parse(date);

//dt.AddMilliseconds(milliSecond);

//dt.Add(TimeSpan.FromMilliseconds(milliSecond));

//DateTime dt1 = DateTime.ParseExact(time, "yyyy-MM-dd hh:mm:ss:fff", System.Globalization.CultureInfo.CurrentCulture);

//DateTime dt2 = DateTime.ParseExact(time, "yyyy-MM-dd hh:mm:ss:fff", System.Globalization.CultureInfo.InvariantCulture);

//DateTime now = DateTime.UtcNow; // all dates should be kept in UTC internally
//// convert time to local and format appropriately for end user
//var Text = now.ToLocalTime().ToString(CultureInfo.CurrentCulture);

//DateTime dt3 = DateTime.Now;

//Console.WriteLine(dt.ToString("yyyy-MM-dd hh:mm:ss:fff")); Console.WriteLine(dt1.ToString("yyyy-MM-dd hh:mm:ss:fff"));
//Console.WriteLine(dt3.ToString("yyyy-MM-dd hh:mm:ss:fff"));
//Console.WriteLine(dt2.ToString("yyyy-MM-dd hh:mm:ss:fff")); Console.WriteLine(now.ToString("yyyy-MM-dd hh:mm:ss:fff"));


Console.ReadKey();
