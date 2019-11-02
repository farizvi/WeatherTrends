# Weather Trends

Weather Trends is a console application which reads historical rainfall data provided by Bureau of Meteorology in csv format and converts it in JSON.

## Project Overview

This application consists of following projects

### WeatherTrends.Domin

This project consists of the Domain entities for the application. In this case, there is only one domain entity named `WeatherData`

### WeatherTrends.Infrastructure

This project consists of all the helper libraries which are required by the appication to perform various operations. The processes for reading CSV file and writing data to a JSON file are implemented in this project

### WeatherTrends.Core

This project contains the business logic for this application.

### WeatherTrends.ConsoleApp

This project is the entry point for this application. It is the startup project and takes the CSV file as command line input when running

### WeatherTrends.UnitTests

This project contains the unit tests for this application

## Running Weather Trends Application

This application is developed using .Net Core 2.2. To run this application 

1. Install .Net Core 2.2 Framework(https://dotnet.microsoft.com/download/dotnet-core/2.2)
2. In command line, navigate to `WeatherTrends` directory
3. Execute
    ```
    dotnet restore
    ```
4. Navigate to `WeatherTrends.ConsoleApp` directory and execute
    ```
    dotnet run
    ```
5. Download input data from  this(http://www.bom.gov.au/jsp/ncc/cdio/weatherData/av?p_nccObsCode=136&p_display_type=dailyDataFile&p_startYear=&p_c=&p_stn_num=066062) by clicking the button *All years of data* on top right of the page.

### Sample Output

When the application completes its execution, it will generate a json file which will be like this

```
{
    "WeatherData": {
        "WeatherDataForYear": {
            "Year": "2019",
            "FirstRecordedDate": "2019-01-01",
            "LastRecordedDate": "2019-04-19",
            "TotalRainfall": "374.2",
            "AverageDailyRainfall": "3.411",
            "DaysWithNoRainfall": "65",
            "DaysWithRainfall": "44",
            "LongestNumberOfDaysRaining": "12",
            "MonthlyAggregates": {
                "WeatherDataForMonth": {
                    "Month": "January",
                    "FirstRecordedDate": "2019-01-01",
                    "LastRecordedDate": "2019-01-31",
                    "TotalRainfall": "48.8",
                    "AverageDailyRainfall": "1.571",
                    "MedianDailyRainfall": "22.1",
                    "DaysWithNoRainfall": "21",
                    "DaysWithRainfall": "10"
                }
            }
        }
    }
}
```

## Executing Unit Tests

To run the unit tests for this application, navigate to `WeatherTrends.UnitTests` directory and execute following command
```
dotnet test
```