# Insurance
Insurance Project is an end to end solution that gives the ability to choose various options on the screen to view the monthly premiums calculated and displayed.
The UI has below mandatory inputs :
- Name
- Age
- Date of Birth
- Occupation
- Sum Insured.
 
**Technologies Used:**
- .NET 5 Web API with C# for backend 
- Angular 12 for the frontend
- Material UI for the UI Components with css and boostrap for styling
- xUnit Testing with MOQ framework

**Getting Started**
Prerequisites:
Node version of 16.6.2 or higher
Angular CLI version of 12 or higher
NPM version of 7 or higher
Visual Studio 2019
.Net 5.0

**Steps to follow to run the applications:**
1. Open the backend InsuranceAPI solution file (InsuranceAPI.sln) in Visual Studio 
    https://github.com/haripriyarajs/Insurance/tree/main/Backend/InsuranceAPI
2. All the API endpoints can be individually tested through Swagger integrated with .NET 5 WebApi
    http://localhost:11671/swagger/index.html
3. Navigate to the below FrontEnd folder and open in Visual studio code(for ease of access)
    https://github.com/haripriyarajs/Insurance/tree/main/FrontEnd/insurance-app
4. run **npm install **
5. To Launch the UI, run the command **ng serve -o**

**Assumptions**
1. Age is auto calculated on basis of the date of birth entered.
2. Sum Insured is a decimal slider.
3. Monthly Premium gets calculated only when the age > 0, sumInsured > 0 and a valid occupation is selected.
4. Monthly premium gets recalculated on change of any of the mandatory values.
5. The occupations listed and the monthly premium calculation is through the Web API.
6. The data for the caluclations are being used from the Json file for now.

**Future Scope**
1. Data can be pulled from DB with the help of Entity Framework Core and using repository pattern.
2. Authentication can be implemented for the API using JWT token or Azure AD.

