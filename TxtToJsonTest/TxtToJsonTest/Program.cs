namespace TxtToJsonTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            string txtFilePath = "C:\\Users\\mmuradyan\\Desktop\\Validation_data.txt";
            string jsonFilePath = "C:\\Users\\mmuradyan\\Desktop\\newResult2.json";

            NewConverter converter = new NewConverter();

            converter.ConvertValidationDataToJson(txtFilePath, jsonFilePath);
        }
    }
}
