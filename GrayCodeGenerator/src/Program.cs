using System.Diagnostics;

namespace GrayCodeGenerator;

internal static class Program
{
    private static void Main()
    {
        while (true)
        {
            Console.WriteLine(@"请选择一个选项：");
            Console.WriteLine(@"1. 生成对应位数的格雷码列表");
            Console.WriteLine(@"2. 转换二进制到格雷码");
            Console.WriteLine(@"3. 转换格雷码到二进制");
            Console.WriteLine(@"4. 退出");
            Console.Write(@"请输入选项编号 (1-4): ");
            var option = Console.ReadLine();
            string? binary = null;
            string? gray = null;
            switch (option)
            {
                case "1":
                    Console.Write(@"请输入位数: ");
                    var bits = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                    var grayCodes = GrayCodeGenerator.GenerateGrayCodes(bits);
                    if (bits <= 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(@"生成的格雷码列表:");
                        Console.ResetColor();
                        foreach (var grayCode in grayCodes) Console.WriteLine(grayCode);
                    }

                    Console.Write(@"请输入文件名保存格雷码列表: ");
                    var fileName = Console.ReadLine();
                    Debug.Assert(fileName != null, nameof(fileName) + " != null");
                    GrayCodeGenerator.SaveToFile(grayCodes, fileName);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"格雷码列表已保存到文件 {fileName}，{bits} 位格雷码一共有 {grayCodes.Count} 个.");
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Write(@"请输入二进制数: ");
                    binary = Console.ReadLine();
                    if (binary != null) gray = GrayCodeGenerator.ConvertBinaryToGray(binary);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (gray != null) Console.WriteLine(@"转换后的格雷码: " + gray);
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Write(@"请输入格雷码: ");
                    gray = Console.ReadLine();
                    if (gray != null) binary = GrayCodeGenerator.ConvertGrayToBinary(gray);
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (binary != null) Console.WriteLine(@"转换后的二进制数: " + binary);
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                case "4":
                    return;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"无效选项.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}