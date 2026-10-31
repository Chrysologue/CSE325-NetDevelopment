# Assignment Notes

## 1. Pizza List Evidence
The PizzaService contains the following items, including our newly added pizza:
- Id: 1, Name: Classic Italian, IsGlutenFree: false
- Id: 2, Name: Veggie, IsGlutenFree: true
- Id: 3, Name: BBQ Chicken, IsGlutenFree: false
- Id: 4, Name: Hawaii, IsGlutenFree: false

---

## 2. API Operations Evidence

- **GET /pizza**
  - **Request:** `GET http://localhost:5019/pizza`
  - **Response:** 
    ```json
    [
      {
        "id": 1,
        "name": "Classic Italian",
        "isGlutenFree": false
      },
      {
        "id": 2,
        "name": "Veggie",
        "isGlutenFree": true
      },
      {
        "id": 3,
        "name": "BBQ Chicken",
        "isGlutenFree": false
      }
    ]
    ```
  - **Status Code:** `200 OK`

- **GET /pizza/1**
  - **Request:** `GET http://localhost:5019/pizza/1`
  - **Response:** 
    ```json
    {
      "id": 1,
      "name": "Classic Italian - Updated",
      "isGlutenFree": false
    }
    ```
  - **Status Code:** `200 OK`

- **POST /pizza**
  - **Request:** `POST http://localhost:5019/pizza` (Body: `{"name": "Hawaii", "isGlutenFree": false}`)
  - **Response:** `{"name":"Hawaii","isGlutenFree":false}`
  - **Status Code:** `201 Created`

- **PUT /pizza/1**
  - **Request:** `PUT http://localhost:5019/pizza/1` (Body: `{"id":1,"name":"Classic Italian - Updated","isGlutenFree":false}`)
  - **Response:** *(No body)*
  - **Status Code:** `204 No Content`

- **DELETE /pizza/4**
  - **Request:** `DELETE http://localhost:5019/pizza/4`
  - **Response:** *(No body)*
  - **Status Code:** `204 No Content`

---

## 3. Sales Summary Function
```csharp
public static void GenerateSalesSummary(string folderPath, string outputFilePath)
{
    string[] salesFiles = Directory.GetFiles(folderPath);
    decimal totalSales = 0;
    
    StringBuilder report = new StringBuilder();
    StringBuilder details = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");

    foreach (var file in salesFiles)
    {
        string fileName = Path.GetFileName(file);
        string fileContent = File.ReadAllText(file);

        if (decimal.TryParse(fileContent.Trim(), out decimal fileSales))
        {
            totalSales += fileSales;
            details.AppendLine($" {fileName}: {fileSales:C}");
        }
    }

    report.AppendLine($" Total Sales: {totalSales:C}");
    report.AppendLine();
    report.AppendLine(" Details:");
    report.Append(details.ToString());

    File.WriteAllText(outputFilePath, report.ToString());
}