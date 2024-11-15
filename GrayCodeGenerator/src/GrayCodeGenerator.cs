namespace GrayCodeGenerator;

public static class GrayCodeGenerator
{
    public static List<string> GenerateGrayCodes(int bits)
    {
        switch (bits)
        {
            case 0:
                return ["0"];
            case 1:
                return ["0", "1"];
        }

        // Recursive
        var smallerGrayCodes = GenerateGrayCodes(bits - 1);

        List<string> grayCodes = [];
        grayCodes.AddRange(smallerGrayCodes.Select(grayCode => "0" + grayCode));
        grayCodes.AddRange(smallerGrayCodes.Select(grayCode => "1" + grayCode).Reverse());

        return grayCodes;
    }

    public static void SaveToFile(List<string> grayCodes, string fileName)
    {
        // 保存到根目录
        var path = Path.Combine(Environment.CurrentDirectory, fileName);
        using var writer = new StreamWriter(path);
        foreach (var grayCode in grayCodes) writer.WriteLine(grayCode);
    }

    public static string ConvertBinaryToGray(string binary)
    {
        var gray = binary[0].ToString();
        for (var i = 1; i < binary.Length; i++) gray += binary[i - 1] == binary[i] ? "0" : "1";

        return gray;
    }

    public static string ConvertGrayToBinary(string gray)
    {
        var binary = gray[0].ToString();
        for (var i = 1; i < gray.Length; i++) binary += binary[i - 1] == gray[i] ? "0" : "1";

        return binary;
    }
}