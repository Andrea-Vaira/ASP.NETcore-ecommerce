/*Func<DateTime, bool> canDrive = canDrive =>{
    return dob.AddYears(18) < DateTime.Today;
};

DateTime dob = new DateTime(2006, 1, 1);

bool result = canDrive(dob);
Console.WriteLine(result);

Action<DateTime> printDate = date => Console.WriteLine(date);*/

//Es1
Func<string, string, string> concatFirstAndLastName = (name, lastName) =>{
    return name + " " + lastName;
};
string name = "John";
string lastName = "Doe";
string completeName = concatFirstAndLastName(name, lastName);

//Es2
Func<int, int, int, int> getMaximun = (a, b, c) =>{
    return Math.Max(a, Math.Max(b, c));
};
int a = 1;
int b = 2;
int c = 3;
int max = getMaximun(a, b, c);

//Es3
Action<DateTime, DateTime> printLowerDate = (date1, date2) =>{
    if(date1 < date2){
        Console.WriteLine(date1);
    }else{
        Console.WriteLine(date2);
    }
};
DateTime date1 = new DateTime(2006, 1, 1);
DateTime date2 = new DateTime(2006, 1, 2);
printLowerDate(date1, date2);