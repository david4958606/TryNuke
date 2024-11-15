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
        for (var i = smallerGrayCodes.Count - 1; i >= 0; i--) grayCodes.Add("1" + smallerGrayCodes[i]);

        return grayCodes;
    }

    public static void SaveToFile(List<string> grayCodes, string fileName)
    {
        using var writer = new StreamWriter(fileName);
        foreach (var grayCode in grayCodes) writer.WriteLine(grayCode);
    }
}