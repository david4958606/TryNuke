using static GrayCodeGenerator.GrayCodeGenerator;


const int bits = 16;
const string fileName = "gray_code.txt";

var grayCodes = GenerateGrayCodes(bits);

SaveToFile(grayCodes, fileName);

Console.WriteLine($"All {grayCodes.Count} Gray codes saved to {fileName}");